using System;
namespace _02_IWasToldThereWouldBeNoMath
{
    public class Box
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Area { get; set; }
        public int Len { set; get; }

        public Box(string str)
        {
            string[] lens = str.Split('x');
            X = int.Parse(lens[0]);
            Y = int.Parse(lens[1]);
            Z = int.Parse(lens[2]);


            if (X > Y)
            {
                int t = X;
                X = Y;
                Y = t;
            }
            if (Y > Z)
            {
                int t = Y;
                Y = Z;
                Z = t;
            }
            if (X > Y)
            {
                int t = X;
                X = Y;
                Y = t;
            }
            Area = 3 * X * Y + 2 * X * Z + 2 * Y * Z;
            Len = 2 * (X + Y) + X * Y * Z;
        }
    }
}
