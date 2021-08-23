using System;
using System.IO;

namespace _18_LikeAGigForYourYard
{
    class Program
    {
        //private static string[] Curr;

        static void Main(string[] args)
        {
            string[] Curr = File.ReadAllLines("input.txt");
            string[] next = new string[102];

            //surround with dots
            for (int i = 1; i < 99; i++)
            {
                next[i + 1] = $".{Curr[i]}.";
            }
            next[0] = new string('.', 102);
            next[101] = new string('.', 102);

            // PART ONE - as is
            //next[1] = $".{Curr[0]}.";
            //next[100] = $".{Curr[99]}.";

            //PART TWO - hashes in corners!
            next[1] = ".#" + Curr[0].Substring(1, 98) + "#.";
            next[100] = ".#" + Curr[99].Substring(1, 98) + "#.";

            Curr = (string[])next.Clone();

            // Let's start this all off !!

            for (int iteration = 0; iteration < 100; iteration++)
            {
                for (int row = 1; row <= 100; row++)
                {
                    next[row] = ".";
                    for (int col = 1; col <= 100; col++)
                    {
                        int count = 0;
                        if (Curr[row - 1][col - 1] == '#') count++;
                        if (Curr[row - 1][col - 0] == '#') count++;
                        if (Curr[row - 1][col + 1] == '#') count++;

                        if (Curr[row - 0][col - 1] == '#') count++;
                        if (Curr[row - 0][col + 1] == '#') count++;

                        if (Curr[row + 1][col - 1] == '#') count++;
                        if (Curr[row + 1][col - 0] == '#') count++;
                        if (Curr[row + 1][col + 1] == '#') count++;

                        char nextChar = ' ';
                        if (Curr[row][col] == '#')
                        {
                            if (count == 2 || count == 3)
                                nextChar = '#';
                            else
                                nextChar = '.';
                        }
                        else
                        {
                            if (count == 3)
                                nextChar = '#';
                            else
                                nextChar = '.';
                        }
                        if ((col == 1 && (row == 1 || row == 100)) || (col == 100 && (row == 1 || row == 100)))
                            nextChar = '#';

                        next[row] += nextChar;

                    }
                    next[row] += ".";
                }

                Curr = (string[])next.Clone();
            }

            int total = 0;
            foreach (string str in Curr)
            {
                foreach (char ch in str)
                    if (ch == '#')
                        total++;
            }
            Console.WriteLine(total);
        }
    }
}
