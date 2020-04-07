using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LAbCs3
{
    class MainClass
    {
        static void Main(string[] args)
        {
            WriteLine("\t\t--------------BSUIR Students, employees and book List --------------");


            while (true)
            {
                int mainChoice;

                GotoMainMenu:
                WriteLine("Menu:");
                WriteLine("1. Списки студентов");
                WriteLine("2. Списки сотрудников");
                WriteLine("3. Библиотека");
                WriteLine("4. Выход.");

                Write("\nВыберите пункт: ");
                mainChoice = MainActions.GetCorrectPositiveInt(1, 4);

                switch (mainChoice)
                {

                    case 1:
                        {

                            ListOfStudents listOfStudents = new ListOfStudents();

                            while (true)
                            {
                                int firstChoice;

                                WriteLine("Students Menu:");
                                WriteLine("1. Добавить студента");
                                WriteLine("2. Удалить студента");
                                WriteLine("3. Показать список студентов");
                                WriteLine("4. Найти студента по ID");
                                WriteLine("5. Вывести всех студентов с учетом успеваемости");
                                WriteLine("6. Вернуться в главное меню");
                                WriteLine("7. Выход.");

                                Write("\nВыберите пункт: ");
                                firstChoice = MainActions.GetCorrectPositiveInt(1, 7);

                                Write("\n");

                                switch (firstChoice)
                                {
                                    case 1:
                                        {
                                            Student addedStudent = new Student();

                                            addedStudent.SetInfo();

                                            ListOfStudents.Add(addedStudent);
                                        }
                                        break;

                                    case 2:
                                        {              
                                            SwitchCaseActions.RemoveStudent();

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
                                            ourChoice3 = MainActions.GetCorrectPositiveInt(1, 4); // in range from 1 to 4

                                            switch (ourChoice3)
                                            {
                                                case 1:
                                                    {
                                                        ListOfStudents.ShowAll();
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

                                                        MainActions.NoExistMassege(flag, TypeOfPerson.Student, AmountOfPersons.Several);
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

                                                        MainActions.NoExistMassege(flag, TypeOfPerson.Student, AmountOfPersons.Several);
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

                                                        WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия)");

                                                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                                                        {
                                                            if (ourStudent.Group == ourGroup && ourStudent.Year == ourYear && ourStudent.Specialty == ourSpecialty)
                                                            {
                                                                MainActions.ShowStudentInfo(ourStudent);
                                                                flag = true;
                                                            }
                                                        }

                                                        MainActions.NoExistMassege(flag, TypeOfPerson.Student, AmountOfPersons.Several);
                                                    }
                                                    break;

                                            }

                                        }
                                        break;

                                    case 4:
                                        {                                            
                                            SwitchCaseActions.FindStudentByID();

                                        }
                                        break;

                                    case 5:
                                        {
                                            ListOfStudents.SortByProgress();
                                            ListOfStudents.ShowAll();

                                            if (ListOfStudents.ActualNumberOfStudents == 0)
                                            {
                                                WriteLine("( There is no any students )");
                                            }

                                        }
                                        break;

                                    case 6:
                                        {
                                            goto GotoMainMenu;
                                        }
                                        //break;

                                    case 7:
                                        {
                                            Environment.Exit(0);
                                        }
                                        break;
                                }

                            }

                        }
                        break;

                    case 2:
                        {                            
                            while (true)
                            {
                                int secondChoice;

                                WriteLine("Employees Menu:");
                                WriteLine("1. Добавить сотрудника");
                                WriteLine("2. Удалить сотрудника");
                                WriteLine("3. Показать список сотрудников");
                                WriteLine("4. Найти сотрудника по ID");
                                WriteLine("5. Вывести всех сотрудников с учетом стажа работы");
                                WriteLine("6. Вернуться в главное меню");
                                WriteLine("7. Выход.");

                                Write("\nВыберите пункт: ");
                                secondChoice = MainActions.GetCorrectPositiveInt(1, 7);

                                switch (secondChoice)
                                {
                                    case 1:
                                        {
                                            SwitchCaseActions.AddEmployee();
                                        }
                                        break;

                                    case 2:
                                        {
                                            SwitchCaseActions.RemoveEmployee();
                                        }
                                        break;

                                    case 3:
                                        {                                           
                                            ListOfEmployees.ShowAll();
                                        }
                                        break;

                                    case 4:
                                        {
                                            SwitchCaseActions.FindEmployeeByID();
                                        }
                                        break;

                                    case 5:
                                        {
                                            ListOfEmployees.SortByWorkExperience();
                                            ListOfEmployees.ShowAll();
                                        }
                                        break;

                                    case 6:
                                        {
                                            goto GotoMainMenu;
                                        }
                                        //break;

                                    case 7:
                                        {
                                            Environment.Exit(0);                                              
                                        }
                                        break;

                                }

                            }

                        }
                        break;

                    case 3:
                        {
                            List<Book> listOfBooks = new List<Book>();

                            while (true) 
                            {
                                int thirdChoice;

                                WriteLine("Libruary Menu : ");
                                WriteLine("1. Добавить книгу");
                                WriteLine("2. Удалить книгу");
                                WriteLine("3. Показать все книги");
                                WriteLine("4. В главное меню");
                                WriteLine("5. Выход.");

                                Write("Ввод : ");
                                thirdChoice = MainActions.GetCorrectPositiveInt(1, 5);

                                switch (thirdChoice)
                                {
                                    case 1:
                                        {
                                            Book newBook = new Book(listOfBooks.Count);

                                            newBook.SetInfo();

                                            listOfBooks.Add(newBook);
                                        }
                                        break;

                                    case 2:
                                        {                                           
                                            Write("Введите ID книги : ");
                                            int ourBookID = MainActions.GetCorrectPositiveInt();

                                            bool flag = false;
                                            
                                            foreach (Book ourBook in listOfBooks.ToArray())
                                            {
                                                if (ourBook.BookID == ourBookID)
                                                {
                                                    listOfBooks.Remove(ourBook);
                                                    flag = true;
                                                }
                                            }

                                            if (flag == false)
                                            {
                                                WriteLine("( There's no such book )");
                                            }

                                        }
                                        break;

                                    case 3:
                                        {
                                            bool flag = false;

                                            WriteLine("( ID, title, year, price )");
                                            foreach (Book ourBook in listOfBooks.ToArray())
                                            {                                                
                                                ourBook.ShowInfo();
                                                flag = true;                                                
                                            }

                                            if (flag == false)
                                            {
                                                WriteLine("( There's no any book )");
                                            }

                                        }
                                        break;

                                    case 4:
                                        {
                                            goto GotoMainMenu;
                                        }
                                    //break;

                                    case 5:
                                        {
                                            Environment.Exit(0);
                                        }
                                        break;
                                }
                            } 
                            
                        }
                        break;

                    case 4:
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }

            

        }
    }
}
