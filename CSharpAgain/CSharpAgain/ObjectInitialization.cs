using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    enum PointColor
    {
        LightBlue, BloodRed, Gold
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            Color = PointColor.Gold;
        }

        public Point(PointColor ptColor)
        {
            Color = ptColor;
        }

        public Point() : this(PointColor.BloodRed) { }

        public void DisplayStats()
        {
            Console.WriteLine("[{0}, {1}]", X, Y);
            Console.WriteLine("Point is {0}", Color);
        }
    }

    class Rectangle
    {
        Point topLeft;
        Point bottomRight;

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public void DisplayStats()
        {
            Console.WriteLine("[TopLeft: {0}, {1}, {2} BottomRight: {3}, {4}, {5}]",
            TopLeft.X, TopLeft.Y, TopLeft.Color,
            BottomRight.X, BottomRight.Y, BottomRight.Color);
        }
    }


    class ObjectInitialization
    {
        static void Main(string[] args)
        {
            Point p1 = new Point { X = 10, Y = 20 };
            p1.DisplayStats();

            Point p2 = new Point(PointColor.LightBlue) { X = 1, Y = 2 };
            p2.DisplayStats();

            Point p3 = new Point();
            p3.DisplayStats();

            Point p4 = new Point(PointColor.Gold);
            p4.DisplayStats();

            Point p5 = new Point(5, 10);
            p5.DisplayStats();

            Console.WriteLine();

            Rectangle rect = new Rectangle
            {
                TopLeft = new Point { X = 50, Y = 70 },
                BottomRight = new Point(PointColor.LightBlue) { X = 55, Y = 75 }
            };
            rect.DisplayStats();

            Console.ReadLine();
        }
    }
}
