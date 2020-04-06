using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    public abstract class Employee : Person
    {
        protected int jobPositionNumber;
        //private string typeOfEmployee;
        protected string jobPosition; //должность
        private int workExperience;
        private int salary;
        private string formOfRemuneration; //форма оплаты труда
        private static int totalAmountOfEmployees = 0; //общее кол-во работников

        public Employee()
        {
            totalAmountOfEmployees++;
        }

        private static string[] typesOfEmployees = new string[] { "Преподаватель", "Администрация", "Другие сотрудники" };

        private static string[][] jobPositions = new string[][]
        {
            new string[] { "Лектор", "Лаборант" },
            new string[] { "Декан", "Зам. декана по уч. работе", "Зам. декана по воспитательной работе",
                           "Зам. декана по методической работе", "Секретарь деканата"},
            new string[] { "Вахтер", "Уборщик", "Охранник", "Сторож", "Слесарь-сантехник", "Бухгалтер", "Контролер-кассир" }
        };

        public int WorkExperience
        {
            get { return workExperience; }
        }

        public int Salary
        {
            get { return salary; }
        }

        public string FormOfRemuneration
        {
            get { return formOfRemuneration; }
        }

        public static int TotalAmountOfEmployees
        {
            get { return totalAmountOfEmployees; }
        }

        public string JobPosition
        {
            get { return jobPosition; }
        }

        public static string[] TypesOfEmployees
        {
            get { return typesOfEmployees; }
        }

        public static string[][] JobsPositions
        {
            get { return jobPositions; }
        }

        public override void SetInfo()
        {
            base.SetInfo();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Write("Стаж работы : ");
            workExperience = MainActions.GetCorrectPositiveInt(200);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Write("Заработная плата($) : ");
            salary = MainActions.GetCorrectPositiveInt();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            WriteLine("Форма оплаты труда : ");
            formOfRemuneration = MainActions.ChoosenFormOfRemuneration();

        }

        public override void ShowInfo()
        {
            base.ShowInfo();

            WriteLine("Стаж работы " + WorkExperience);
            WriteLine("Заработная плата($) : " + Salary);
            WriteLine("Форма оплаты труда : " + FormOfRemuneration);
            WriteLine("Должность : " + jobPosition);

        }       

        public int CompareTo(object obj) //можно использовать метод "Sort(array)" для массива
        {
            Employee ourEmployee = obj as Employee; //пробуем перевести обьект к типу Student

            if (ourEmployee != null)
            {
                if (this.WorkExperience < ourEmployee.WorkExperience)
                {
                    return -1;
                }
                else if (this.WorkExperience > ourEmployee.WorkExperience)
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
                throw new Exception("Параметр должен быть типа Employee.");
            }

        }

        public static bool operator >(Employee firstEmployee, Employee secondEmployee)
        {
            return (firstEmployee.WorkExperience > secondEmployee.WorkExperience);
        }
        public static bool operator <(Employee firstEmployee, Employee secondEmployee)
        {
            return (firstEmployee.WorkExperience < secondEmployee.WorkExperience);
        }


    }
}
