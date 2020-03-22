using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3from2
{
    public class Task3from2Actions
    {
        static Random rnd = new Random();

        public void MixStr( ref string ourString )
        {
            //char[] input = "abcdefg".ToCharArray(); // для задания 
            //char[] result = new char[30];

            //prev = 0;
            //step = (new Random()).Next(1, input.Length);

            //int curr = (prev + step) % (input.Length - 1);
            //result[i] = input[curr];
            //prev = curr;
            

            char[] tempArray = ourString.ToCharArray();

            for (int i = ourString.Length - 1; i > 0; --i)
            {
                int j = rnd.Next(i);
                char temp = tempArray[i];
                tempArray[i] = tempArray[j];
                tempArray[j] = temp;
            }

            ourString =  new string(tempArray);

        }


    }
}
