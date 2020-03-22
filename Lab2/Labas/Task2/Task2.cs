using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Write("Enter a string : ");

                string ourString = ReadLine();

                while (ourString.Length == 0)
                {
                    Write("Enter a string : ");
                    ourString = ReadLine();
                }

                Task2Actions Action1 = new Task2Actions();
                Action1.AfterVowel(ref ourString);

                Write($"Our new string : { ourString }");

                Write("\n\n");
            }
        }
    }
}
