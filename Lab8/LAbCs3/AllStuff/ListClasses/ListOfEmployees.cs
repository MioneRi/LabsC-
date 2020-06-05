using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    class ListOfEmployees : IJournal, IEnumerable
    {
        private static List<Employee> journal = new List<Employee>();

        // That's just a property with "get" only.
        public static List<Employee> Journal => journal;        
        
        public static int ActualNumberOfEmployees => journal.Count;

        public static int Length => journal.Count;

        // My indexator. 
        // Удобно для сортировки обьектов по значениям и при дальнейшем выводе на экран.
        public Employee this[int index] 
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

        // For correct work "foreach" construction.
        public IEnumerator GetEnumerator()
        {
            //foreach (object o in journal)
            //{
            //    // "yield" let us know about the last index that was used.
            //    yield return o; 
            //}

            return journal.GetEnumerator();
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

            MainActions.NoExistMassege(flag, TypeOfEntity.Employee, AmountOfEntities.Several);

        }
        
        public static void SortByWorkExperience(TypeOfSort ourtypeOfSort) 
        {
            Employee[] ourEmployeeArray = journal.ToArray();

            Array.Sort(ourEmployeeArray);

            switch (ourtypeOfSort)
            {
                case TypeOfSort.Increase:
                    {

                    }
                    break;

                case TypeOfSort.Decrease:
                    {
                        Array.Reverse(ourEmployeeArray);
                    }
                    break;
            }

            ShowAll();
        }


    }
}
