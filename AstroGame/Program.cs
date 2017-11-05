using System;
using System.Windows.Forms;
using System.Drawing;

namespace AstroGame
{
    // 1.  Добавить свои объекты в  иерархию объектов, чтобы получился красивый задний фон, похожий на полёт в звёздном пространстве.
    // 2.  * Заменить кружочки картинками, используя метод DrawImage.
    // 3.  **Разработать собственный класс заставка SplashScreen, аналогичный классу Game, в котором создайте собственную иерархию объектов и задайте их движение. Предусмотреть кнопки – Начало игры, Рекорды, Выход.Добавьте на заставку имя автора.


    class Program
    {
        static public bool flag = true; // переменная проверяет не была ли нажата кнопка Выход

        static void Main(string[] args)
        {
            Menu();
            if (flag) StartGame();
        }

        /// <summary>
        /// метод вызывающий меню
        /// </summary>
        private static void Menu()
        {
            Application.EnableVisualStyles();
            Application.Run(new SplashScreen());
        }

        /// <summary>
        ///  метод начинающий игру
        /// </summary>
        private static void StartGame()
        {
            Form form = new Form();
            form.Width = 1000;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
