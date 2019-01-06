using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsGame
{
    class Healthpack : Asteroid
    {
        public Healthpack(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = -10;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.GreenYellow, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
