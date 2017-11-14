using System;
using System.Windows.Forms;
using System.Drawing;

namespace AstroGame
{
    //1.	  Добавить космический корабль,  как описано в методичке.
    // 2. а)  Добавить в игру  “Астероиды” ведение журнала в консоль с помощью делегатов
    //б)* и в файл.
    //3. Добавить аптечки, которые добавляют энергии.
    //4. Добавить подсчет очков за cбитые астероиды.

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
