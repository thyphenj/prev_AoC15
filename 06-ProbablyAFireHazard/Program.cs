using System.Collections.Generic;
using System.IO;

namespace _06_ProbablyAFireHazard
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            List<Quad> instructions = new List<Quad>();

            foreach (var s in input)
                instructions.Add(new Quad(s));

            System.Console.WriteLine("06-ProbablyAFireHazard\n-------------------------------- Part 1");

            bool[,] grid = new bool[1000, 1000];
            foreach (var ins in instructions)
            {
                for (int x = ins.Lo.X; x <= ins.Hi.X; x++)
                    for (int y = ins.Lo.Y; y <= ins.Hi.Y; y++)
                        grid[x, y] = ins.OnOff(grid[x, y]);
            }
            int count = 0;
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (grid[x, y])
                        count++;
                }
            }
            System.Console.WriteLine(count);

            System.Console.WriteLine("\n-------------------------------- Part 2");

            int[,] grid2 = new int[1000, 1000];
            foreach (var ins in instructions)
            {
                for (int x = ins.Lo.X; x <= ins.Hi.X; x++)
                    for (int y = ins.Lo.Y; y <= ins.Hi.Y; y++)
                    {
                        grid2[x, y] += ins.Delta();
                        if (grid2[x, y] < 0)
                            grid2[x, y] = 0;
                    }
            }

            long count2 = 0;
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    count2 += grid2[x, y];
                }
            }
            System.Console.WriteLine(count2);
        }
    }
}
