using System;
using System.Security.Cryptography;
using System.Text;

namespace _04_TheIdealStockingStuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "iwrupvqb";

            Console.WriteLine("04-TheIdealStockingStuffer\n------------------------- Part 1 & 2");

            long num = 0;
            while (true)
            {
                byte[] hash = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes($"{input}{num.ToString()}"));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                if (sb.ToString().Substring(0, 5) == "00000")
                    Console.WriteLine($"{sb.ToString()} - {num}");

                if (sb.ToString().Substring(0, 6) == "000000")
                {
                    Console.WriteLine($"{sb.ToString()} - {num}");
                    break;
                }
                num++;
            }
        }
    }
}
