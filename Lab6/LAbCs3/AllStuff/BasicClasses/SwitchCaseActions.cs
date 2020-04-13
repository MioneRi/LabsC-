using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Globalization;

namespace LAbCs3
{
    public static class SwitchCaseActions
    {
        public static void AddStudent()
        {
            Student addedStudent = new Student();

            addedStudent.SetInfo();

            ListOfStudents.Add(addedStudent);
        }

        public static void AddEmployee()
        {
            Employee ourEmployee;
            int choice;

            WriteLine("\tВыберите один из возможных вариантов : ");
            WriteLine("\t1. Преподаватель");
            WriteLine("\t2. Администрация");
            WriteLine("\t3. Другое");

            Write("\tВвод : ");
            choice = MainActions.GetCorrectPositiveInt(1, 3);

            switch (choice)
            {
                case 1:
                    {
                        ourEmployee = new Teacher();
                        ourEmployee.SetInfo();
                        ListOfEmployees.Add(ourEmployee);                        
                    }
                    break;

                case 2:
                    {
                        ourEmployee = new Administration();
                        ourEmployee.SetInfo();
                        ListOfEmployees.Add(ourEmployee);                        
                    }
                    break;

                case 3:
                    {
                        ourEmployee = new OtherEmployees();
                        ourEmployee.SetInfo();
                        ListOfEmployees.Add(ourEmployee);
                    }
                    break;
            }

        }

        public static void RemoveEmployee()
        {
            bool flag = false;
            int ourInputID;

            Write("Введите ID сотрудника : ");
            ourInputID = MainActions.GetCorrectPositiveInt();

            foreach (Employee ourEmployee in ListOfEmployees.Journal.ToArray()) //that's possible if List -> Array ... but for my new class it isn't necc
            {
                if (ourInputID == ourEmployee.PersonID)
                {
                    ListOfEmployees.Remove(ourEmployee);
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Employee, AmountOfEntities.One);
        }

        public static void RemoveStudent()
        {
            bool flag = false;
            int ourInputID;

            Write("Введите ID студента : ");
            ourInputID = MainActions.GetCorrectPositiveInt();

            // That's possible if List -> Array ... but for my new class it isn't necessary.
            foreach (Student ourStudent in ListOfStudents.Journal.ToArray()) 
            {
                if (ourInputID == ourStudent.PersonID)
                {
                    ListOfStudents.Remove(ourStudent);
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Student, AmountOfEntities.One);
        }

        public static void FindStudentByID()
        {
            bool flag = false;
            int ourID;

            Write("Введите ID студента: ");
            ourID = MainActions.GetCorrectPositiveInt();

            foreach (Student ourStudent in ListOfStudents.Journal)
            {
                if (ourStudent.PersonID == ourID)
                {
                    ourStudent.ShowInfo();
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Student, AmountOfEntities.One);
        }

        public static void FindEmployeeByID()
        {
            bool flag = false;
            int ourID;

            Write("Введите ID сотрудника: ");
            ourID = MainActions.GetCorrectPositiveInt();

            foreach (Employee ourEmployee in ListOfEmployees.Journal)
            {
                if (ourEmployee.PersonID == ourID)
                {
                    ourEmployee.ShowInfo();
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Employee, AmountOfEntities.One);
        }

        public static void SortAndShowEmployees()
        {
            int ourInput;

            WriteLine("Выберите один из вариантов : ");
            WriteLine("\t1. По возростанию");
            WriteLine("\t2. По убыванию");
            Write("\tВвод : ");

            ourInput = MainActions.GetCorrectPositiveInt(1, 2);

            switch (ourInput)
            {
                case 1:
                    {
                        ListOfEmployees.SortByWorkExperience(TypeOfSort.Increase);
                    }
                    break;

                case 2:
                    {
                        ListOfEmployees.SortByWorkExperience(TypeOfSort.Decrease);
                    }
                    break;
            }
        }

        public static void SortAndShowStudents()
        {
            int ourInput;

            WriteLine("Выберите один из вариантов : ");
            WriteLine("\t1. По возростанию");
            WriteLine("\t2. По убыванию");
            Write("\tВвод : ");

            ourInput = MainActions.GetCorrectPositiveInt(1, 2);

            switch (ourInput)
            {
                case 1:
                    {
                        ListOfStudents.SortByProgress(TypeOfSort.Increase);
                    }
                    break;

                case 2:
                    {
                        ListOfStudents.SortByProgress(TypeOfSort.Decrease);
                    }
                    break;
            }

        }

        public static void AddAssocation()
        {            
            int amountOfParticipants;            

            MainActions.ChoosenTypeOfAssociation(out TypeOfEntity ourTypeOfEntity);

            switch (ourTypeOfEntity)
            {
                case TypeOfEntity.Student:
                    {                        
                        ScientificAssociation<Student> ourAssociation =
                            new ScientificAssociation<Student>(TypeOfEntity.Student);

                        ourAssociation.SetInfo();

                        Write("Кол-во студентов(1-6) : ");

                        amountOfParticipants = MainActions.GetCorrectPositiveInt(1, 6);

                        for (int i = 0; i < amountOfParticipants; i++)
                        {
                            int ourID;
                            bool flag = false;

                            SomeException:
                            Write($"Введите ID студента №{i + 1} : ");

                            ourID = MainActions.GetCorrectPositiveInt();

                            foreach (Student ourStudent in ListOfStudents.Journal)
                            {
                                if (ourID == ourStudent.PersonID)
                                {                                    
                                    ourAssociation.Add(ourStudent);
                                    flag = true;
                                }
                            }

                            MainActions.NoExistMassege(flag, TypeOfEntity.Student, AmountOfEntities.One);

                            if (flag == false)
                            {
                                goto SomeException;
                            }                            
                        }

                        ListOfAssociations.Add(ourAssociation);
                    }
                    break;

                case TypeOfEntity.Employee:
                    {
                        ScientificAssociation<Employee> ourAssociation =
                            new ScientificAssociation<Employee>(TypeOfEntity.Employee);

                        ourAssociation.SetInfo();

                        Write("Кол-во преподавателей(1-6) : ");

                        amountOfParticipants = MainActions.GetCorrectPositiveInt(1, 6);

                        for (int i = 0; i < amountOfParticipants; i++)
                        {
                            int ourID;
                            bool flag = false;

                            SomeException:
                            Write($"Введите ID преподавателя №{i + 1} : ");

                            ourID = MainActions.GetCorrectPositiveInt();

                            foreach (Employee ourEmployee in ListOfEmployees.Journal)
                            {
                                if (ourID == ourEmployee.PersonID)
                                {                                    
                                    ourAssociation.Add(ourEmployee);
                                    flag = true;
                                }
                            }

                            MainActions.NoExistMassege(flag, TypeOfEntity.Employee, AmountOfEntities.One);
                            if (flag == false)
                            {
                                goto SomeException;
                            }

                        }

                        ListOfAssociations.Add(ourAssociation);
                    }
                    break;
            }

        }

        public static void RemoveAssociation()
        {
            int ourID;
            bool flag = false;

            MainActions.ChoosenTypeOfAssociation(out TypeOfEntity ourTypeOfEntity);

            Write("Введите ID обьединения : ");

            ourID = MainActions.GetCorrectPositiveInt();

            switch (ourTypeOfEntity)
            {
                case TypeOfEntity.Student:
                    {
                        foreach (ScientificAssociation<Student> ourAssociation in ListOfAssociations.Journal)
                        {
                            if (ourID == ourAssociation.AssociationID)
                            {
                                ListOfAssociations.Remove(ourAssociation);
                                flag = true;
                            }
                        }
                    }
                    break;

                case TypeOfEntity.Employee:
                    {
                        foreach (ScientificAssociation<Employee> ourAssociation in ListOfAssociations.Journal)
                        {
                            if (ourID == ourAssociation.AssociationID)
                            {
                                ListOfAssociations.Remove(ourAssociation);
                                flag = true;
                            }
                        }
                    }
                    break;
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Association, AmountOfEntities.One);
        }

        public static void ShowAssociationParticipants()
        {
            int ourID;
            bool flag = false;

            MainActions.ChoosenTypeOfAssociation(out TypeOfEntity ourTypeOfEntity);            

            Write("Введите ID обьединения : ");

            ourID = MainActions.GetCorrectPositiveInt();

            switch (ourTypeOfEntity)
            {
                case TypeOfEntity.Student:
                    {

                        foreach (ScientificAssociation<Student> ourAssociation in ListOfAssociations.Journal)
                        {
                            if (ourID == ourAssociation.AssociationID)
                            {
                                ourAssociation.ShowParticipants();
                                flag = true;
                                break;
                            }
                        }

                    }
                    break;

                case TypeOfEntity.Employee:
                    {

                        foreach (ScientificAssociation<Employee> ourAssociation in ListOfAssociations.Journal)
                        {
                            if (ourID == ourAssociation.AssociationID)
                            {
                                ourAssociation.ShowParticipants();
                                flag = true;
                                break;
                            }
                        }

                    }
                    break;
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Association, AmountOfEntities.One);

        }

        public static void AddBook(List<Book> listOfBooks)
        {
            Book newBook = new Book(listOfBooks.Count);

            newBook.SetInfo();

            listOfBooks.Add(newBook);

        }

        public static void RemoveBook(List<Book> listOfBooks)
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

            MainActions.NoExistMassege(flag, TypeOfEntity.Book, AmountOfEntities.One);
        }

        public static void ShowAllBooks(List<Book> listOfBooks)
        {
            bool flag = false;

            WriteLine("( ID, title, year, price($) )");
            foreach (Book ourBook in listOfBooks.ToArray())
            {
                string tmp = ourBook.ToString("Standart", new CultureInfo("en-US"));
                WriteLine(tmp);
            }

            if (listOfBooks.Count != 0)
            {
                flag = true;
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Book, AmountOfEntities.Several);
        }

        public static void ShowBookInfo(List<Book> listOfBooks)
        {
            int ourID;
            bool flag = false;

            Write("Введите ID книги : ");

            ourID = MainActions.GetCorrectPositiveInt();

            foreach (Book ourBook in listOfBooks.ToArray())
            {
                if (ourBook.BookID == ourID)
                {
                    ourBook.ToString("Full", new CultureInfo("en-US"));
                    flag = true;
                    break;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Book, AmountOfEntities.One);
        }

    }
}
