
using System;
using System.IO;
using System.Collections.Generic;

namespace _19_MedicineForRudolph
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HashSet<string> modified = new HashSet<string>();

            List<Transform> transforms = new List<Transform>();

            //string[] input = File.ReadAllLines("input.txt");
            string[] input = GetTestData();

            int j = 0;
            while (input[j].Trim().Length > 0)
            {
                transforms.Add(new Transform(input[j++]));
            }

            string mole = ParseMolecule(input[++j]);

            foreach (string str in mole.Split(' '))
            {
                Console.Write($"{str} ");
            }
            Console.WriteLine("\n\n");

        }

        private static string[] GetTestData ()
        {
            return new string[] { "H => HO", "H => OH", "O => HH", "", "HOH" };
        }

        private static string ParseMolecule(string molecule)
        {
            string retval = "";

            int i = 0;

            while (i + 1 < molecule.Length)
            {
                string newStr;
                char[] charArr = new char[2];
                char one = molecule[i++];
                char two = molecule[i];
                if (two < 'a')
                {
                    newStr = $"{one} ";
                }
                else
                {
                    newStr = $"{one}{two} ";
                    i++;
                }
                retval += newStr;
            }
            if (i < molecule.Length)
                retval += $"{molecule[i]}";

            return retval;
        }
    }
}
