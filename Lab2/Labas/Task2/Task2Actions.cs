using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Task2Actions
    {
        public void AfterVowel ( ref string ourString )
        {
            string origString = ourString;

            for ( int i = 0; i<ourString.Length; ++i )
            {
                if ( i == 0)
                {
                    continue;
                }
                
                if ( ComparisonIfVowel( origString[i-1] ) == true && (int)origString[i] < 123 && (int)origString[i] > 96 )
                {
                    char[] temparr = ourString.ToCharArray();                    

                    if ( origString[i] == 'z' )
                    {
                        temparr[i] = 'a';
                    }
                    else
                    {
                        temparr[i] = Convert.ToChar((int)origString[i] + 1);
                    }

                    ourString = new string(temparr); // ссылка ourString теперь ссылается на новый обьект temparr!
                }
            }

        }

        public bool ComparisonIfVowel ( char ourChar )
        {
            char[] vowelChars = new char[]
            { 'a', 'e', 'i', 'o', 'u', 'y' };

            foreach (char ch in vowelChars)
            {
                if ( ourChar == ch )
                {
                    return true;
                }
            }

            return false;

        }

    }
}
