using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _07_SomeAssemblyReauired
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            if (test)
            {
                input = new string[] {
                    "123 -> x",
                    "456 -> y",
                    "x AND y -> d",
                    "x OR y -> e",
                    "x LSHIFT 2 -> f",
                    "y RSHIFT 2 -> g",
                    "NOT x -> h",
                    "NOT y -> i" };
            }

            Console.WriteLine("07-SomeAssemblyRequired\n-------------------------------- Part 1");
            List<Gate> gates = new List<Gate>();
            string part1;
            {
                Gate a = new Gate();

                foreach (var i in input)
                {
                    Gate gate = new Gate(i);
                    gates.Add(gate);
                    if (gate.Name == "a")
                        a = gate;
                }
                gates.Sort();

                while (!a.result.HasValue)
                {
                    foreach (var gate in gates)
                    {
                        gate.TryResults(gates);
                    }
                }
                Console.WriteLine(a.result);
                part1 = a.result.ToString(); ;
            }

            Console.WriteLine("\n-------------------------------- Part 2");
            {
                Gate a = new Gate();
                gates = new List<Gate>();

                foreach (var i in input)
                {
                    Gate gate = new Gate(i);
                    if (gate.Name == "b")
                        gate = new Gate($"{part1} -> b");
                    gates.Add(gate);
                    if (gate.Name == "a")
                        a = gate;

                }
                gates.Sort();

                while (!a.result.HasValue)
                {
                    foreach (var gate in gates)
                    {
                        gate.TryResults(gates);
                    }
                }
                Console.WriteLine(a.result);
            }
        }
    }
}
