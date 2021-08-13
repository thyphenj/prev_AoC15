using System;
namespace _06_ProbablyAFireHazard
{
    public class Quad
    {
        public Pont Lo { get; set; }
        public Pont Hi { get; set; }
        public ActionType Act { set; get; }

        public Quad(string str)
        {
            string[] work = str.Split(" through ");
            Hi = new Pont(work[1]);
            work = work[0].Split(' ');
            if (work[0] == "toggle")
            {
                Act = ActionType.toggle;
                Lo = new Pont(work[1]);
            }
            else if (work[1] == "on")
            {
                Act = ActionType.turnOn;
                Lo = new Pont(work[2]);
            }
            else
            {
                Act = ActionType.turnOff;
                Lo = new Pont(work[2]);
            }
        }

        public enum ActionType
        {
            turnOn,
            turnOff,
            toggle
        }

        public bool OnOff(bool curr)
        {
            switch (Act)
            {
                case Quad.ActionType.turnOn:
                    return true;

                case Quad.ActionType.turnOff:
                    return false;
                case Quad.ActionType.toggle:
                    return !curr;
                default:
                    return false;
            }
        }
        public int Delta()
        {
            switch (Act)
            {
                case Quad.ActionType.turnOn:
                    return 1;
                case Quad.ActionType.turnOff:
                    return -1;
                case Quad.ActionType.toggle:
                    return 2;
                default: return 0;
            }

        }
    }
}
