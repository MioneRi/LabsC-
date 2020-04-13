using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LAbCs3
{

    public class Student : Person, IComparable
    {
        // Общее кол-во студентов.
        private static int totalAmountOfStudents = 0;
        // Курс.
        private int year; 
        private string faculty;
        private string specialty;
        private string group;
        private int facultyNumber;
        private int progress;

        public Student()
        {
            totalAmountOfStudents++;
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public string Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }              

        public int Progress
        {
            get { return progress; }
            set { progress = value; }
        }

        public static int TotalAmountOfStudents => totalAmountOfStudents;

        public override void SetInfo()
        {
            // Calling the base class SetInfo method.
            base.SetInfo();   

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -            
            Faculty = MainActions.ChoosenFaculty(out facultyNumber);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -            
            Specialty = MainActions.ChoosenSpecialty(facultyNumber);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Year = MainActions.ChoosenYear();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -       
            Group = MainActions.ChoosenGroup();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -       
            Progress = MainActions.ChoosenProgress();
        }

        public override void ShowInfo()
        {
            // Calling the base class SowInfo method.
            base.ShowInfo(); 

            WriteLine("Факультет : " + Faculty);
            WriteLine("Специальность : " + Specialty);
            WriteLine("Курс : " + Year);
            WriteLine("Группа : " + Group);
            WriteLine("Успеваемость : " + Progress);
        }


        // Можно использовать метод "Sort(array)" для массива.
        public int CompareTo(object obj) 
        {
            // Пробуем перевести обьект к типу Student.
            Student ourStudent = obj as Student; 

            if (ourStudent != null)
            {
                if (this.Progress < ourStudent.Progress)
                {
                    return -1;
                }
                else if (this.Progress > ourStudent.Progress)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Если передан обьект другого типа.
            else
            {
                throw new Exception("Параметр должен быть типа Student.");
            }

        }

        public static bool operator >(Student firstStudent, Student secondStudent)
        {
            return ( firstStudent.Progress > secondStudent.Progress ) ;
        }
        public static bool operator <(Student firstStudent, Student secondStudent)
        {
            return ( firstStudent.Progress < secondStudent.Progress ) ;
        }

    }


}