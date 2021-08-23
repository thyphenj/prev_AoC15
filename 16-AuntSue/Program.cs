using System;
using System.Collections.Generic;
using System.IO;

namespace _16_AuntSue
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> auntSue = new Dictionary<string, int>()
                { { "children", 1 }
                , { "cats", 7 }
                , { "samoyeds", 2 }
                , { "pomeranians", 3 }
                , { "akitas", 0 }
                , { "vizslas", 0 }
                , { "goldfish", 5 }
                , { "trees", 3 }
                , { "cars", 2 }
                , { "perfumes", 1}
            };

            string[] input = File.ReadAllLines("input.txt");
            foreach (string line in input)
            {
                int colon = line.IndexOf(':');
                string[] subline = line.Substring(colon + 2).Split(", ");

                bool validPartOne = true;
                bool validPartTwo = true;
                foreach (string str in subline)
                {
                    string[] atoms = str.Split(": ");
                    string key = atoms[0];
                    int val = int.Parse(atoms[1]);

                    if (auntSue.GetValueOrDefault(key) != val)
                        validPartOne = false;

                    if (key == "cats" || key == "trees")
                    {
                        if (auntSue.GetValueOrDefault(key) >= val)
                            validPartTwo = false;
                    }
                    else if (key == "pomeranians" || key == "goldfish")
                    {
                        if (auntSue.GetValueOrDefault(key) <= val)
                            validPartTwo = false;
                    }
                    else if (auntSue.GetValueOrDefault(key) != val)
                        validPartTwo = false;
                }
                if (validPartOne)
                {
                    Console.WriteLine($"Part 1 - {line}");
                }
                if (validPartTwo)
                {
                    Console.WriteLine($"Part 2 - {line}");
                }
            }
        }
    }
}
