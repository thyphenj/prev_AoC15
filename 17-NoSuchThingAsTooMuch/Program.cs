using System;
using System.IO;
using System.Collections.Generic;

namespace _17_NoSuchThingAsTooMuch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int[] containers = new int[input.Length];
            HashSet<uint> answers = new HashSet<uint>();

            for (int i = 0; i < input.Length; i++)
            {
                containers[i] = int.Parse(input[i]);
            }
            Array.Sort(containers);
            Array.Reverse(containers);

            foreach (int val in containers)
                Console.Write($"  {val,2}");
            Console.WriteLine();

            for (uint i = 1; i < 1048576; i++)
            {
                int sum = 0;
                for (int j = 0; j < containers.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                        sum += containers[j];

                    if (sum > 150)
                        break;
                }
                if (sum == 150)
                    answers.Add(i);
            }

            Console.WriteLine($"Part one - {answers.Count}");

            int count = 0;
            foreach (var s in answers)
            {
                int bitCount = 0;
                for (int j = 0; j < containers.Length; j++)
                {
                    if ((s & (1 << j)) != 0)
                        bitCount++;
                }
                if (bitCount == 4)
                    count++;

                //                Console.WriteLine($"{Convert.ToString(s, 2)} - {bitCount,2}");
            }

            Console.WriteLine($"Part two - {count}");
        }
    }
}
