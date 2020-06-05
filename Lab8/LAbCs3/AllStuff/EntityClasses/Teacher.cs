using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    public class Teacher : Employee
    {

        public override void SetInfo()
        {
            base.SetInfo();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            WriteLine("должность : ");
            WriteLine("выберите один из предложенных вариантов : ");

            for (int i = 0; i < JobsPositions[0].Length; i++)
            {
                WriteLine($"\t{i + 1}. " + JobsPositions[0][i]);
            }

            Write("\tВвод : ");
            jobPositionNumber = MainActions.GetCorrectPositiveInt(1, JobsPositions[0].Length);

            jobPosition = JobsPositions[0][jobPositionNumber - 1];

        }


    }
}
