using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    public class SwitchCaseActions
    {
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

            foreach (Employee ourEmployee in ListOfEmployees.journal.ToArray()) //that's possible if List -> Array ... but for my new class it isn't necc
            {
                if (ourInputID == ourEmployee.PersonID)
                {
                    ListOfEmployees.Remove(ourEmployee);
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfPerson.Employee, AmountOfPersons.One);
        }

        public static void RemoveStudent()
        {
            bool flag = false;
            int ourInputID;

            Write("Введите ID студента : ");
            ourInputID = MainActions.GetCorrectPositiveInt();

            foreach (Student ourStudent in ListOfStudents.journal.ToArray()) //that's possible if List -> Array ... but for my new class it isn't necc
            {
                if (ourInputID == ourStudent.PersonID)
                {
                    ListOfStudents.Remove(ourStudent);
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfPerson.Student, AmountOfPersons.One);
        }

        public static void FindStudentByID()
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

            MainActions.NoExistMassege(flag, TypeOfPerson.Student, AmountOfPersons.One);
        }

        public static void FindEmployeeByID()
        {
            bool flag = false;
            int ourID;

            Write("Введите ID сотрудника: ");
            ourID = MainActions.GetCorrectPositiveInt();

            foreach (Employee ourEmployee in ListOfEmployees.journal.ToArray())
            {
                if (ourEmployee.PersonID == ourID)
                {
                    ourEmployee.ShowInfo();
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfPerson.Employee, AmountOfPersons.One);
        }


    }
}
