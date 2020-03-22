using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

using Task3from2;

namespace Task3From2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Write("Enter a string : ");

                string ourString = ReadLine();
                
                while ( ourString.Length == 0)
                {
                    Write("Enter a string : ");
                    ourString = ReadLine();
                }

                Task3from2Actions action1 = new Task3from2Actions();

                action1.MixStr(ref ourString);

                WriteLine($"After mixing : {ourString}");

                Write("\n\n");
            }
        }
    }
}
