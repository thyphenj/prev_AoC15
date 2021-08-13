using System;
namespace _06_ProbablyAFireHazard
{
    public class Pont
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pont(string str)
        {
            string[] work = str.Split(',');

            X = int.Parse(work[0]);
            Y = int.Parse(work[1]);
        }
    }
}
