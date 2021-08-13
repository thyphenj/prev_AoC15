using System.IO;
using System;
using System.Collections.Generic;


namespace _03_PerfectlySphericalHousesInAVacuum
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = File.ReadAllText(@"Resources/input.txt");

            Console.WriteLine("03-PerfectlySphericalHousesInAVacuum\n--------------------------- Part 1");

            HashSet<string> houses = new HashSet<string>();
            int x = 0, y = 0;

            houses.Add($"{x},{y}");
            foreach (var ch in input)
            {
                switch (ch)
                {
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '>':
                        x++;
                        break;
                    case '<':
                        x--;
                        break;
                }
                houses.Add($"{x},{y}");
            }
            Console.WriteLine(houses.Count);

            Console.WriteLine("\n--------------------------- Part 2");
            houses = new HashSet<string>();
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;

            bool robo = false;
            houses.Add($"{x1},{y1}");
            foreach (var ch in input)
            {
                switch (ch)
                {
                    case '^':
                        if (robo) y1++; else y2++;
                        break;
                    case 'v':
                        if (robo) y1--; else y2--;
                        break;
                    case '>':
                        if (robo) x1++; else x2++;
                        break;
                    case '<':
                        if (robo) x1--; else x2--;
                        break;
                }
                string s = robo ? $"{x1},{y1}" : $"{x2},{y2}";
                houses.Add(s);

                robo = !robo;
            }
            Console.WriteLine(houses.Count);


        }
    }
}
