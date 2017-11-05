using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
namespace AstroGame
{
    class Game
    {

        static BaseObject[] objs; // массив хранит звезды и планеты
        static Asteroid[] ast;  // массив хранит астеройды
        static BaseObject graund;
        static Galaxy galaxy;
        static Ship ship;
        static public Random random = new Random();
        static Timer timer = new Timer();
        static BufferedGraphicsContext context; // объект контекст
        static public BufferedGraphics buffer;  // объект буфер
        static public int Width { get; set; }
        static public int Height { get; set; }

        static Game()
        {

        }

        /// <summary>
        /// метод инициализирует игровое поле
        /// </summary>
        /// <param name="form"></param>
        static public void Init(Form form)
        {
            Graphics g; // объект типа графикс
            context = BufferedGraphicsManager.Current; //предоставляет доступ к главному буферу графического контекста
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        /// <summary>
        /// Обработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        ///  загружает данные для игры
        /// </summary>
        static public void Load()
        {
            objs = new BaseObject[25];
            ast = new Asteroid[5];

            for (int i = 0; i < 23; i++)
            {
                objs[i] = new Star(new Point(random.Next(800), random.Next(350)), new Point(-random.Next(5, 15), 0), new Size(random.Next(5, 30), random.Next(5, 30)));
            }

            for (int i = 23; i < 25; i++)
            {
                objs[i] = new Planet(new Point(random.Next(1000), random.Next(350)), new Point(-random.Next(3, 17), 0), new Size(random.Next(70, 80), random.Next(70, 80)));
            }

            galaxy = new Galaxy(new Point(-180, 10), new Point(0, 0), new Size(100, 100));
            graund = new Graund(new Point(0, 440), new Point(-3, 0), new Size(500, 200));

            for (int i = 0; i < 5; i++)
            {
                ast[i] = new Asteroid(new Point(random.Next(800), random.Next(400)), new Point(-random.Next(5, 15), 0), new Size(random.Next(25, 30), random.Next(25, 30)));
            }
            ship = new Ship(new Point(10, 200), new Point(5, 10), new Size(50, 50));
        }

        /// <summary>
        /// метод отрисовки происходящего на экране
        /// </summary>
        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            galaxy.Draw();
            foreach (BaseObject obj in objs)
            {
                obj.Draw();
            }
            foreach (Asteroid aster in ast)
            {
                if (aster != null) aster.Draw();
            }
            graund.Draw();
            ship.Draw();
            buffer.Render();
        }

        /// <summary>
        /// метод обновляющий координаты объекта
        /// </summary>
        static public void Update()
        {
            foreach (BaseObject obj in objs) obj.Update();
            graund.Update();
            galaxy.Update();
            for (int i = 0; i < ast.Length; i++)
            {
                ast[i].Update();
            }
        }
    }
}
