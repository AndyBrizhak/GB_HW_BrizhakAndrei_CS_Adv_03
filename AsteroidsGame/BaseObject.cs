using System;
using System.Drawing;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3

namespace AsteroidsGame
{
    /// <summary>
    /// Абстрактный класс BaseObject 
    /// </summary>
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        //Image Planet = Image.FromFile(@"Planet.png");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos">Позиция обьекта на экране</param>
        /// <param name="dir">Направление обьекта</param>
        /// <param name="size">Размер обьекта</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public delegate void Message();

        /// <summary>
        /// рисует  обьекты
        /// </summary>
        public abstract void Draw();


        //   ДЗ Задача 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в
        //    наследниках.
        /// <summary>
        /// расчитывает новое местоположение обьектов
        /// </summary>
        public abstract void Update();

        // public abstract void Crash();

        /// <summary>
        /// Реализация интрефейса ICollision
        /// </summary>
        /// <param name="o">логическое да/нет</param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
