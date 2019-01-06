using System;
using System.Drawing;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3

namespace AsteroidsGame
{
    /// <summary>
    /// класс Asteroid, наследуемый от BaseObject
    /// </summary>
    class Asteroid : BaseObject, ICloneable
    {
        /// <summary>
        /// Свойство , описыващее энергию
        /// </summary>
        public int Power { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        /// <summary>
        /// рисует обьект 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// рассчитывает местоположение обьекта 
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

        /// <summary>
        /// метод клонирует обьект со всеми его свойствами
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // Создаем копию 
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new
                Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            asteroid.Power = Power;
            return asteroid;
        }

        // <summary>
        /// при столкновении перенести положение снаряда на верхний край экрана
        /// </summary>
        public void Crash()
        {
            Pos.Y = 0;
        }
    }
}