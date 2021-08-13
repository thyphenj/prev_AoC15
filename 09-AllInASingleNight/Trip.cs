using System;
using System.Collections.Generic;

namespace _09_AllInASingleNight
{
    public class Trip
    {
        public string From { set; get; }
        public string To { get; set; }
        public int Distance { get; set; }

        public Trip(string str)
        {
            string[] work = str.Split(" = ");
            Distance = int.Parse(work[1]);
            work = work[0].Split(" to ");
            From = work[0];
            To = work[1];
        }
        public Trip(string from, string to, int distance)
        {
            Distance = distance;
            From = from;
            To = to;
        }
        public Trip OtherWay()
        {
            return new Trip(To, From, Distance);

        }
        public override string ToString()
        {
            return $"{From} -> {To} = {Distance}";
        }
    }
}
