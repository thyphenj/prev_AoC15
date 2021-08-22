using System;
using System.IO;
using System.Collections.Generic;

namespace _14_ReindeerOlympics
{
    class MainClass
    {
        public static void Main()
        {
            int time = 2503;

            List<Deer> deers = ReadInput(time);

            Deer maxDeer = deers[0];
            foreach (Deer deer in deers)
            {
                if (deer.Dist > maxDeer.Dist)
                    maxDeer = deer;

                Console.WriteLine(deer);
            }
            Console.WriteLine("\n------- furthest -------\n");
            Console.WriteLine(maxDeer);

            for (int secs = 1; secs <= time; secs++)
            {
                Deer leader = null;
                double maxPosition = 0;
                foreach (Deer deer in deers)
                {
                    int position = deer.Position(secs);
                    if (position > maxPosition)
                    {
                        maxPosition = position;
                        leader = deer;
                    }
                }
                leader.AddPoint();
                Console.WriteLine($"{secs,5}   leader - {leader,10} - points - {leader.Points}");
            }

            Console.WriteLine();
            foreach (Deer deer in deers)
            {
                Console.WriteLine($"{deer,10} points={deer.Points,4}");
            }

        }

        public static List<Deer> ReadInput(int time)
        {
            string[] lines = File.ReadAllLines("input.txt");

            List<Deer> deers = new List<Deer>();
            foreach (string line in lines)
            {
                string[] atoms = line.Split(' ');

                int speed = int.Parse(atoms[3]);
                int flight = int.Parse(atoms[6]);
                int rest = int.Parse(atoms[13]);
                deers.Add(new Deer(atoms[0], speed, flight, rest, time));
            }
            return deers;
        }
    }
}
