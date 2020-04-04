using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LAbCs3
{
    class main
    {
        static void Main(string[] args)
        {
            WriteLine("\t\t--------------BSUIR Students List --------------");
            
            ListOfStudents listOfStudents = new ListOfStudents();

            while (true)
            {
                int choice;

                WriteLine("Menu:");
                WriteLine("1. Добавить студента");
                WriteLine("2. Удалить студента");
                WriteLine("3. Показать список студентов");
                WriteLine("4. Найти студента по ID");
                WriteLine("5. Вывести всех студентов с учетом успеваемости");
                WriteLine("6. Выход.");

                Write("\nВыберите пункт: ");
                choice = MainActions.GetCorrectPositiveInt(1,6);

                Write("\n");

                switch (choice)
                {
                    case 1:
                        {
                            Student addedStudent = new Student();

                            addedStudent.SetInfo();

                            listOfStudents.Add(addedStudent);
                        }
                        break;

                    case 2:
                        {
                            bool flag = false;
                            int ourInputID;

                            Write("Введите ID студента : ");
                            ourInputID = MainActions.GetCorrectPositiveInt();

                            foreach (Student ourStudent in ListOfStudents.journal.ToArray() ) //that's possible if List -> Array ... but for my new class it isn't necc
                            {
                                if (ourInputID == ourStudent.PersonID)
                                {
                                    listOfStudents.Remove(ourStudent);
                                    flag = true;
                                }
                            }

                            MainActions.NotExistMassege(flag);

                        }
                        break;

                    case 3:
                        {
                            int ourChoice3;

                            WriteLine("\tВыберите один из пунктов: ");
                            WriteLine("\t1. Показать всех студентов в университете");
                            WriteLine("\t2. Показать всех студентов факультета");
                            WriteLine("\t3. Показать всех студентов специальности");
                            WriteLine("\t4. Показать всех студентов группы");

                            Write("\tВвод : ");
                            ourChoice3 = MainActions.GetCorrectPositiveInt(1,4); // in range from 1 to 4

                            switch (ourChoice3)
                            {
                                case 1:
                                    {
                                        bool flag = false;

                                        WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия)");

                                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                                        {
                                            if ( ourStudent != null)
                                            {
                                                MainActions.ShowStudentInfo(ourStudent);
                                                flag = true;
                                            }
                                            
                                        }

                                        MainActions.NotExistMassege(flag);

                                    }
                                    break;

                                case 2:
                                    {
                                        bool flag = false;
                                        string ourFaculty;
                                        int ourFacultyNumber;

                                        ourFaculty = MainActions.ChoosenFaculty(out ourFacultyNumber);

                                        WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия)");

                                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                                        {
                                            if (ourStudent.Faculty == ourFaculty)
                                            {
                                                MainActions.ShowStudentInfo(ourStudent);
                                                flag = true;
                                            }
                                        }

                                        MainActions.NotExistMassege(flag);

                                    }
                                    break;

                                case 3:
                                    {
                                        bool flag = false;
                                        string ourFaculty;
                                        int ourFacultyNumber;
                                        string ourSpecialty;

                                        ourFaculty = MainActions.ChoosenFaculty(out ourFacultyNumber);

                                        ourSpecialty = MainActions.ChoosenSpecialty(ourFacultyNumber);

                                        WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия)");

                                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                                        {
                                            if (ourStudent.Specialty == ourSpecialty)
                                            {
                                                MainActions.ShowStudentInfo(ourStudent);
                                                flag = true;
                                            }
                                        }

                                        MainActions.NotExistMassege(flag);

                                    }
                                    break;

                                case 4:
                                    {
                                        bool flag = false;
                                        string ourFaculty;
                                        int ourFacultyNumber;
                                        string ourSpecialty;
                                        string ourGroup;
                                        int ourYear;

                                        ourFaculty = MainActions.ChoosenFaculty(out ourFacultyNumber);

                                        ourSpecialty = MainActions.ChoosenSpecialty(ourFacultyNumber);

                                        ourYear = MainActions.ChoosenYear();

                                        ourGroup = MainActions.ChoosenGroup();

                                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                                        {
                                            if ( ourStudent.Group == ourGroup && ourStudent.Year == ourYear && ourStudent.Specialty == ourSpecialty)
                                            {
                                                MainActions.ShowStudentInfo(ourStudent);
                                                flag = true;
                                            }
                                        }

                                        MainActions.NotExistMassege(flag);

                                    }
                                    break;

                            }

                        }
                        break;

                    case 4:
                        {
                            bool flag = false;
                            int ourID;

                            Write("Введите ID студента: ");
                            ourID = MainActions.GetCorrectPositiveInt(); 

                            foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                            {
                                if (ourStudent.PersonID == ourID)
                                {
                                    ourStudent.ShowInfo();
                                    flag = true;
                                }
                            }

                            MainActions.NotExistMassege(flag);

                        }
                        break;

                    case 5:
                        {
                            listOfStudents.SortByProgress();
                            listOfStudents.ShowAll();

                            if (ListOfStudents.ActualNumberOfStudents == 0)
                            {
                                WriteLine("( There is no any students )");
                            }

                        }
                        break;

                    case 6:
                        {
                            Environment.Exit(0);
                        }
                        break;
                }


            }

        }
    }
}
