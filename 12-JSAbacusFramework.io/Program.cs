using System;
using System.IO;

namespace _12_JSAbacusFramework.io
{
    class Program
    {
        private static string input;
        private static int pos;

        static void Main(string[] args)
        {
            //Console.WriteLine("12-JSAbacusFramework.io\n-------------------------------- Part 1");
            //{
            //input = File.ReadAllText("input.json");

            //int i = 0;
            //int sum = 0;
            //while (i < input.Length)
            //{
            //    if ((input[i] >= '0' && input[i] <= '9') || input[i] == '-')
            //    {
            //        // Parse out the number
            //        string n = "" + (char)input[i++];
            //        while (i < input.Length && input[i] >= '0' && input[i] <= '9')
            //        {
            //            n += (char)input[i++];
            //        }
            //        int num = int.Parse(n);
            //        sum += num;
            //        //                        Console.WriteLine($"{num,6}");
            //    }
            //    else
            //        i++;
            //}

            //Console.WriteLine(sum);
            //}

            Console.WriteLine("\n-------------------------------- Part 2");
            {
                input = File.ReadAllText("input.txt");
                //input = "[1,{\"c\":\"red\",\"b\":2},3]";
                //input = "\"Hello World\",";

                Console.WriteLine("         1         2         3");
                Console.WriteLine(input);

                EvalInput();

            }
        }
        private static int EvalInput()
        {
            int sum = 0;

            switch (input[SkipWhiteSpace()])
            {
                case ',':
                case ':':
                    pos++;
                    break;
                case '[':
                    sum = EvalArray();
                    break;
                case '{':
                    sum = EvalObject();
                    break;
                case '"':
                    string str = EvalString();
                    break;
                default:
                    sum = EvalNumber();
                    break;
            }
            Console.WriteLine(sum);
            return sum;
        }
        private static int EvalArray()
        {
            int sum = 0;

            pos++;
            while (input[SkipWhiteSpace()] != ']')
            {
                sum += EvalInput();
                Console.WriteLine($"{pos,3}");
            }
            pos++;

            return sum;
        }
        private static int EvalObject()
        {
            int sum = 0;

            pos++;
            while (input[SkipWhiteSpace()] != '}')
            {
                sum = EvalInput();
                Console.WriteLine($"{pos,3}");
            }
            pos++;

            return sum;
        }
        private static string EvalString()
        {
            string str = "";
            pos++;
            while (input[pos] != '"')
                str += input[pos++];
            pos++;

            Console.WriteLine($"{pos,3} [{str}]");

            return str;
        }
        private static int EvalNumber()
        {
            string str = "";
            while (input[pos] == '-' || (input[pos] >= '0' && input[pos] <= '9'))
                str += input[pos++];

            Console.WriteLine($"{pos,3} [{str}]");

            return int.Parse(str);
        }
        private static int SkipWhiteSpace()
        {
            while (input[pos] == ' ' || input[pos] == '\t' || input[pos] == '\n')
                pos++;

            return pos;
        }
    }
}
