using System;
using System.Drawing;

namespace AstroGame
{
    //вынесла корабль в отдельный класс, так как он очень большой
    /// <summary>
    /// класс корабль
    /// </summary>
    class Ship : BaseObject
    {
        int energy = 100;
        Image img = Properties.Resources.cruiser;
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public int Energy
        {
            get => energy;
            set => energy = value;
        }

        public void EnergyLow(int n)
        {
            energy -= n;
        }

        internal void EnergyUp(int n)
        {
            energy += n;
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

        public static event Message MessageDie;

        public void Die()
        {
            if (MessageDie != null) MessageDie();
        }
        public void Message(object o)
        {
            Console.WriteLine($"{DateTime.Now} Создан корабль, { o.GetType()} ");
        }

        internal static void MessageDamege(object o)
        {
            Console.WriteLine($"{DateTime.Now} Корабль получил повреждения,  {o.GetType()} ");
        }

        internal static void MessageRepaire(object o)
        {
            Console.WriteLine($"{DateTime.Now} Корабль отремонтирован, { o.GetType()} ");
        }
    }
}

