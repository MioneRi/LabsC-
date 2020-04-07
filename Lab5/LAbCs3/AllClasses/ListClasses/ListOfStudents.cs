using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    public interface IJournal
    {
        // Для хорошего foreach().
        public IEnumerator GetEnumerator();

        // По умолчанию public.
        static void Add(object obj) { } 

        static void Remove(object obj) { }

        static void ShowAll() { }
    }


    class ListOfStudents : IJournal
    {
        // There's a "contains" method.
        public static List<Student> journal = new List<Student>();

        public static int ActualNumberOfStudents
        {
            get { return journal.Count; }
        }    
        
        public static int Length
        {
            get { return journal.Count; }
        }

        // My indexator. 
        // Удобно для сортировки обьектов по значениям и при дальнейшем выводе на экран.
        public Student this[int index]
        {
            get { return (Student)journal[index]; }

            set 
            {
                if ( index > -1 && ( value is Student ))
                {
                    journal.Add(value);
                }                
            }
        }

        // For correct work "foreach" construction.
        public IEnumerator GetEnumerator()
        {
            foreach (object o in journal)
            {
                // "yield" let us know about the last index that was used.
                yield return o; 
            }
        }

        public static void Add(object ourObject)
        {
            Student ourStudent = ourObject as Student; 

            if (ourStudent != null)
            {
                journal.Add(ourStudent);
            }
            // Если передан обьект другого типа.
            else
            {
                throw new Exception("Параметр должен быть типа Student.");
            }

        }

        public static void Remove(object ourObject)
        {
            Student ourStudent = ourObject as Student;           

            if (ourStudent != null)
            {
                journal.Remove(ourStudent);
            }
            // Если передан обьект другого типа.
            else
            {
                throw new Exception("Параметр должен быть типа Student.");
            }

        }

        public static void ShowAll()
        {            
            bool flag = false;

            WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия, Успеваемость)");

            for (int i = 0; i < ActualNumberOfStudents; i++)
            {
                if (journal[i] != null)
                {
                    MainActions.ShowStudentInfo(journal[i]);
                    flag = true;
                }                
            }

            MainActions.NoExistMassege(flag, TypeOfPerson.Student, AmountOfPersons.Several);
        }

        // По убыванию.
        public static void SortByProgress()
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
