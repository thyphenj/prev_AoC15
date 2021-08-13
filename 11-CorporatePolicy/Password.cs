using System;
namespace _11_CorporatePolicy
{
    public class Password
    {
        private char[] chars = new char[8];

        public Password(string str)
        {
            chars = str.ToCharArray();
        }
        private bool AddOne(int digit)
        {
            if (chars[digit]++ == 'z')
            {
                chars[digit] = 'a';
                return true;
            }
            else if (chars[digit] == 'i')
                chars[digit] = 'j';
            else if (chars[digit] == 'l')
                chars[digit] = 'm';
            else if (chars[digit] == 'o')
                chars[digit] = 'p';

            return false;
        }

        public string Increment()
        {
            if (AddOne(7))
            {
                if (AddOne(6))
                {
                    if (AddOne(5))
                    {
                        if (AddOne(4))
                        {
                            if (AddOne(3))
                            {
                                if (AddOne(2))
                                {
                                    if (AddOne(1))
                                    {
                                        if (AddOne(0))
                                            throw new NotImplementedException();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return new string(chars);
        }

        public bool Test()
        {
            return isItIncreasin() && IsItDoubled();
        }
        private bool isItIncreasin()
        {
            if (chars[5] + 2 == chars[7] && chars[6] + 1 == chars[7])
                return true;
            if (chars[4] + 2 == chars[6] && chars[5] + 1 == chars[6])
                return true;
            if (chars[3] + 2 == chars[5] && chars[4] + 1 == chars[5])
                return true;
            if (chars[2] + 2 == chars[4] && chars[3] + 1 == chars[4])
                return true;
            if (chars[1] + 2 == chars[3] && chars[2] + 1 == chars[3])
                return true;
            if (chars[0] + 2 == chars[2] && chars[1] + 1 == chars[2])
                return true;

            return false;
        }
        private bool IsItDoubled()
        {
            int i = 0;
            while (i < 5 && chars[i] != chars[i + 1])
                i++;
            if (i == 5)
                return false;

            int j = i + 2;
            while (j < 7 && chars[j] != chars[j + 1])
                j++;
            if (j == 7)
                return false;

            return true;
        }

        public override string ToString()
        {
            return new string(chars);
        }
    }
}
