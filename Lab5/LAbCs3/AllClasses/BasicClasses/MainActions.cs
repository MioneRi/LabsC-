using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LAbCs3
{
    public enum TypeOfPerson
    {
        Student,
        Employee
    };

    public enum AmountOfPersons
    {
        One,
        Several
    }
    
    // Статический класс не может наследовать интерфейсы.
    public static class MainActions 
    {
        public static string ChoosenFormOfRemuneration()
        {
            string ourFormOfRemuneration;
            int ourInputNumber;
            string[] formsOfRemuneration = new string[] { "Повременная", "Сдельная" };

            WriteLine("Выберите один из возможных вариантов : ");
            WriteLine("\t 1. Повременная");
            WriteLine("\t 2. Сдельная");

            Write("\t Ввод : ");
            ourInputNumber = GetCorrectPositiveInt(1, 2);

            ourFormOfRemuneration = formsOfRemuneration[ourInputNumber - 1];

            return ourFormOfRemuneration;
        }

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
            //by pattern (ID студента, Факультет, Группа, Имя, Фамилия, Успеваемость)

            WriteLine(ourStudent.PersonID + "\t" + ourStudent.Faculty + "\t " + ourStudent.Group + "\t " +
                ourStudent.Name + "\t " + ourStudent.Surname + "\t" + ourStudent.Progress);
            Write("\n");
        }

        public static void ShowEmployeeInfo(Employee ourEmployee)
        {
            //by pattern (ID работника, Имя, Фамилия, Должность, Стаж)

            WriteLine(ourEmployee.PersonID + "\t" + ourEmployee.Name + "\t" + ourEmployee.Surname + "\t" +
                ourEmployee.JobPosition + "\t" + ourEmployee.WorkExperience);
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

        // Checks interval.
        public static int GetCorrectPositiveInt(int numberFrom, int numberTill)
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
            if (ourInt < 0 || (ourInt < numberFrom || ourInt > numberTill))
            {
                Write("You enter smth wrong! \n Try again: ");
                goto someException;
            }

            return ourInt;
        }

        // Checks interval.
        public static int GetCorrectPositiveInt(int numberTill)
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
            if (ourInt < 0 || (ourInt > numberTill))
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
            ourGroupNumber = GetCorrectPositiveInt(1, 6);

            ourGroup = BSUIRUniversity.Group[ourGroupNumber - 1];

            return ourGroup;
        }

        // String should be less than 60 chars.
        public static string GetCorrectString()
        {
            string ourString;

            ourString = ReadLine();
            while (ourString.Length == 0 || ourString.Length > 60)
            {
                Write("You enter smth wrong! \n Try again: ");
                ourString = ReadLine();
            }

            return ourString;
        }

        // Here i use enums.
        public static void NoExistMassege(bool flag, TypeOfPerson typeOfPerson, AmountOfPersons amountOfPersons)
        {
            if (flag == false)
            {
                switch (typeOfPerson)
                {
                    case TypeOfPerson.Student:
                        {
                            switch (amountOfPersons)
                            {
                                case AmountOfPersons.One:
                                    {
                                        WriteLine("( Such studen doesn't exist )");
                                    }
                                    break;
                                case AmountOfPersons.Several:
                                    {
                                        WriteLine("( There's no one student )");
                                    }
                                    break;
                            }
                        }                        
                        break;

                    case TypeOfPerson.Employee:
                        {
                            switch (amountOfPersons)
                            {
                                case AmountOfPersons.One:
                                    {
                                        WriteLine("( Such employee doesn't exist )");
                                    }
                                    break;
                                case AmountOfPersons.Several:
                                    {
                                        WriteLine("( There's no one employee )");
                                    }
                                    break;
                            }
                        }                        
                        break;
                }
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
            if (ourProgress < 0 || ourProgress > 100)
            {
                WriteLine("You enter smth wrong! \n Try again: ");
                goto SomeException;
            }

            return ourProgress;
        }
        
    }
}       