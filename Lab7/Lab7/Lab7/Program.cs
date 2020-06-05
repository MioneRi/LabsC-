using System;
using System.Collections.Generic;

using static System.Console;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {

            WriteLine("\t Test functions \n");

            Fraction fr1 = new Fraction(1, 5);
            Fraction fr2 = new Fraction(2,8);
            Fraction fr3 = new Fraction(1, 4);
            bool tmp = true;

            WriteLine("1. Math and comparison operations : \n");
            fr3 = fr1 + fr2;
            WriteLine("\t1/5 + 2/8 = {0}", fr3.ToString("div"));
            fr3 = fr2 - fr1;
            WriteLine("\t2/8 - 1/5 = {0}", fr3.ToString("div"));
            fr3 = fr2 * fr1;
            WriteLine("\t(2/8) * (1/5) = {0}", fr3.ToString("div"));
            fr3 = fr2 / fr1;
            WriteLine("\t(2/8) / (1/5) = {0}", fr3.ToString("div"));
            tmp = fr2 > fr1; // true
            WriteLine("\t(2/8) > (1/5) - {0}", tmp);
            tmp = fr2 < fr1; // false
            WriteLine("\t(2/8) < (1/5) - {0}", tmp);
            Fraction fr4 = new Fraction(1, 4);
            tmp = (fr4 == fr2); // true
            WriteLine("\t(1/4) == (2,8) = {0}", tmp);
            tmp = (fr4 != fr1); // true
            WriteLine("\t(1/4) != (1/5) = {0}", tmp);
            Fraction fr5 = new Fraction(4,5);
            tmp = (fr5 >= fr1);
            WriteLine("\t(4/5) >= (1/5) = {0}", tmp);
            tmp = (fr5 <= fr1);
            WriteLine("\t(4/5) <= (1/5) = {0}", tmp);

            WriteLine("2. Object to string in diff. formats : \n");
            Fraction fr6 = new Fraction(10, 20);
            WriteLine("\t(10/20) = {0}", fr6.ToString());
            WriteLine("\t(10/20) = {0}", fr6.ToString("div"));
            Fraction fr7 = new Fraction(3, 8);
            WriteLine("\t(3/8) = {0}", fr7.ToString());
            WriteLine("\t(3/8) = {0}", fr7.ToString("div"));
            Fraction fr8 = new Fraction(1, 100);
            WriteLine("\t(1/100) = {0}", fr8.ToString());
            WriteLine("\t(1/100) = {0}", fr8.ToString("div"));

            WriteLine("3. String to object in diff. forms : \n");
            Fraction fr9 = Fraction.Parse("2.5");
            Fraction fr10 = Fraction.Parse("1/4");
            WriteLine("\tfrom 2.5 = {0}", fr9.ToString());
            WriteLine("\tfrom 1/4 = {0}", fr10.ToString("div"));

            WriteLine("4. compare and equal : \n");
            Random rand = new Random(DateTime.Now.Millisecond);
            List<Fraction> ourList = new List<Fraction>();
            for (int i = 0; i<10; i++)
            {
                ourList.Add(new Fraction( rand.Next(5, 20), rand.Next(1, 20)));
            }

            WriteLine("\tBefore sort : ");
            for (int i = 0; i < 10; i++)
            {
                Write("({0}) ", ourList[i].ToString("div"));
            }
            WriteLine();

            ourList.Sort();
            WriteLine("\tAfter sort : ");
            for (int i = 0; i < 10; i++)
            {
                Write("({0}) ", ourList[i].ToString("div"));
            }

            Fraction fr11 = new Fraction(15, 6);
            Fraction fr12 = new Fraction(15, 6);

            tmp = fr11.Equals(fr12);
            WriteLine("\n(15/6) equals (15/6) = {0}\n", tmp);

            WriteLine("5. Try Fraction to (int) or (double) : \n");

            Fraction fr20 = new Fraction(4, 3);
            WriteLine("\t(int)4/3 = {0}", (int)fr20);
            WriteLine("\t(double)4/3 = {0}", (double)fr20);

            WriteLine("End.");

            ReadKey();
        }
    }
}
