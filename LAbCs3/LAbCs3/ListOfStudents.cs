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
        void Add(Student ourStudent); //по умолчанию public
        void Remove(Student ourStudent);
        void ShowAll();
    }


    class ListOfStudents : IJournal
    {        
        public static List<Student> journal = new List<Student>();

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

        public void Add(Student ourStudent)
        {
            journal.Add(ourStudent);
        }

        public void Remove(Student ourStudent)
        {
            journal.Remove(ourStudent);

        }

        public void ShowAll()
        {
            for (int i = 0; i < Person.TotalAmountOfPeople; i++)
            {
                MainActions.ShowStudentInfo(journal[i]);
            }

        }

        public void SortByProgress() //убывание
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
