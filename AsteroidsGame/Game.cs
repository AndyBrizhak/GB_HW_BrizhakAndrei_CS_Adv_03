using System;
using System.Windows.Forms;
using System.Drawing;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3

namespace AsteroidsGame
{
    /// <summary>
    /// класс, где будут происходить все действия игры
    /// </summary>
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        /// <summary>
        /// статический таймер для класса Game
        /// </summary>
        private static Timer _timer = new Timer();

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        public static Random Rnd = new Random();

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        /// <summary>
        /// Максимальная высота и ширина экрана
        /// </summary>
        const int MaxH = 1000, MaxW = 1000;

        // <summary>
        /// массив объектов BaseObject
        /// </summary>
        public static BaseObject[] _objs;

        /// <summary>
        /// Обьект типа Bullet
        /// </summary>
        private static Bullet _bullet;

        /// <summary>
        /// массив объектов Asteroid
        /// </summary>
        private static Asteroid[] _asteroids;

        /// <summary>
        /// статитческий обьект Корабль +
        /// </summary>
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

        static Game()
        {
        }

        /// <summary>
        /// Инициализация сцены и обьектов
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {



            // Графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics(); // Создаём объект - поверхность рисования и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;

            //  Задача 4 ДЗ Проверка на задание размера экрана. Если высота или ширина(Width,
            //      Height) больше 1000 или принимает отрицательное значение, то выбросить исключение
            //  ArgumentOutOfRangeException().
            CheckSizeScreen(Width, Height);

            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            _timer.Start();
            _timer.Tick += Timer_Tick;
            //NewMethod();
            //учет нажатия на клавишы
            form.KeyDown += Form_KeyDown;

        }

        //private static void NewMethod()
        //{
        //   Timer timer = new Timer {Interval = 100};
        //    timer.Start();
        //    timer.Tick += Timer_Tick;
        //}

        /// <summary>
        /// обработка событий Ctrl создаем снаряд, Up -сдвиг корабля вверх, Down -сдвиг корабля вниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }


        /// <summary>
        /// Обработчик таймера в котором вызываются Draw () и Update();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// вывод графики
        /// </summary>
        public static void Draw()
        {
            // Проверяем вывод графики
            // Buffer.Graphics.Clear(Color.Black);
            // Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            // Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            // Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();

            foreach (Asteroid obj in _asteroids)
                obj?.Draw();

            _bullet?.Draw();

            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);

            Buffer.Render();
        }

        /// <summary>
        /// инициализация  объектов
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(800, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(800, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new
                    Size(r, r));
            }

            // for (int i = 0; i < _objs.Length / 3; i++)
            //    _objs[i] = new Planet(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            //for (int i = _objs.Length / 3; i < _objs.Length / 3 * 2; i++)
            //    _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(10, 10));
            // for (int i = _objs.Length / 3 * 2; i < _objs.Length; i++)
            //     _objs[i] = new SmallRedStar(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));
        }

        /// <summary>
        /// изменения состояния объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            _bullet.Update();

            //  foreach (Asteroid a in _asteroids)
            //   {
            //
            //       if (a.Collision(_bullet))
            //       {
            //          System.Media.SystemSounds.Hand.Play();   // подать звуковой сигнал
            //          a.Crash();                               //изменить положение обьекта   
            //          _bullet.Crash();                         //изменить положение обьекта    
            //       }
            //      a.Update();
            //  }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }


        }


        /// <summary>
        /// Проверка на задание размера экрана
        /// </summary>
        /// <param name="width">фактическая ширина экрана</param>
        /// <param name="height">фактическая высота экрана</param>
        public static void CheckSizeScreen(int width, int height)
        {
            if (width <= 0 || height <= 0 || width > MaxW || height > MaxH)
            {
                throw new ArgumentOutOfRangeException();   //выбросить исключение

            }


        }

        /// <summary>
        /// Метод завершение игры
        /// </summary>
        public static void Finish()
        {
            Console.WriteLine("The End");
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60,
                FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }




    }
}
