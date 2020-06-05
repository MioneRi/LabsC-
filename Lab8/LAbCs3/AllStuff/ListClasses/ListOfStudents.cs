using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    class ListOfStudents : IJournal, IEnumerable
    {

        private static List<Student> journal = new List<Student>(); //there's a "contains" method

        // That's just a property with "get" only.
        public static List<Student> Journal => journal;

        public static int ActualNumberOfStudents => journal.Count;

        public static int Length => journal.Count;        

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
            //foreach (object o in journal)
            //{
            //    // "yield" let us know about the last index that was used.
            //    yield return o; 
            //}

            return journal.GetEnumerator();
        }

        // Use some event here.
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

            MainActions.NoExistMassege(flag, TypeOfEntity.Student, AmountOfEntities.Several);
        }

        public static void ShowAll(UniversityElements ourElement)
        {
            bool flag = false;
            string ourFaculty;
            int ourFacultyNumber;

            ourFaculty = MainActions.ChoosenFaculty(out ourFacultyNumber);            

            switch (ourElement)
            {
                case UniversityElements.Faculty:
                    {
                        WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия)");

                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                        {
                            if (ourStudent.Faculty == ourFaculty)
                            {
                                MainActions.ShowStudentInfo(ourStudent);
                                flag = true;
                            }
                        }                        
                    }
                    break;

                case UniversityElements.Specialty:
                    {
                        string ourSpecialty;

                        ourSpecialty = MainActions.ChoosenSpecialty(ourFacultyNumber);

                        WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия)");

                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                        {
                            if (ourStudent.Specialty == ourSpecialty)
                            {
                                MainActions.ShowStudentInfo(ourStudent);
                                flag = true;
                            }
                        }
                    }
                    break;

                case UniversityElements.Group:
                    {
                        string ourSpecialty;
                        string ourGroup;
                        int ourYear;

                        ourSpecialty = MainActions.ChoosenSpecialty(ourFacultyNumber);

                        ourYear = MainActions.ChoosenYear();

                        ourGroup = MainActions.ChoosenGroup();

                        WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия)");

                        foreach (Student ourStudent in ListOfStudents.journal.ToArray())
                        {
                            if (ourStudent.Group == ourGroup && ourStudent.Year == ourYear && ourStudent.Specialty == ourSpecialty)
                            {
                                MainActions.ShowStudentInfo(ourStudent);
                                flag = true;
                            }
                        }

                    }
                    break;
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Student, AmountOfEntities.Several);

        }

        public static void ShowAll(Student[] ourStudentArray)
        {
            bool flag = false;

            WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия, Успеваемость)");

            for (int i = 0; i < ActualNumberOfStudents; i++)
            {
                if (ourStudentArray[i] != null)
                {
                    MainActions.ShowStudentInfo(ourStudentArray[i]);
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Student, AmountOfEntities.Several);
        }

        // По убыванию
        public static void SortByProgress(TypeOfSort ourTypeOfSort)
        {
            Student[] ourStudentArray = journal.ToArray();

            Array.Sort(ourStudentArray);

            switch (ourTypeOfSort)
            {
                case TypeOfSort.Increase:
                    {

                    }
                    break;

                case TypeOfSort.Decrease:
                    {
                        Array.Reverse(ourStudentArray);
                    }
                    break;
            }

            ShowAll(ourStudentArray);

        }


    }

}
