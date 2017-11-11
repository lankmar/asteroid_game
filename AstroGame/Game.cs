using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
namespace AstroGame
{
    class Game
    {
        static BaseObject[] objs; // массив хранит звезды и планеты
        static List<Asteroid> aster = new List<Asteroid>();
        static Graund graund;
        static List<Repairs> repairs = new List<Repairs>();
        static Galaxy galaxy;
        static Ship ship;
        static public int shipEnergy;
        static int shootCount = 0; // количество выстрелов( для счета)
        static int level = 1;
        static int score = 0;
        static public Random random = new Random();
        static public System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        static BufferedGraphicsContext context; // объект контекст
        static public BufferedGraphics buffer;  // объект буфер
        static List<Bullet> bullets = new List<Bullet>();
        static public int Width { get; set; }
        static public int Height { get; set; }
        static public Log myLogMessage = new Log();

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
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;

        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bullets.Add(new Bullet(new Point(ship.Rect.X + 100, ship.Rect.Y + 20), new Point(4, 0), new Size(4, 1)));
                shootCount++;
                myLogMessage.PrintMessage(new LogMessage(Bullet.MessageShot)); 
            }// если нажали клавишу ControlKey, то создается пулька перед кораблем
            if (e.KeyCode == Keys.Up) ship.Up();
            //если клавиша вверх - событие ship.Up
            if (e.KeyCode == Keys.Down) ship.Down();
            // если клавиша вниз - ship.Down
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
            Level();
        }

        /// <summary>
        /// проверка на начало нового уровня
        /// </summary>
        private static void Level()
        {
            bool flag = true;
            foreach (var item in aster)
            {
                if (item == null) flag = false;
                else
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                level++;
                if (level == 3)
                {
                    Finish();
                    return;
                }
                flag = true;
                buffer.Graphics.DrawString($"Level {level}", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
                buffer.Render();
                Load();
                bullets.Clear();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        ///  загружает данные для игры
        /// </summary>
        static public void Load()
        {
            objs = new BaseObject[25];
            for (int i = 0; i < 23; i++)
            {
                objs[i] = new Star(new Point(random.Next(800), random.Next(350)), new Point(-random.Next(5, 15), 0), new Size(random.Next(5, 30), random.Next(5, 30)));
            }

            for (int i = 23; i < 25; i++)
            {
                objs[i] = new Planet(new Point(random.Next(1000), random.Next(350)), new Point(-random.Next(3, 17), 0), new Size(random.Next(70, 80), random.Next(70, 80)));
            }

            galaxy = new Galaxy(new Point(-180, 10), new Point(0, 0), new Size(100, 100));
            myLogMessage.PrintMessage(new LogMessage(galaxy.Message));
            graund = new Graund(new Point(0, 440), new Point(-3, 0), new Size(500, 200));
            myLogMessage.PrintMessage(new LogMessage(graund.Message));

            for (int i = 0; i < 5+level*2; i++)
            {
                aster.Add(new Asteroid(new Point(random.Next(1000, 1500), random.Next(400)), new Point(-(random.Next(9, 12) + level), 0), new Size(random.Next(25, 30), random.Next(25, 30))));
                myLogMessage.PrintMessage(new LogMessage(Asteroid.MessageCreate));
            }
            ship = new Ship(new Point(10, 200), new Point(5, 10), new Size(50, 50));
            myLogMessage.PrintMessage(new LogMessage(ship.Message));
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
             foreach (Asteroid ast in aster)
            {
                if (ast != null) ast.Draw();
            }
            graund.Draw();
            foreach (Bullet b in bullets) b.Draw();
            ship.Draw();
            buffer.Graphics.DrawString("String: " + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            if (random.Next(500) == 1 && repairs.Count <= 2)
            {
                repairs.Add(new Repairs(new Point(1000, random.Next(400)), new Point(-random.Next(5, 15), 0), new Size(20, 20)));
            }
            foreach (var item in repairs) item.Draw(); // прорисовка ремонта корабля
            buffer.Render();
        }

        /// <summary>
        /// метод обновляющий координаты объекта
        /// </summary>
        static public void Update()
        {
            foreach (BaseObject obj in objs) obj.Update();
            graund.Update();
            if (bullets != null)
            {
                foreach (Bullet b in bullets) b.Update();
            }
            for (int i = 0; i < aster.Count; i++)
            {
                if (aster[i] != null)
                {
                    aster[i].Update();
                    for (int j = 0; j < bullets.Count; j++)
                        if (aster[i] != null && bullets[j].Collision(aster[i]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            aster[i] = null;
                            bullets.RemoveAt(j);
                            myLogMessage.PrintMessage(new LogMessage(Asteroid.MessageDestroy));
                            score += 50 - shootCount; 
                            continue;
                        }
                    if (aster[i] != null && ship.Collision(aster[i]))
                    {
                        ship.EnergyLow(random.Next(1, 10));
                        myLogMessage.PrintMessage(new LogMessage(Ship.MessageDamege));
                        System.Media.SystemSounds.Asterisk.Play();
                        if (ship.Energy <= 0)
                        {
                            ship.Die();
                            score = 0;
                        }
                    }
                }
            }


            for (int i = 0; i < repairs.Count; i++)
            {
                if (repairs[i] != null)
                {
                    repairs[i].Update();
                    for (int j = 0; j < repairs.Count; j++)
                        if (repairs[j] != null && ship.Collision(repairs[j]))
                        {
                            ship.EnergyUp(repairs[j].Power);
                            repairs.RemoveAt(i);
                            if(ship.Energy >=100) ship.Energy = 100;
                            myLogMessage.PrintMessage(Ship.MessageRepaire);
                            continue;
                        }
                }
            }
        }
        /// <summary>
        /// Метод финиш
        /// </summary>
        static public void Finish()
        {
            timer.Stop();
            buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 200, 100);
            if (score != 0) buffer.Graphics.DrawString($"Win! score: {score}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 200, 300);
            myLogMessage.Start();
            buffer.Render();
        }
    }
}
