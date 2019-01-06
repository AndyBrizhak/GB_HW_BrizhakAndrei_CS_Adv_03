using System;
using System.Drawing;

namespace AsteroidsGame
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
