using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    public abstract class Employee : Person, IComparable
    {
        protected int jobPositionNumber;
        //private string typeOfEmployee;
        // Должность.
        protected string jobPosition; 
        private int workExperience;
        private int salary;
        // Форма оплаты труда.
        private string formOfRemuneration;
        // Общее кол-во работников.
        private static int totalAmountOfEmployees = 0; 

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

        public int WorkExperience => workExperience;

        public int Salary => salary;

        public string FormOfRemuneration => formOfRemuneration;

        public static int TotalAmountOfEmployees => totalAmountOfEmployees;

        public string JobPosition => jobPosition;

        public static string[] TypesOfEmployees => typesOfEmployees;

        public static string[][] JobsPositions => jobPositions;        

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

        // Можно использовать метод "Sort(array)" для массива.
        public int CompareTo(object obj) 
        {
            // Пробуем перевести обьект к типу Student.
            Employee ourEmployee = obj as Employee; 

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
            // Если передан обьект другого типа.
            else
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
