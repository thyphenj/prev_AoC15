using System.IO;

namespace _25_LetItSnow
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("input.txt").Split("row ")[1].Split("column");


            int row = int.Parse(input[0].Trim(new char[] { ' ', '.', ',' }));
            int col = int.Parse(input[1].Trim(new char[] { ' ', '.', ',' }));
            int s = row + col - 2;
            long target = (s + 1) * s / 2 + col;

            System.Console.WriteLine($"({row},{col}) {target}");

            long val = 20151125;
            long multi = 252533;
            long divor = 33554393;

            long i = 1;
            do
            {
                val = (val * multi) % divor;
                i++;
                if ( i == target)
                    System.Console.Write("**********");
                if (i > target-10)
                    System.Console.WriteLine($"{i,10} {val,10}");
            } while (i < target + 10);
        }
    }
}
