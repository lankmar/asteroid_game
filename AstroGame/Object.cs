using System;
using System.Windows.Forms;
using System.Drawing;

namespace AstroGame
{
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        static protected Random rnd = new Random();

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public int PosX
        {
            set { if (value > 0) pos.X = value; }
        }
        public int PosY
        {
            set { if (value > 0) pos.X = value; }
        }

        /// <summary>
        /// виртуальный класс 
        /// </summary>
        public virtual void Draw() { }


        /// <summary>
        /// виртуальный клас для обновления позиции любого объекта
        /// </summary>
        public virtual void Update()
        {

            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0)
            {
                pos.X = Game.Width;
                pos.Y = rnd.Next(350);
            }
        }
    }

    /// <summary>
    /// класс звезда, рандамно выбирает какую из двух картинок использовать
    /// </summary>
    class Star : BaseObject
    {
        Image img;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) // конструктор 
        {
            bool aster = Convert.ToBoolean(rnd.Next(0, 2));
            img = Image.FromFile(Application.StartupPath + ((aster == true) ? "../Star2.png" : "../star3.png"));
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 20, 20);
        }
    }

    /// <summary>
    /// класс планеты
    /// </summary>
    class Planet : BaseObject
    {
        Image img = Image.FromFile(Application.StartupPath + "../planet.png");
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            //  Game.buffer.Graphics.DrawRectangle (Pens.White, pos.X, pos.Y, size.Width, size.Height);
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 50, 50);
        }
    }
    /// <summary>
    /// класс астеройд
    /// </summary>
    class Asteroid : BaseObject
    {
        public int Power { get; set; }  // автоматическое свойство
        Image img;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            bool aster = Convert.ToBoolean(rnd.Next(0, 2));
            img = Image.FromFile(Application.StartupPath + ((aster == true) ? "../aster1.png" : "../aster2.png"));
            Power = rnd.Next(5);
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 20, 20);
        }
        public void ChangePosition()
        {
            pos.X = 1000;
            pos.Y = rnd.Next(380);
        }
    }

    /// <summary>
    /// класс земля
    /// </summary>
    class Graund : BaseObject
    {
        Image img = Image.FromFile(Application.StartupPath + "../pluto.jpg");
        public Graund(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 4000, 150);
        }
        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < -1000)
            {
                pos.X = 0;
            }
        }
    }
    /// <summary>
    /// класс галактика
    /// </summary>
    class Galaxy : BaseObject
    {
        Image img = Image.FromFile(Application.StartupPath + "../home_galaxy.png");
        public Galaxy(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 1200, 450);
        }
        public override void Update()
        {
        }
    }

    /// <summary>
    /// класс корабль
    /// </summary>
    class Ship : BaseObject
    {
        Image img = Image.FromFile(Application.StartupPath + "../cruiser.png");
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 100, 50);
        }
        public override void Update()
        {
        }
    }
}
