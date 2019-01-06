using System;
using System.Drawing;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3

namespace AsteroidsGame
{
    /// <summary>
    /// класс SmallRedStar, наследуемый от BaseObject
    /// </summary>
    class SmallRedStar : BaseObject
    {
        public SmallRedStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        /// <summary>
        /// рисует обьект SmallRedStar
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Red, Pos.X, Pos.Y, Pos.X + Size.Width / 2, Pos.Y + Size.Height / 2);
            Game.Buffer.Graphics.DrawLine(Pens.Red, Pos.X + Size.Width / 2, Pos.Y, Pos.X, Pos.Y + Size.Height / 2);
        }

        /// <summary>
        /// рассчитывает местоположение обьекта SmallRedStar
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
