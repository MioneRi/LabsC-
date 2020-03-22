using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;  
//using static System.Console; 

namespace Laba1          
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("\t\t\t----------------Программа матричный калькулятор-----------------");

            Console.WriteLine("Доступные действия :  ");

            while (true)
            {
                Console.WriteLine("1. Умножение на число ");
                Console.WriteLine("2. Транспонирование ");
                Console.WriteLine("3. Сумма (разность) ");
                Console.WriteLine("4. Умножение матриц ");
                Console.WriteLine("5. Нахождение определителя ");
                Console.WriteLine("6. Нахождение обратной матрицы ");
                Console.WriteLine("7. Выход ");

                Console.Write("\nВыберите пункт : ");
                int Choise;

                try
                {
                    Choise = Convert.ToInt32(Console.ReadLine()); ;
                }
                catch (Exception)
                {
                    Console.WriteLine("You enter smth wrong!\n");
                    break;
                }

                int Strings;
                int Columns;

                switch (Choise)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите размеры матрицы ");
                            Console.Write("Кол-во строк : ");

                            try
                            {
                                Strings = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }
                            if (Strings < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }


                            Console.Write("Кол-во столбцов : ");

                            try
                            {
                                Columns = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }
                            if (Columns < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            Console.Write("Множитель : ");
                            int Factor;

                            try
                            {
                                Factor = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            ArrayActions Action1 = new ArrayActions();
                            int[,] MyArray = new int[Strings, Columns];
                            int Test = Action1.InputArray(MyArray, Strings, Columns);

                            if (Test == 1)
                            {
                                break;
                            }


                            Action1.MultiplyArray(MyArray, Strings, Columns, Factor);

                            Console.WriteLine("\nОтвет : ");
                            Action1.PrintArray(MyArray, Strings, Columns);

                            Console.Write("\n");

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Введите размеры матрицы ");

                            Console.Write("Кол-во строк : ");
                            try
                            {
                                Strings = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }
                            if (Strings < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            Console.Write("Кол-во столбцов : ");
                            try
                            {
                                Columns = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }
                            if (Columns < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            ArrayActions Action2 = new ArrayActions();
                            int[,] MyArray2 = new int[Strings, Columns];
                            int Test = Action2.InputArray(MyArray2, Strings, Columns);
                            if (Test == 1)
                            {
                                break;
                            }

                            Console.WriteLine("Ответ : ");
                            Action2.TransposeArray(MyArray2, Strings, Columns);

                            Console.Write("\n");

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Введите размеры матриц          \t ***(ввод производится один раз тк они соразмерны)");

                            Console.Write("Кол-во строк : ");
                            try
                            {
                                Strings = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }
                            if (Strings < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            Console.Write("Кол-во столбцов : ");
                            try
                            {
                                Columns = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }
                            if (Columns < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            ArrayActions Action3 = new ArrayActions();
                            int[,] MyArray3 = new int[Strings, Columns];
                            int[,] Myarray33 = new int[Strings, Columns];

                            Console.Write("Ввод матрицы 1: \n");
                            int Test = Action3.InputArray(MyArray3, Strings, Columns);
                            if (Test == 1)
                            {
                                break;
                            }

                            Console.WriteLine("Ввод матрицы 2: \n");
                            Test = Action3.InputArray(Myarray33, Strings, Columns);
                            if (Test == 1)
                            {
                                break;
                            }

                            Console.Write("Введите знак (+ or -) : ");
                            char Sign;
                            try
                            {
                                Sign = Convert.ToChar(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            while (Sign != '+' && Sign != '-')
                            {
                                Console.Write("You enter smth wrong! \n  Try again : ");
                                Sign = Convert.ToChar(Console.ReadLine());
                            }

                            Console.WriteLine("Ответ : ");
                            Action3.SumArrays(MyArray3, Myarray33, Strings, Columns, Sign);

                            Console.Write("\n");

                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Введите размеры матрицы 1 ");

                            Console.Write("Кол-во строк : ");
                            int Strings1;
                            try
                            {
                                Strings1 = Convert.ToInt32(Console.ReadLine()); ;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!\n");
                                break;
                            }
                            if (Strings1 == 0 || Strings1 == -1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            Console.Write("Кол-во столбцов : ");
                            int Columns1;
                            try
                            {
                                Columns1 = Convert.ToInt32(Console.ReadLine()); ;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!\n");
                                break;
                            }
                            if (Columns1 < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            Console.WriteLine("Введите размеры матрицы 2 ");

                            int Strings2 = Columns1;                   //STRINGS2 = COLUMNS
                            Console.Write("Кол-во строк : {0}           \t***(тоже что и кол-во строк 2ой матрицы)\n", Strings2);

                            Console.Write("Кол-во столбцов : ");
                            int Columns2;
                            try
                            {
                                Columns2 = Convert.ToInt32(Console.ReadLine()); ;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!\n");
                                break;
                            }
                            if (Columns2 < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            ArrayActions Action4 = new ArrayActions();
                            int[,] Array1 = new int[Strings1, Columns1];
                            int[,] Array2 = new int[Strings2, Columns2];

                            Console.WriteLine("Ввод матрицы 1 : ");
                            int Test;
                            Test = Action4.InputArray(Array1, Strings1, Columns1);
                            if (Test == 1)
                            {
                                break;
                            }

                            Console.WriteLine("Ввод матрицы 2 : ");
                            Test = Action4.InputArray(Array2, Strings2, Columns2);
                            if (Test == 1)
                            {
                                break;
                            }

                            Console.WriteLine("Ответ : ");
                            Action4.MultiplyArrays(Array1, Array2, Strings1, Columns1, Strings2, Columns2);

                            Console.Write("\n");
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Введите размеры матрицы ");

                            Console.Write("Кол-во строк : ");
                            try
                            {
                                Strings = Convert.ToInt32(Console.ReadLine()); ;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!\n");
                                break;
                            }
                            if (Strings < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            Columns = Strings;
                            Console.Write("Кол-во столбцов : {0}       \t ***(the same as amount of Strings)\n", Columns);

                            ArrayActions Action5 = new ArrayActions();
                            int[,] MyArray = new int[Strings, Columns];
                            int Test = Action5.InputArray(MyArray, Strings, Columns);
                            if (Test == 1)
                            {
                                break;
                            }

                            int Answer = Action5.DeterminantArray(MyArray, Strings, Strings, -1);

                            Console.WriteLine("Ответ : {0}", Answer);
                            Console.Write("\n");

                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Введите размеры матрицы ");

                            Console.Write("Кол-во строк : ");
                            try
                            {
                                Strings = Convert.ToInt32(Console.ReadLine()); ;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You enter smth wrong!\n");
                                break;
                            }
                            if (Strings < 1)
                            {
                                Console.WriteLine("You enter smth wrong!");
                                break;
                            }

                            Columns = Strings;
                            Console.Write("Кол-во столбцов : {0}       \t ***(the same as amount of Strings)\n", Columns);

                            ArrayActions Action6 = new ArrayActions();
                            int[,] MyArray = new int[Strings, Columns];
                            int Test = Action6.InputArray(MyArray, Strings, Columns);
                            if (Test == 1)
                            {
                                break;
                            }

                            int OurDeterminant = Action6.DeterminantArray(MyArray, Strings, Strings, -1);

                            if (OurDeterminant == 0)
                            {
                                Console.WriteLine("Обратной матрицы не существует! (Определитель = 0)");
                            }
                            else
                            {
                                Console.WriteLine("Ответ : ");

                                Action6.ReverseArray(MyArray, Strings);

                                Console.Write("\n");
                            }
                        }

                        break;
                    case 7:
                        {
                            Console.Write("\n");
                            return 0;
                        }
                    default:
                        {
                            Console.WriteLine("You enter smth wrong! \n");
                        }
                        break;

                }



            }



            return 0;
        }
    }
}
