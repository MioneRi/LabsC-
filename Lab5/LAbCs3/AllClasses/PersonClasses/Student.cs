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
        private static int totalAmountOfStudents = 0; //общее кол-во студентов
        private int year; //курс
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

        public static int TotalAmountOfStudents
        {
            get { return totalAmountOfStudents; }
        }

        public int Progress
        {
            get { return progress; }
            set { progress = value; }
        }

        public override void SetInfo()
        {
            base.SetInfo();   // Calling the base class SetInfo method;

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
            base.ShowInfo(); // Calling the base class SetInfo method;

            WriteLine("Факультет : " + Faculty);
            WriteLine("Специальность : " + Specialty);
            WriteLine("Курс : " + Year);
            WriteLine("Группа : " + Group);
            WriteLine("Успеваемость : " + Progress);
        }

        public int CompareTo(object obj) //можно использовать метод "Sort(array)" для массива
        {
            Student ourStudent = obj as Student; //пробуем перевести обьект к типу Student

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
            else //если передан обьект другого типа
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