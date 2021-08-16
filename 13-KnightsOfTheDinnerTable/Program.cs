using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent13
{
    class Program
    {
        public static void Main()
        {
            string avail = "ABCDEFGM";
            string[] strs = File.ReadAllLines("input.txt");

            //string avail = "ABCD";
            //string[] strs = {
            //    "Alice would gain 54 happiness units by sitting next to Bob.",
            //    "Alice would lose 79 happiness units by sitting next to Carol.",
            //    "Alice would lose 2 happiness units by sitting next to David.",
            //    "Bob would gain 83 happiness units by sitting next to Alice.",
            //    "Bob would lose 7 happiness units by sitting next to Carol.",
            //    "Bob would lose 63 happiness units by sitting next to David.",
            //    "Carol would lose 62 happiness units by sitting next to Alice.",
            //    "Carol would gain 60 happiness units by sitting next to Bob.",
            //    "Carol would gain 55 happiness units by sitting next to David.",
            //    "David would gain 46 happiness units by sitting next to Alice.",
            //    "David would lose 7 happiness units by sitting next to Bob.",
            //    "David would gain 41 happiness units by sitting next to Carol."
            //        };

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string str in strs)
            {
                string[] flds = str.Split(' ');

                int v = int.Parse((flds[2] == "lose" ? "-" : "+") + flds[3]);

                //  string k = flds[0].Substring(0, 1) + flds[10].Substring(0, 1);
                string k = flds[0][0].ToString() + flds[10][0].ToString();
                if (dict.ContainsKey(k))
                    dict[k] += v;
                else
                    dict.Add(k, v);

                k = flds[10][0].ToString() + flds[0][0].ToString();
                if (dict.ContainsKey(k))
                    dict[k] += v;
                else
                    dict.Add(k, v);
            }

            Console.WriteLine("part 1-----------------------\n");
            {
                int mx = 0;
                string mxstr = "";

                foreach (List<char> perm in Permutate(avail.ToCharArray().ToList(), avail.Length))
                {
                    string comb = new string(perm.ToArray());
                    comb += comb[0];

                    int sum = 0;
                    for (int i = 0; i < avail.Length; i++)
                    {
                        string op = comb.Substring(i, 2);
                        //Console.Write(op + " " + dict[op] + " ");
                        sum += dict[comb.Substring(i, 2)];
                    }
                    //Console.WriteLine($"    = {sum}");
                    if (sum > mx)
                    {
                        mx = sum;
                        mxstr = comb;
                    }
                }
                Console.WriteLine($"{mxstr} {mx}");
            }
            Console.WriteLine("part 2-----------------------\n");
            {
                foreach (char ch in avail)
                {
                    dict.Add(ch + "T", 0);
                    dict.Add("T" + ch, 0);
                }
                avail += 'T';

                int mx = 0;
                string mxstr = "";
                foreach (List<char> perm in Permutate(avail.ToCharArray().ToList(), avail.Length))
                {
                    string comb = new string(perm.ToArray());
                    comb += comb[0];

                    int sum = 0;
                    for (int i = 0; i < avail.Length; i++)
                    {
                        string op = comb.Substring(i, 2);
                        Console.Write(op + " " + dict[op] + " ");
                        sum += dict[comb.Substring(i, 2)];
                    }
                    Console.WriteLine($"    = {sum}");
                    if (sum > mx)
                    {
                        mx = sum;
                        mxstr = comb;
                    }
                }
                Console.WriteLine($"{mxstr} {mx}");
            }
        }
        /// <summary>
        ///  --------------------------------------------------------------
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="count"></param>
        public static void RotateRight(IList sequence, int count)
        {
            object tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        public static IEnumerable<IList> Permutate(IList sequence, int count)
        {
            if (count == 1) yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                        yield return perm;
                    RotateRight(sequence, count);
                }
            }
        }
    }
}
