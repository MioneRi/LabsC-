using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LAbCs3
{
    // Cтатический класс не может наследовать интерфейсы.
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
            // By pattern (ID студента, Факультет, Группа, Имя, Фамилия, Успеваемость).

            WriteLine(ourStudent.PersonID + "\t" + ourStudent.Faculty + "\t " + ourStudent.Group + "\t " +
                ourStudent.Name + "\t " + ourStudent.Surname + "\t" + ourStudent.Progress);
            Write("\n");
        }

        public static void ShowEmployeeInfo(Employee ourEmployee)
        {
            // By pattern (ID работника, Имя, Фамилия, Должность, Стаж).

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

        // Checks the interval.
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

        // Checks the interval.
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
            while ( (ourString.Length == 0) || (ourString.Length > 60) )
            {
                Write("You enter smth wrong! \n Try again: ");
                ourString = ReadLine();
            }

            return ourString;
        }

        // Here i use enums.
        public static void NoExistMassege(bool flag, TypeOfEntity typeOfEntity, AmountOfEntities amountOfEntities) 
        {
            if (flag == false)
            {
                switch (typeOfEntity)
                {
                    case TypeOfEntity.Student:
                        {
                            switch (amountOfEntities)
                            {
                                case AmountOfEntities.One:
                                    {
                                        WriteLine("( Such studen doesn't exist )");
                                    }
                                    break;
                                case AmountOfEntities.Several:
                                    {
                                        WriteLine("( There's no one student )");
                                    }
                                    break;
                            }
                        }                        
                        break;

                    case TypeOfEntity.Employee:
                        {
                            switch (amountOfEntities)
                            {
                                case AmountOfEntities.One:
                                    {
                                        WriteLine("( Such employee doesn't exist )");
                                    }
                                    break;

                                case AmountOfEntities.Several:
                                    {
                                        WriteLine("( There's no one employee )");
                                    }
                                    break;
                            }
                        }                        
                        break;

                    case TypeOfEntity.Book:
                        {
                            switch (amountOfEntities)
                            {
                                case AmountOfEntities.One:
                                    {
                                        WriteLine("( Such book doesn't exist )");
                                    }
                                    break;

                                case AmountOfEntities.Several:
                                    {
                                        WriteLine("( There's no books )");
                                    }
                                    break;
                            }
                        }
                        break;

                    case TypeOfEntity.Association:
                        {
                            switch (amountOfEntities)
                            {
                                case AmountOfEntities.One:
                                    {
                                        WriteLine("( Such association doesn't exist ) ");
                                    }
                                    break;

                                case AmountOfEntities.Several:
                                    {
                                        WriteLine("( There's no associations )");
                                    }
                                    break;
                            }
                        }
                        break;

                    default:
                        {
                            throw new FormatException(String.Format($"The {typeOfEntity} type of TypeOfEntity is not supported."));
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

        // Indexers cannot be passed by reference.
        public static void Swap<T>(ref T firstObject, ref T secondObject)
        {
            T temp = firstObject;
            firstObject = secondObject;
            secondObject = temp;
        }

        public static bool MyReferenceEquals(object objA, object objB)
        {
            return objA == objB;
        }
        
        public static void ChoosenTypeOfAssociation(out TypeOfEntity ourTypeOfEntity)
        {
            int ourLocalChoice;

            WriteLine("Выберите тип обьединения : ");
            WriteLine("\t1. Студенческое ");
            WriteLine("\t2. Преподавательское");
            Write("\tВвод : ");

            ourLocalChoice = MainActions.GetCorrectPositiveInt(1, 2);

            switch (ourLocalChoice)
            {
                case 1:
                    {
                        ourTypeOfEntity = TypeOfEntity.Student;
                    }
                    break;
                case 2:
                    {
                        ourTypeOfEntity = TypeOfEntity.Employee;
                    }
                    break;
                default:
                    {
                        ourTypeOfEntity = TypeOfEntity.Student;
                    }
                    break;
            }


        }

    }
}       