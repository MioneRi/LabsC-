using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ArrayActions
{


    public int InputArray(int[,] myArray, int strings, int columns)
    {

        for (int i = 0; i < strings; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write("a[{0}][{1}] = ", i, j);
                try
                {
                    myArray[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("You enter smth wrong!");
                    return 1;
                }
            }
        }
        return 0;

    }

    public void PrintArray(int[,] myArray, int strings, int columns)
    {

        for (int i = 0; i < strings; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(myArray[i, j] + "    ");
            }
            Console.Write("\n");
        }

    }

    public void PrintArray(double[,] myArray, int strings, int columns)
    {

        for (int i = 0; i < strings; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(myArray[i, j] + "    ");
            }
            Console.Write("\n");
        }

    }

    public void MultiplyArray(int[,] myArray, int strings, int columns, int factor)
    {

        for (int i = 0; i < strings; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                myArray[i, j] *= factor;
            }
        }

    }

    public void TransposeArray(int[,] myArray, int strings, int columns)
    {
        int[,] transporedArray = new int[columns, strings];

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < strings; j++)
            {
                transporedArray[i, j] = myArray[j, i];
            }
        }

        PrintArray(transporedArray, columns, strings);

    }

    public void SumArrays(int[,] array1, int[,] array2, int strings, int columns, char sign)
    {
        int[,] resultArray = new int[strings, columns];

        if (sign == '+')
        {
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultArray[i, j] = array1[i, j] + array2[i, j];
                }
            }
        }
        else if (sign == '-')
        {
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultArray[i, j] = array1[i, j] - array2[i, j];
                }
            }
        }

        PrintArray(resultArray, strings, columns);
    }

    public void MultiplyArrays(int[,] Array1, int[,] Array2, int Strings1, int Columns1, int Strings2, int Columns2)
    {
        int[,] ResultArray = new int[Strings1, Columns2];

        for (int i = 0; i < Strings1; i++)
        {
            for (int j = 0; j < Columns2; j++)
            {
                for (int v = 0; v < Columns1; v++)
                {
                    ResultArray[i, j] += Array1[i, v] * Array2[v, j];
                }
            }
        }

        PrintArray(ResultArray, Strings1, Columns2);
    }

    public int DeterminantArray(int[,] Array, int Size, int FlagSize, int Ji) 
    {
        int[,] NewArray = new int[Size, Size];

        if (Size == 1)
        {
            return Array[0, 0];
        }

        if (Size < FlagSize)
        {
            int PastSize = Size + 1;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0, Pastj = 0; Pastj < PastSize; Pastj++)
                {
                    if (Pastj == Ji)
                    {
                        continue;
                    }
                    else
                    {
                        NewArray[i, j] = Array[i + 1, Pastj];
                        j++;
                    }

                }
            }
        }
        else if (Size == FlagSize)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    NewArray[i, j] = Array[i, j];
                }
            }
        }

        int Answer = 0;

        if (Size == 2)
        {
            Answer = NewArray[0, 0] * NewArray[1, 1] - NewArray[0, 1] * NewArray[1, 0];
        }
        else
        {
            int i = 0;
            for (int j = 0; j < Size; j++)
            {
                Answer += NewArray[i, j] * (int)Math.Pow(-1, i + j) * DeterminantArray(NewArray, Size - 1, Size, j);
            }
        }

        return Answer;
    }

    public void ReverseArray(int[,] Array, int Size)
    {
        if (Size == 1)
        {
            Console.WriteLine(Math.Pow(Array[0, 0], -1));
            return;
        }

        int[,] NewArray = new int[Size, Size]; //Матрица алгебраических дополнений

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                int[,] TempArray = new int[Size - 1, Size - 1];

                for (int i1 = 0, PastI = 0; PastI < Size; PastI++)
                {
                    if (PastI != i)
                    {
                        for (int j1 = 0, PastJ = 0; PastJ < Size; PastJ++)
                        {
                            if (PastJ != j)
                            {
                                TempArray[i1, j1] = Array[PastI, PastJ];

                                j1++;
                            }

                        }

                        i1++;

                    }
               
                }

                NewArray[i, j] = (int)Math.Pow(-1, i+j) * DeterminantArray(TempArray,Size-1,Size-1,-1);

            }

        }

        //Сейчас нужно будет транспонировать матрицу алгеб. доп. (тоесть NewArray записать в AnswerArray)

        double[,] AnswerArray = new double[Size, Size];  //Транспонированная матрица от матрицы NewArray
        int OurDeterminant = DeterminantArray(Array, Size, Size, -1);

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                AnswerArray[i, j] = (double)NewArray[j, i];
                AnswerArray[i, j] /= (double)OurDeterminant;  //Делим каждый член на Определитель исходной матр.
            }
        }

        PrintArray(AnswerArray, Size, Size);

    }




}


