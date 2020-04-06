using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    class ListOfEmployees : IJournal
    {
        public static List<Employee> journal = new List<Employee>();

        public static int ActualNumberOfEmployees
        {
            get { return journal.Count; }
        }

        public static int Length
        {
            get { return journal.Count; }
        }

        public Employee this[int index] //my indexator //удобно для сортировки обьектов по значениям и при дальнецшем выводе на экран
        {
            get { return (Employee)journal[index]; }

            set
            {
                if (index > -1 && (value is Employee))
                {
                    journal.Add(value);
                }

            }

        }

        public IEnumerator GetEnumerator() //for correct work "foreach" construction!
        {
            foreach (object o in journal)
            {
                yield return o; //"yield" let us know about the last index that was used
            }
        }

        public static void Add(object ourObject)
        {
            Employee ourEmployee = ourObject as Employee;

            if (ourEmployee != null)
            {
                journal.Add(ourEmployee);
            }
            else
            {
                throw new Exception("Параметр должен быть типа Employee.");
            }
            
        }

        public static void Remove(object ourObject)
        {
            Employee ourEmployee = ourObject as Employee;

            if (ourEmployee != null)
            {
                journal.Remove(ourEmployee);
            }
            else
            {
                throw new Exception("Параметр должен быть типа Employee.");
            }

        }

        public static void ShowAll()
        {
            bool flag = false;

            WriteLine(" (ID работника, Имя, Фамилия, Должность, Стаж) ");

            for (int i = 0; i < ActualNumberOfEmployees; i++)
            {
                if (journal[i] != null)
                {
                    MainActions.ShowEmployeeInfo(journal[i]);
                    flag = true;
                }                
            }

            MainActions.NoExistMassege(flag, TypeOfPerson.Employee, AmountOfPersons.Several);

        }

        public static void SortByWorkExperience() //убывание
        {
            var length = journal.Count;

            for (int i = 1; i < length; i++)
            {
                for (int j = 0; j < length - i; j++)
                {
                    if (journal[j] < journal[j + 1])
                    {

                        var temp = journal[j];
                        journal[j] = journal[j + 1];
                        journal[j + 1] = temp;

                    }
                }
            }

        }


    }
}
