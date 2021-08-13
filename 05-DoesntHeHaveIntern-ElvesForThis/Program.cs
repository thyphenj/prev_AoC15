using System;
using System.IO;

namespace _05_DoesntHeHaveIntern_ElvesForThis
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            Console.WriteLine("05-Doesn't We Have...\n-------------------------------- Part 1");
            int count = 0;

            foreach (var s in input)
            {
                if (NiceOne(s))
                    count++;
            }
            Console.WriteLine(count);

            Console.WriteLine("-------------------------------- Part 2");
            count = 0;
            foreach (var s in input)
            {
                if (NiceTwo(s))
                    count++;
            }
            Console.WriteLine(count);

        }
        static bool NiceOne(string s)
        {
            int vowels = 0;
            bool dble = false;
            bool abcd = false;

            for (int i = 0; i < s.Length; i++)
            {
                if ("aeiou".Contains(s[i]))
                    vowels++;

                if (i < s.Length - 1)
                {
                    if (s[i] == s[i + 1])
                        dble = true;
                    string ss = s.Substring(i, 2);
                    if (ss == "ab" || ss == "cd" || ss == "pq" || ss == "xy")
                        abcd = true;
                }
            }
            return vowels > 2 && dble && !abcd;
        }
        static bool NiceTwo(string s)
        {
            bool rep = false;
            bool trp = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 2)
                {
                    if (s[i] == s[i + 2])
                        trp = true;
                }
                if (i < s.Length - 3)
                {
                    string dbl = s.Substring(i, 2);
                    for (int j = i + 2; j < s.Length - 1; j++)
                        if (dbl == s.Substring(j, 2))
                            rep = true;

                }
            }
            return rep && trp;
        }
    }
}
