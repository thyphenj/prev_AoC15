using System;
using System.Diagnostics;

namespace _10_ElvesLookElvesSay
{
    class Program
    {
        static void Main()
        {
            string seed = "1113222113";
            Part1(seed);
            Console.WriteLine("-----------------");
            Part2(seed);
        }
        static void Part2(string seed)
        {
            Stopwatch sw;
            Console.WriteLine(seed);
            Console.WriteLine();

            string inp = seed;
            for (int i = 1; i <= 50; i++)
            {
                sw = new Stopwatch();
                sw.Start();

                string outp = "";
                string shortstr = "";
                int j = 0;
                while (j < inp.Length - 3)
                {
                    char ch = inp[j];
                    if (ch != inp[++j])
                    {
                        shortstr += "1" + ch;
                    }
                    else if (ch != inp[++j])
                    {
                        shortstr += "2" + ch;
                    }
                    else if (ch != inp[++j])
                    {
                        shortstr += "3" + ch;
                    }
                    if (shortstr.Length > 250)
                    {
                        outp += shortstr;
                        shortstr = "";
                    }
                }
                outp += shortstr;
                inp = outp + "2113";

                sw.Stop();
                Console.WriteLine($"{i,2} - {inp.Length,10} ({inp.Substring(inp.Length - 10)}) {sw.Elapsed}");
            }

        }
        static void Part1(string seed)
        {
            Stopwatch sw;

            string inp = seed;
            for (int i = 1; i <= 40; i++)
            {
                sw = new Stopwatch();
                sw.Start();

                string outp = "";

                char ch = inp[0];
                int chCnt = 1;
                int j = 0;
                while (++j < inp.Length)
                {
                    char nxtch = inp[j];
                    if (nxtch != ch)
                    {
                        outp += $"{chCnt}{ch}";
                        ch = nxtch;
                        chCnt = 1;
                    }
                    else
                    {
                        chCnt++;
                    }

                }
                inp = outp + $"{chCnt}{ch}";

                sw.Stop();
                Console.WriteLine($"{i,2} - {inp.Length,10} ({inp.Substring(inp.Length - 10)}) {sw.Elapsed}");
            }
        }
    }
}
