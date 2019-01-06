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
        /// Событие уничтожение Bullet
        /// </summary>
        public static event Message MessageBulletDestroyed;  

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }


        /// <summary>
        /// при столкновении перенести положение снаряда на левый кран экрана
        /// </summary>
        public void Crash()
        {
            Pos.X = 0;
        }
    }
}

