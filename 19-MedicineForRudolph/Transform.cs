using System;
namespace _19_MedicineForRudolph
{
    public class Transform
    {
        public string From;
        public string To;

        public Transform(string str)
        {
            string[] tokens = str.Split(" => ");
            From = tokens[0];
            To = tokens[1];
        }

        public override string ToString()
        {
            return $"{From} => {To}";
        }
    }
}
