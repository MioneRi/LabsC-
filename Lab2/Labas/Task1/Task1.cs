using static System.Console;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StrokiActions;

namespace Labaratornaya2
{
    class Task1
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Stroki strActions = new Stroki();

                string ourString;

                Write("Enter a string : ");
                ourString = ReadLine();

                strActions.ChekingForDouble(strActions, ref ourString);

                //WriteLine($"Your double : {strActions.PerevodVDouble(ourString)}");  округляет очень мальенькие значения (закономерность: до запятой 1 знак => после максимум 14)

                while ((int)strActions.PerevodVDouble(ourString) > Stroki.Max_Int)
                {
                    Write("You enter smth wrong!\n Try again : ");
                    ourString = ReadLine();
                    strActions.ChekingForDouble(strActions, ref ourString);
                }

                WriteLine($"Your int from double : {strActions.FromDoubleToInt(ourString) }");

                WriteLine("\n");

            }
        }
    }
}
