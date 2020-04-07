using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    // Другие сотрудники.
    class OtherEmployees : Employee
    {
        public override void SetInfo()
        {
            base.SetInfo();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            WriteLine("Должность : ");
            WriteLine("выберите один из предложенных вариантов : ");

            for (int i = 0; i < JobsPositions[2].Length; i++)
            {
                WriteLine($"\t{i+1}. " + JobsPositions[2][i] );
            }

            Write("\tВвод : ");
            jobPositionNumber = MainActions.GetCorrectPositiveInt(1, JobsPositions[2].Length);

            jobPosition = JobsPositions[2][ jobPositionNumber - 1 ];

        }


    }
}
