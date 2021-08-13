using System.IO;
using System;

namespace _01_NotQuiteLisp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"Resources/input.txt");

            Console.WriteLine("01-BotQuiteLisp\n--------------------------- Part 1");
            int floor = 0;
            foreach (var c in input)
            {
                if (c == '(') floor++;
                if (c == ')') floor--;
            }
            Console.WriteLine(floor);

            Console.WriteLine("--------------------------- Part 2");
            int ptr = 1;
            floor = 0;
            while (floor != -1)
            {
                char ch = input[ptr - 1];
                if (ch == '(') floor++;
                if (ch == ')') floor--;
                if (floor != -1)
                    ptr++;
            }
            Console.WriteLine(ptr);
        }
    }
}
