using System;
using System.Drawing;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3

namespace AsteroidsGame
{
    /// <summary>
    /// класс Planet, наследуемый от BaseObject
    /// </summary>
    class Planet : BaseObject
    {
        Image ImagePlanet = Image.FromFile(@"Planet.png");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        /// <summary>
        /// рисует обьект 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(ImagePlanet, Pos.X, Pos.Y);

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
    }
}
