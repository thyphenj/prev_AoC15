using System;

namespace _11_CorporatePolicy
{
    class Program
    {
        static void Main(string[] args)
        {
            string seed = "hepxcrrq";


            string result = Part1(seed);
        }
        static string Part1(string seed)
        {
            string retval = seed;
            var pw = new Password(seed);

            int answercount = 0;
            while (answercount < 2)
            {
                var xx = pw.Increment();
                if (pw.Test())
                {
                    answercount++;
                    Console.WriteLine($"{answercount,10} {xx}");
                }
            }
            return retval;
        }
    }
}
