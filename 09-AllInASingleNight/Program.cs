using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _09_AllInASingleNight
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
                    "London to Dublin = 464",
                    "London to Belfast = 518",
                    "Dublin to Belfast = 141" };
            }

            List<Trip> trips = new List<Trip>();
            HashSet<string> locations = new HashSet<string>();

            foreach (var s in input)
            {
                Trip t = new Trip(s);
                trips.Add(t);
                trips.Add(t.OtherWay());
                locations.Add(t.From);
                locations.Add(t.To);
            }

            List<int> used = new List<int>();
            int minDistance = 1000;
            int maxDistance = 0;
            for (int a = 0; a < 8; a++)
            {
                used.Add(a);
                for (int b = 0; b < 8; b++)
                {
                    if (!used.Contains(b))
                    {
                        used.Add(b);
                        for (int c = 0; c < 8; c++)
                        {
                            if (!used.Contains(c))
                            {
                                used.Add(c);
                                for (int d = 0; d < 8; d++)
                                {
                                    if (!used.Contains(d))
                                    {
                                        used.Add(d);
                                        for (int e = 0; e < 8; e++)
                                        {
                                            if (!used.Contains(e))
                                            {
                                                used.Add(e);
                                                for (int f = 0; f < 8; f++)
                                                {
                                                    if (!used.Contains(f))
                                                    {
                                                        used.Add(f);
                                                        for (int g = 0; g < 8; g++)
                                                        {
                                                            if (!used.Contains(g))
                                                            {
                                                                used.Add(g);
                                                                for (int h = 0; h < 8; h++)
                                                                {
                                                                    if (!used.Contains(h))
                                                                    {
                                                                        used.Add(h);
                                                                        int tripDistance = 0;
                                                                        for (int i = 0; i < 7; i++)
                                                                        {
                                                                            string from = locations.ToList()[used[i]];
                                                                            string to = locations.ToList()[used[i + 1]];
                                                                            Trip shrt = trips.Where(a => a.From == from && a.To == to).FirstOrDefault();
                                                                            tripDistance += shrt.Distance;
                                                                            //Console.Write($"{locations.ToList()[used[i]]} - ");
                                                                        }
                                                                        //Console.WriteLine($"{locations.ToList()[used[7]]} {tripDistance}");
                                                                        if (tripDistance < minDistance)
                                                                            minDistance = tripDistance;
                                                                        if (tripDistance > maxDistance)
                                                                            maxDistance = tripDistance;
                                                                        used.RemoveAt(7);
                                                                    }
                                                                }
                                                                used.RemoveAt(6);
                                                            }
                                                        }
                                                        used.RemoveAt(5);
                                                    }
                                                }
                                                used.RemoveAt(4);
                                            }
                                        }
                                        used.RemoveAt(3);
                                    }
                                }
                                used.RemoveAt(2);
                            }
                        }
                        used.RemoveAt(1);
                    }
                }
                used.RemoveAt(0);
            }

            Console.WriteLine("09-AllInASingleNight\n-------------------------------- Part 1");
            Console.WriteLine(minDistance);

            Console.WriteLine("\n-------------------------------- Part 2");
            Console.WriteLine(maxDistance);

        }
    }
}

