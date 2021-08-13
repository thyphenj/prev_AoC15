using System.IO;
using System;

namespace _02_IWasToldThereWouldBeNoMath
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            Console.WriteLine("02-IWasToldThereWouldBeNoMath\n--------------------------- Part 1 & 2");
            int area = 0;
            int len = 0;
            foreach (var s in input)
            {
                Box b = new Box(s);
                area += b.Area;
                len += b.Len;
            }
            Console.WriteLine($"area = {area}    length = {len}");

        }
    }
}
