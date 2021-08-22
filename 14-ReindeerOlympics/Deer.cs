using System;
namespace _14_ReindeerOlympics
{
    class Deer
    {
        private string Name;
        private int Speed;
        private int Flight;
        private int Rest;
        private int Distance;
        private int Points;
        public int Dist { get { return Distance; } }
        public int GetPoints { get { return Points; } }

        public Deer(string name, int speed, int flight, int rest, int time)
        {
            Name = name;
            Speed = speed;
            Flight = flight;
            Rest = rest;

            Distance = _part1_distance(time);

            Points = 0;
        }
        private int _part1_distance(int time)
        {
            int phaseTime = Flight + Rest;

            int phases = 0;
            while (time > phaseTime)
            {
                time -= phaseTime;
                phases++;
            }

            if (time > Flight)
                time = Flight;

            int retval = (time + (phases * Flight)) * Speed;

            return retval;
        }

        public int Position(int secs)
        {
            int phases = secs / (Flight + Rest);
            int rem = secs % (Flight + Rest);
            if (rem <= Flight)
                return (phases * Flight + rem) * Speed;
            else
                return (phases * Flight + Flight) * Speed;
        }

        public void AddPoint()
        {
            Points++;
        }
        public override string ToString()
        {
            return $"{Name,10}   -   {Distance}";
        }
    }

}
