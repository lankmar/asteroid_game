using System;
using System.Windows.Forms;
using System.Drawing;

namespace AstroGame
{
    /// <summary>
    /// Интерфейс для обработки столкновений
    /// </summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    abstract class BaseObject : ICollision
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
            get { return pos.X; } // для обработки ошибок открыт доступ, потом убрать
            set { pos.X = value; } // { if (value > 0) pos.X = value; }
        }
        public int PosY
        {
            set { if (value > 0) pos.X = value; }
        }

        /// <summary>
        //    абстрактный клас, без тела, должен быть реализовон в потомке 
        //    </summary>
        public abstract void Draw(); //

        /// <summary>
        /// виртуальный класc для обновления позиции любого объекта
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

        /// <summary>
        /// метод обнаружения пересечения с объектом
        /// </summary>
        /// <param name="o"> переданный в метод объект</param>
        /// <returns></returns>
        public bool Collision(ICollision o)
        {
            if (o.Rect.IntersectsWith(this.Rect)) return true; else return false;
        }

        public Rectangle Rect
        {
            get { return new Rectangle(pos, size); }
        }
    }

    /// <summary>
    /// класс звезда, рандамно выбирает какую из двух картинок использовать
    /// </summary>
    class Star : BaseObject
    {
        Image img; // = Image.FromFile(Application.StartupPath + "../Star2.png");
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            bool aster = Convert.ToBoolean(rnd.Next(0, 2));
            img = Image.FromFile(Application.StartupPath + ((aster == true) ? "../Star2.png" : "../star3.png"));
        }
        public override void Draw()
        {
            //  Game.buffer.Graphics.DrawRectangle (Pens.White, pos.X, pos.Y, size.Width, size.Height);
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
    /// класс астероид
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
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 2000, 150);
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
    ///класс пуля 
    /// </summary>
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.OrangeRed, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X + 10;
        }
        public void ChangePosition()
        {
            pos.X = 1;
            pos.Y = rnd.Next(350);
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
            // обработка ошибки по параметру положения коробля
            if (PosX < 10)
            {
                pos.X= 10;
                throw new MyException();
            }
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 100, 50);
        }
        public override void Update()
        {
        }

        public void Up()
        {
            if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }

        public void Down()
        {
            if (pos.Y < Game.Width) pos.Y = pos.Y + dir.Y;
        }
     }
}

