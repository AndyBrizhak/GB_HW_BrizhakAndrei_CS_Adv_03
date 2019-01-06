using System;
using System.Drawing;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3


namespace AsteroidsGame
{
    /// <summary>
    /// класс Star, наследуемый от BaseObject
    /// </summary>
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        /// <summary>
        /// рисует обьект Star
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        /// <summary>
        /// рассчитывает местоположение обьекта Star
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
