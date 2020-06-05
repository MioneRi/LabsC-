using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Fraction : IComparable<Fraction>, IFormattable
    {
        // Числитель.
        public int Numerator
        {
            get => numerator;
            set => SetNumerator(value);
        }

        // Знаменатель.
        public int Denominator
        {
            get => denominator;
            set => SetDenomerator(value);
        }

        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        // Наибольший общий делитель.
        public static int GreatestCommonDivisor(int n, int m)
        {
            if (n > m)
            {
                return EuclidsAlgorithm(n ,m);
            }
            else
            {
                return EuclidsAlgorithm(m, n);
            }         
        }

        private static int EuclidsAlgorithm(int a, int b)
        {
            int reminder = a % b;

            if (reminder == 0)
            {
                return Math.Abs(b);
            }
            else
            {
                return EuclidsAlgorithm(b, reminder);
            }

        }

        private void Reduce()
        {
            if (numerator != 0 && denominator != 0)
            {
                int ourGCD = GreatestCommonDivisor(numerator, denominator);

                numerator /= ourGCD;
                denominator /= ourGCD;
            }         
        }

        private void SetNumerator(int numerator)
        {
            this.numerator = numerator;

            // Reducing the values if it's possible.
            Reduce();
        }

        private void SetDenomerator(int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denumerator cannot be a null ...");
            }
            else if (denominator < 0)
            {
                Numerator = -1 * Numerator;
                denominator = -1 * denominator;
            }

            this.denominator = denominator;

            // Reducing if it's possible.
            Reduce();
        }

        static int LeastCommonMultiple(int a, int b)
        {
            int result = 0;

            result = (a * b) / (GreatestCommonDivisor(a, b));

            return result;
        }

        public int CompareTo(Fraction ourObj)
        {
            int ourLCM = LeastCommonMultiple(Denominator, ourObj.Denominator);

            int res1 = Numerator * (ourLCM/Denominator);
            int res2 = ourObj.Numerator * (ourLCM/ourObj.Denominator);

            if (res1 > res2)
            {
                return 1;
            }
            else if (res1 < res2)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        public override string ToString()
        {
            return this.ToString("DOT", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        // Formats "DOT" and "DIV"
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "DOT";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "DOT":
                    {
                        double tmp = ( (double)Numerator / (double)Denominator );

                        return tmp.ToString();
                    }
                    break;
                case "DIV":
                    {
                        string tmp = Numerator.ToString() + "/" + Denominator.ToString();

                        return tmp;
                    }
                    break;
                default:
                    {
                        throw new Exception("This format isn't correct...\n");
                    }
            }
        }

        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
            int LCM, newNumerator;

            LCM = LeastCommonMultiple(fr1.denominator, fr2.denominator);
            newNumerator = fr1.numerator * (LCM / fr1.denominator) + fr2.numerator * (LCM/fr2.denominator);

            return new Fraction(newNumerator, LCM);
        }

        public static Fraction operator -(Fraction fr)
        {
            return new Fraction(-fr.numerator, fr.denominator);
        }

        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
            // Cuz we already declare operation "+" betweeen them.
            return fr1 + (-fr2);
        }

        public static Fraction operator *(Fraction fr1, Fraction fr2)
        {
            return new Fraction( (fr1.numerator * fr2.numerator), (fr1.denominator * fr2.denominator) );
        }

        public static Fraction operator /(Fraction fr1, Fraction fr2)
        {
            return new Fraction( (fr1.numerator * fr2.denominator), (fr1.denominator * fr2.numerator) );
        }

        public static bool operator >(Fraction fr1, Fraction fr2)
        {
            return fr1.CompareTo(fr2) == 1;
        }

        public static bool operator <(Fraction fr1, Fraction fr2)
        {
            return fr1.CompareTo(fr2) == -1;
        }

        public static bool operator ==(Fraction fr1, Fraction fr2)
        {
            return fr1.CompareTo(fr2) == 0;
        }

        public static bool operator !=(Fraction fr1, Fraction fr2)
        {
            return fr1.CompareTo(fr2) != 0;
        }

        public static bool operator >=(Fraction fr1, Fraction fr2)
        {
            return fr1.CompareTo(fr2) != -1;
        }

        public static bool operator <=(Fraction fr1, Fraction fr2)
        {
            return fr1.CompareTo(fr2) != 1;
        }

        public static explicit operator int(Fraction fr)
        {
            int ourInt = fr.numerator / fr.denominator;

            return ourInt;
        }

        public static explicit operator double(Fraction fr)
        {
            double ourDbl = ( ((double)fr.numerator) / ((double)fr.denominator) );

            return ourDbl;
        }

        // Converting from string to Fraction.
        public static Fraction Parse(string ourStr)
        {
            // That string can be "12.4" or "12/4" or "12,4".
            string patternWithDot = @"^(-?\d*)[\.|,](\d*)$";
            string patternWithDiv = @"^(-?\d*)\/(\d*)$";

            Regex regWithDot = new Regex(@"^(-?\d*)[\.|,](\d*)$");
            Regex regWithDiv = new Regex(@"^(-?\d*)\/(\d*)$");

            // Check our situation.       
            if (Regex.IsMatch(ourStr, patternWithDot, RegexOptions.IgnoreCase))
            {
                // Get our correct string.
                Match ourValue = regWithDot.Match(ourStr);
                
                int firstBlock = (int)Math.Pow(10, ourValue.Groups[1].Value.Length);
                int firstParameter = int.Parse(ourValue.Groups[1].Value) * firstBlock + int.Parse(ourValue.Groups[2].Value);
                int secondParameter = firstBlock;

                return new Fraction(firstParameter, secondParameter);
            }
            else if (Regex.IsMatch(ourStr, patternWithDiv, RegexOptions.IgnoreCase))
            {
                Match ourValue = regWithDiv.Match(ourStr);

                int firstParameter = int.Parse(ourValue.Groups[1].Value);
                int secondParametr = int.Parse(ourValue.Groups[2].Value);

                return new Fraction(firstParameter, secondParametr);
            }
            else
            {
                throw new Exception("\nUncorrect string...\n");
            }      

        }

        public override bool Equals(object obj)
        {
            return (obj is Fraction fraction) && (numerator == fraction.numerator) && (denominator == fraction.denominator);
        }





    }
}
