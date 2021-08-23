using System;
using System.IO;

namespace _17_NoSuchThingAsTooMuch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            foreach (string str in input)
                Console.Write($"  {str,2}");
            Console.WriteLine();
        }
    }
}
