using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_SomeAssemblyReauired
{
    public class Gate : IComparable<Gate>
    {
        private string Raw;
        private ActionType Act;
        public int opcount;

        public ushort? val1;
        public ushort? val2;
        public ushort? result;

        public string gate1 = "";
        public string gate2 = "";
        public string Name = "";

        public int CompareTo(Gate that)
        {
            return String.Compare(this.Name, that.Name);
        }
        public Gate()
        {

        }
        public Gate(string str)
        {
            Raw = str;

            string[] work = str.Split(" -> ");
            Name = work[1];

            work = work[0].Split(' ');
            if (work.Length == 1)
            {
                Act = ActionType.ASSIGN;
                gate1 = work[0];
                opcount = 1;
            }
            else if (work.Length == 2)
            {
                Act = ActionType.NOT;
                gate1 = work[1];
                opcount = 1;
            }
            else
            {
                switch (work[1])
                {
                    case "AND":
                        Act = ActionType.AND;
                        break;
                    case "OR":
                        Act = ActionType.OR;
                        break;
                    case "LSHIFT":
                        Act = ActionType.LSHIFT;
                        break;
                    case "RSHIFT":
                        Act = ActionType.RSHIFT;
                        break;
                    default:
                        Act = ActionType.UNKNOWN;
                        break;
                }
                gate1 = work[0];
                gate2 = work[2];
                opcount = 2;
            }
            if (ushort.TryParse(gate1, out ushort v1)) val1 = v1;
            if (ushort.TryParse(gate2, out ushort v2)) val2 = v2; ;
            if (val1.HasValue)
                if (opcount == 1)
                    result = val1;
                else if (val2.HasValue)
                {
                    switch (Act)
                    {
                        case ActionType.AND:
                            result = (ushort?)(val1.Value & val2.Value);
                            break;
                        case ActionType.OR:
                            result = (ushort?)(val1.Value | val2.Value);
                            break;
                        case ActionType.LSHIFT:
                            result = (ushort?)(val1.Value << val2.Value);
                            break;
                        case ActionType.RSHIFT:
                            result = (ushort?)(val1.Value >> val2.Value);
                            break;
                    }
                }

        }
        public ushort? SetResult()
        {
            switch (Act)
            {
                case ActionType.ASSIGN:
                    return val1.Value;

                case ActionType.NOT:
                    return (ushort?)(~val1.Value);

                case ActionType.AND:
                    return (ushort?)(val1.Value & val2.Value);

                case ActionType.OR:
                    return (ushort?)(val1.Value | val2.Value);

                case ActionType.LSHIFT:
                    return (ushort?)(val1.Value << val2.Value);

                case ActionType.RSHIFT:
                    return (ushort?)(val1.Value >> val2.Value);
            }

            return 0;
        }

        public void TryResults(List<Gate> gates)
        {
            if (!result.HasValue)
            {
                Gate x, y;
                if (!val1.HasValue)
                {
                    x = gates.Where(a => a.Name == gate1).FirstOrDefault();
                    val1 = x.result;
                }
                if (opcount == 1 && val1.HasValue)
                    result = SetResult();

                if (opcount == 2 && !val2.HasValue)
                {
                    y = gates.Where(a => a.Name == gate2).FirstOrDefault();
                    val2 = y.result;
                }
                if (val1.HasValue && val2.HasValue)
                    result = SetResult();
            }
        }

        public override string ToString()
        {
            string retval = $"{Name} <- {Act} [{(result.HasValue ? result.ToString() + "*" : "")}] ({(val1.HasValue ? val1.ToString() + "*" : gate1)})";
            if (opcount == 2)
                retval = $"{retval}({(val2.HasValue ? val2.ToString() + "*" : gate2)})";
            return retval;
        }
    }
    public enum ActionType
    {
        UNKNOWN,
        ASSIGN,
        AND,
        OR,
        LSHIFT,
        RSHIFT,
        NOT
    }
}
