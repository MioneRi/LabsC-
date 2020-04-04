using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LAbCs3
{
    static class MainActions
    {
        public static string ChoosenFaculty(out int ourFacultyNumber)
        {
            string ourFaculty;

            WriteLine("Выберите один из возможных вариантов : ");
            for (int i = 0; i < 7; i++)
            {
                WriteLine("\t" + (i + 1) + ". " + BSUIRUniversity.Faculty[i]);
            }

            Write("\t№ Факультета : ");
            ourFacultyNumber = GetCorrectPositiveInt(1, 7);

            ourFaculty = BSUIRUniversity.Faculty[ourFacultyNumber - 1];

            return ourFaculty;
        }

        public static string ChoosenSpecialty(int facultyNumber)
        {
            int specialtyNumber;
            string specialty;

            WriteLine("Выберите один из возможных вариантов : ");
            int specialtyCounter = 1;
            foreach (string ourSpecialty in BSUIRUniversity.Specialty[facultyNumber - 1])
            {
                WriteLine("\t" + specialtyCounter + ". " + ourSpecialty);
                specialtyCounter++;
            }

            Write("\t№ Специальности : ");
            specialtyNumber = GetCorrectPositiveInt(1, specialtyCounter);

            specialty = BSUIRUniversity.Specialty[facultyNumber - 1][specialtyNumber - 1];

            return specialty;
        }

        public static int ChoosenYear()
        {
            int ourYear;

            Write("Курс (от 1 до 5) : ");
            ourYear = GetCorrectPositiveInt(1, 5);

            return ourYear;
        }

        public static void ShowStudentInfo(Student ourStudent)
        {
            //by pattern (ID студента, Факультет, Группа, Имя, Фамилия)

            WriteLine(ourStudent.PersonID + "\t" + ourStudent.Faculty + "\t " + ourStudent.Group + "\t " +
                ourStudent.Name + "\t " + ourStudent.Surname);
            Write("\n");
        }

        public static int GetCorrectPositiveInt()
        {
            int ourInt;

            someException:
            try
            {
                ourInt = Convert.ToInt32(ReadLine());
            }
            catch (Exception)
            {
                Write("You enter smth wrong! \n Try again: ");
                goto someException;
            }
            if (ourInt < 0)
            {
                Write("You enter smth wrong! \n Try again: ");
                goto someException;
            }

            return ourInt;
        }

        public static int GetCorrectPositiveInt(int numberFrom, int numberTill) //checks the gap
        {
            int ourInt;

            someException:
            try
            {
                ourInt = Convert.ToInt32(ReadLine());
            }
            catch (Exception)
            {
                Write("You enter smth wrong! \n Try again: ");
                goto someException;
            }
            if (ourInt < 0 || ( ourInt < numberFrom || ourInt > numberTill ) )
            {
                Write("You enter smth wrong! \n Try again: ");
                goto someException;
            }

            return ourInt;
        }

        public static int GetCorrectPositiveInt(int numberTill) //checks the gap
        {
            int ourInt;

            someException:
            try
            {
                ourInt = Convert.ToInt32(ReadLine());
            }
            catch (Exception)
            {
                Write("You enter smth wrong! \n Try again: ");
                goto someException;
            }
            if (ourInt < 0 || ( ourInt > numberTill))
            {
                Write("You enter smth wrong! \n Try again: ");
                goto someException;
            }

            return ourInt;
        }

        public static string ChoosenGroup()
        {
            int ourGroupNumber;
            string ourGroup;

            WriteLine("Выберите один из возможных вариантов : ");
            for (int i = 0; i < 6; i++)
            {
                WriteLine("\t" + (i + 1) + ". " + BSUIRUniversity.Group[i]);
            }

            Write("\t№ Группы : ");
            ourGroupNumber = GetCorrectPositiveInt(1,6);

            ourGroup = BSUIRUniversity.Group[ourGroupNumber - 1];

            return ourGroup;
        }

        public static string GetCorrectString()
        {
            string ourString;

            ourString = ReadLine();
            while (ourString.Length == 0 || ourString.Length > 60 )
            {
                Write("You enter smth wrong! \n Try again: ");
                ourString = ReadLine();
            }

            return ourString;
        }

        public static void NotExistMassege(bool flag)
        {
            if (flag == false)
            {
                WriteLine("( Such student doesn't exist )");
            }
        }

        public static int ChoosenProgress()
        {
            int ourProgress;

            Write("Успеваемость(0-100) : ");

            SomeException:
            try
            {
                ourProgress = Convert.ToInt32(ReadLine());
            }
            catch (Exception)
            {
                WriteLine("You enter smth wrong! \n Try again: ");
                goto SomeException;
            }
            if ( ourProgress < 0 || ourProgress > 100)
            {
                WriteLine("You enter smth wrong! \n Try again: ");
                goto SomeException;
            }

            return ourProgress;
        }

    }
}