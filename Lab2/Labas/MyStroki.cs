using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace StrokiActions
{
    public class Stroki
    {
        public const int Max_Int = 2147483467;
        public const double Max_Double = 4294967296.0;    ///I know that the max double is 1.7E+308 but for my purpose that's enough

        public int PerevodVInt(string n)
        {
            int chislo = 0;

            for (int i = 0, j = 1; i < n.Length; i++, j++)
            {
                chislo += (int)Math.Pow(10, n.Length - j) * (n[i] - '0');
            }

            return chislo;
        }

        public double PerevodVDouble(string n)
        {
            double chislo = 0;
            int beforeDot = 0;
            int afterDot = 0;
            int dot = 0;

            foreach (char ch in n)
            {
                if (ch != ',' && ch != '.' && dot == 0)
                {
                    beforeDot++;
                }
                if (ch == ',' || ch == '.')
                {
                    dot++;
                }

            }

            if (dot == 1)
            {
                afterDot = n.Length - beforeDot - 1;
            }

            int flag = 0;
            int numAfterDot = 0;

            int i = 0;
            foreach (char ch in n)
            {
                if (ch == ',' || ch == '.')
                {
                    flag = 1;
                }

                if (flag == 0)
                {
                    chislo += Math.Pow(10, (beforeDot - i - 1)) * (ch - '0');
                }
                else if (flag == 1 && ch != '.' && ch != ',')
                {
                    chislo += Math.Pow(10, numAfterDot) * (ch - '0');
                }

                if (flag != 0)
                {
                    numAfterDot--;
                }

                ++i;
            }

            return chislo;
        }

        public bool IsInt(string n)              ///  FUNCTION FOR CHEKING INT INPUT
        {
            if (n.Length > 10)
            {
                return false;
            }

            int counter = 0;

            foreach (char ch in n)
            {
                if (!Char.IsDigit(ch))
                {
                    counter++;
                }
            }

            if (counter > 0 || PerevodVInt(n) > Max_Int)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsDouble(string n)  //FUNCTION OF CHECKING OF DOUBLE INPUT  (округляет очень маленькие числа )
        {                                                                       /* если до запятой 1 знак => после зап. максимум 14 */
            if (n.Length == 0 || n.Length > 27 || n[0] == ',' || n[0] == '.')
            {
                return false;
            }

            int counter = 0;
            int dotorcomma = 0;
            int znakAfterDotOrComma = 0;

            foreach (char ch in n)
            {
                if (!Char.IsDigit(ch))
                {
                    if (ch == '.' || ch == ',')
                    {
                        dotorcomma++;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }

            if (dotorcomma > 1 || counter > 0)
            {
                return false;
            }

            int flag = 0;

            foreach (char ch in n)
            {
                if (flag != 0)
                {
                    znakAfterDotOrComma++;
                }

                if (ch == '.' || ch == ',')
                {
                    flag = 1;
                }
            }

            if (znakAfterDotOrComma >= 16 || PerevodVDouble(n) > Max_Double)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ChekingForDouble(Stroki ourObject, ref string ourString)
        {
            while (!ourObject.IsDouble(ourString))
            {
                WriteLine("You enter smth wrong!  \nPossibly problems:  1. there should be only numbers (not other symbols)");
                Write("\t\t    2. if it's a double type there should be max 16 chars after dot or comma  \n  Try again: ");

                ourString = ReadLine();
            }
        }

        public int FromDoubleToInt(string n)
        {
            int chislo = 0;
            int beforeDot = 0;
            int dot = 0;

            foreach (char ch in n)
            {
                if (ch != ',' && ch != '.' && dot == 0)
                {
                    beforeDot++;
                }
                if (ch == ',' || ch == '.')
                {
                    dot++;
                }
            }

            int i = 0;
            foreach (char ch in n)
            {
                chislo += (int)Math.Pow(10, (beforeDot - i - 1)) * (ch - '0');
                ++i;
            }

            return chislo;
        }




    }

}
