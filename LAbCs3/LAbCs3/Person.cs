using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LAbCs3
{
    public interface IPerson
    {
        //string Name { get; set; }    //стоит ли заносить св-ва в интерфейс?
        //string Surname { get; set; }
        //string Patronymic { get; set; }
        //int Age { get; set; }
        //static int TotalAmountOfPeople { get; }
        //int PersonID { get; }   
        void SetInfo();
        void ShowInfo();
    }

    public class Person : IPerson
    {
        private static int totalAmountOfPeople = 0; //общее кол-во людей
        private string name;
        private string surname;
        private string patronymic; //отчество
        private int age;      
        private int personID;

        public Person()
        {
            totalAmountOfPeople++;
            personID = TotalAmountOfPeople;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public static int TotalAmountOfPeople
        {
            get { return totalAmountOfPeople; }
        }

        public int PersonID
        {
            get { return personID; }
        }

        public virtual void SetInfo()
        {
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Write("Имя : ");
            Name = MainActions.GetCorrectString();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Write("Фамилия : ");
            Surname = MainActions.GetCorrectString();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Write("Отчество : ");
            Patronymic = MainActions.GetCorrectString();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -            
            Write("Возраст : ");
            Age = MainActions.GetCorrectPositiveInt(15, 200);

        }

        public virtual void ShowInfo()
        {
            WriteLine("PersonID : " + PersonID);
            WriteLine("Имя : " + Name);
            WriteLine("Фамилия : " + Surname);
            WriteLine("Отчество : " + Patronymic);
            WriteLine("Возраст : " + Age);
        }



    }
}