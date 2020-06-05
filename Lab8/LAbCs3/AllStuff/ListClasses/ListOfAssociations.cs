using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    class ListOfAssociations : IJournal, IEnumerable
    {
        private static ArrayList journal = new ArrayList();

        public static ArrayList Journal => journal;

        public static int AmountOfAssotiations => Journal.Count;

        public static int Length => Journal.Count;

        // My indexator. 
        // Удобно для сортировки обьектов по значениям и при дальнейшем выводе на экран.
        public object this[int index]
        {
            get { return (object)journal[index]; }

            set
            {
                if (index > -1 && (value is object))
                {
                    journal.Add(value);
                }

            }

        }

        // For correct work "foreach" construction.
        public IEnumerator GetEnumerator()
        {
            return journal.GetEnumerator();
        }

        public static void Add(object ourObject)
        {
            journal.Add(ourObject);                
        }

        public static void Remove(object ourObject)
        {
            journal.Remove(ourObject);
        }

        public static void ShowAll()
            //where U : ScientificAssociation<Student>
            //where V : ScientificAssociation<Employee>
        {
            bool flag = false;

            WriteLine("( AssociationID, TypeOfAssociation, Title, StudyArea )");

            foreach (object ourAssotiation in Journal)
            {
                if (ourAssotiation is ScientificAssociation<Student>)
                {
                    ScientificAssociation<Student> tmp = ourAssotiation as ScientificAssociation<Student>;
                    tmp.ShowInfo();
                    flag = true;
                }
                else if (ourAssotiation is ScientificAssociation<Employee>)
                {
                    ScientificAssociation<Employee> tmp = ourAssotiation as ScientificAssociation<Employee>;
                    tmp.ShowInfo();
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Association, AmountOfEntities.Several);
        }

    }
}
