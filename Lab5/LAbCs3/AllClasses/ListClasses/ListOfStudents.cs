using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    public interface IJournal
    {
        public IEnumerator GetEnumerator(); //для хорошего foreach()
        static void Add(object obj) { } //по умолчанию public
        static void Remove(object obj) { }
        static void ShowAll() { }
    }


    class ListOfStudents : IJournal
    {        
        public static List<Student> journal = new List<Student>(); //there's a "contains" method

        public static int ActualNumberOfStudents
        {
            get { return journal.Count; }
        }    
        
        public static int Length
        {
            get { return journal.Count; }
        }

        public Student this[int index] //my indexator //удобно для сортировки обьектов по значениям и при дальнецшем выводе на экран
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

        public IEnumerator GetEnumerator() //for correct work "foreach" construction!
        {
            foreach (object o in journal)
            {
                yield return o; //"yield" let us know about the last index that was used
            }
        }

        public static void Add(object ourObject)
        {
            Student ourStudent = ourObject as Student; 

            if (ourStudent != null)
            {
                journal.Add(ourStudent);
            }
            else //если передан обьект другого типа
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
            else //если передан обьект другого типа
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

        public static void SortByProgress() //убывание
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
