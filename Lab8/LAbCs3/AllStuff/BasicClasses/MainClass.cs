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
                Clear();
                WriteLine("Menu:");
                WriteLine("1. Списки студентов");
                WriteLine("2. Списки сотрудников");
                WriteLine("3. Библиотека");
                WriteLine("4. Научные обьединения");
                WriteLine("5. Выход.");

                Write("\nВыберите пункт: ");
                mainChoice = MainActions.GetCorrectPositiveInt(1, 5);
                // Clear console.
                Clear();

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
                                            SwitchCaseActions.AddStudent();
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
                                            ourChoice3 = MainActions.GetCorrectPositiveInt(1, 4);

                                            switch (ourChoice3)
                                            {
                                                case 1:
                                                    {
                                                        ListOfStudents.ShowAll();
                                                    }
                                                    break;

                                                case 2:
                                                    {
                                                        ListOfStudents.ShowAll(UniversityElements.Faculty);
                                                    }
                                                    break;

                                                case 3:
                                                    {
                                                        ListOfStudents.ShowAll(UniversityElements.Specialty);
                                                    }
                                                    break;

                                                case 4:
                                                    {
                                                        ListOfStudents.ShowAll(UniversityElements.Group);
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
                                            // Increase or Decrease.
                                            SwitchCaseActions.SortAndShowStudents();
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
                                            // Increase or Decrease.
                                            SwitchCaseActions.SortAndShowEmployees();                                        
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
                                WriteLine("4. Показать информацию о книге");
                                WriteLine("5. В главное меню");
                                WriteLine("6. Выход.");

                                Write("Ввод : ");
                                thirdChoice = MainActions.GetCorrectPositiveInt(1, 6);

                                switch (thirdChoice)
                                {
                                    case 1:
                                        {
                                            SwitchCaseActions.AddBook(listOfBooks);
                                        }
                                        break;

                                    case 2:
                                        {
                                            SwitchCaseActions.RemoveBook(listOfBooks);
                                        }
                                        break;

                                    case 3:
                                        {
                                            SwitchCaseActions.ShowAllBooks(listOfBooks);
                                        }
                                        break;

                                    case 4:
                                        {
                                            SwitchCaseActions.ShowBookInfo(listOfBooks);
                                        }
                                        break;

                                    case 5:
                                        {
                                            goto GotoMainMenu;
                                        }
                                    //break;

                                    case 6:
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

                            while (true)
                            {                                
                                int fourthChoice;

                                WriteLine("Association Menu : ");
                                WriteLine("1. Добавить обьединнение");
                                WriteLine("2. Удалить обьединение");
                                WriteLine("3. Вывести все обьединения");
                                WriteLine("4. Вывести участников обьединения ");
                                WriteLine("5. Вернуться в главное меню");
                                WriteLine("6. Выход.");

                                Write("\nВыберите пункт: ");

                                fourthChoice = MainActions.GetCorrectPositiveInt(1, 6);

                                switch (fourthChoice)
                                {
                                    case 1:
                                        {                                            
                                            SwitchCaseActions.AddAssocation();
                                        }
                                        break;

                                    case 2:
                                        {
                                            SwitchCaseActions.RemoveAssociation();   
                                        }
                                        break;

                                    case 3:
                                        {
                                            ListOfAssociations.ShowAll();
                                        }
                                        break;

                                    case 4:
                                        {
                                            SwitchCaseActions.ShowAssociationParticipants();
                                        }
                                        break;

                                    case 5:
                                        {
                                            goto GotoMainMenu;
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
                        break;

                    case 5:
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
            
        }
    }
}
