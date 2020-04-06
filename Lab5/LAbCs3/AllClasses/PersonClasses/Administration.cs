using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    class Administration : Employee
    {

        public override void SetInfo()
        {
            base.SetInfo();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            WriteLine("Должность : ");
            WriteLine("выберите один из предложенных вариантов : ");

            for (int i = 0; i < JobsPositions[1].Length; i++)
            {
                WriteLine($"{i + 1}. " + JobsPositions[1][i]);
            }

            Write("\tВвод : ");
            jobPositionNumber = MainActions.GetCorrectPositiveInt(1, JobsPositions[1].Length);

            jobPosition = JobsPositions[1][jobPositionNumber - 1];

        }

    }
}
