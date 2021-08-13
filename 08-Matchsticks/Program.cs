using System.IO;
using System;

namespace _08_Matchsticks
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            if (test)
            {

            }
            Console.WriteLine("08-Matchsticks\n-------------------------------- Part 1");
            {
                int totalch = 0;
                int realch = 0;
                foreach (var s in input)
                {
                    totalch += s.Length;
                    string w = s.Substring(1, s.Length - 2);

                    while (w.Contains('\\'))
                    {
                        int i = w.IndexOf('\\');
                        if (w[i + 1] == '\\' || w[i + 1] == '"')
                            w = w.Substring(0, i) + "A" + w.Substring(i + 2);

                        else if (w[i + 1] == 'x')
                            w = w.Substring(0, i) + "A" + w.Substring(i + 4);
                    }
                    realch += w.Length;
                }
                Console.WriteLine(totalch - realch);
            }
            Console.WriteLine("\n-------------------------------- Part 2");
            {
                int totalch = 0;
                int expch = 0;
                foreach (var s in input)
                {
                    totalch += s.Length;
                    string exp = "";
                    foreach (var ch in s)
                    {
                        if (ch == '\\' || ch == '"')
                            exp += '\\';
                        exp += ch;
                    }
                    exp = '"' + exp + '"';
                    expch += exp.Length;
                }
                Console.WriteLine(expch - totalch);
            }
        }
    }
}