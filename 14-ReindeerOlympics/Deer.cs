using System;
namespace _14_ReindeerOlympics
{
    class Deer
    {
        private string _name;
        private int _speed;
        private int _flight;
        private int _rest;
        private int _distance;
        private int _point;
        public int Dist { get { return _distance; } }
        public int Points { get { return _point; } }

        public Deer(string name, int speed, int flight, int rest, int time)
        {
            _name = name;
            _speed = speed;
            _flight = flight;
            _rest = rest;

            _distance = _part1_distance(time);

            _point = 0;
        }
        private int _part1_distance(int time)
        {
            int phaseTime = _flight + _rest;

            int phases = 0;
            while (time > phaseTime)
            {
                time -= phaseTime;
                phases++;
            }

            if (time > _flight)
                time = _flight;

            int retval = (time + (phases * _flight)) * _speed;

            return retval;
        }

        public int Position(int secs)
        {
            int phases = secs / (_flight + _rest);
            int rem = secs % (_flight + _rest);
            if (rem <= _flight)
                return (phases * _flight + rem) * _speed;
            else
                return (phases * _flight + _flight) * _speed;
        }

        public void AddPoint()
        {
            _point++;
        }
        public override string ToString()
        {
            return $"{_name,10}   -   {_distance}";
        }
    }

}
