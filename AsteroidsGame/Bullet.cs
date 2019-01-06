using System;
using System.Drawing;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3

namespace AsteroidsGame
{
    /// <summary>
    /// класс Bullet, наследуемый от BaseObject
    /// </summary>
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Событие (делегат) уничтожение Bullet
        /// </summary>
        public static event Message MessageBulletDestroyed;  

        /// <summary>
        /// Прорисовка пули
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Движение пули
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }


        /// <summary>
        /// Разрушение пули
        /// </summary>
        public void MessageDestroyed()    
        {
            MessageBulletDestroyed?.Invoke(); // Когда пуля разрушается вызываем это событие
           // Console.WriteLine("Bullet Destroyed!");  //выводим сообщение в консоль
        }

        /// <summary>
        /// при столкновении перенести положение снаряда на левый кран экрана
        /// </summary>
        public void Crash()
        {
            Pos.X = 0;
        }

        /// <summary>
        /// Вывод сообщения в консоль о разрушении пули
        /// </summary>
        public static void ShowMessageBulletDestroyed()  
        {
            Console.WriteLine("Bullet destoeyd");
        }
    }
}

