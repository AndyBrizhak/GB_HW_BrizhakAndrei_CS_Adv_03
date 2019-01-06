using System;
using System.Windows.Forms;
//Брижак Андрей Домашнее задание по курсу C# уровень 2 урок 3

namespace AsteroidsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            //  Game.Init(form);
            //  form.Show();
            //  Game.Draw();
            //  Application.Run(form);

            // Form form = new Form
            // {
            //     Width = Screen.PrimaryScreen.Bounds.Width,
            //     Height = Screen.PrimaryScreen.Bounds.Height
            // };
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}}
