using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArray
{
    class Program
    {
        //Генератор случайных чисел
        static void FillRandom2dArray(int[,] m)
        {
            //два вложенных цикла
            //1. Внешний цикл - обычно по строчкам
            for (int i = 0; i < m.GetLength(0); i++)
            {
                //2. Внутренний цикл - обычно по столбцам
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    //i-я строка, j-я столбец
                    m[i, j] = rnd.Next(0, 100);
                }
                Console.WriteLine();//После строки - переход
            }
        }
        //Печатает двумерный массив.
        static void Print2dArray(int[,]m)
        {
            //два вложенных цикла
            //1. Внешний цикл - обычно по строчкам
            for (int i = 0; i < m.GetLength(0); i++)
            {
                //2. Внутренний цикл - обычно по столбцам
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    //i-я строка, j-я столбец
                    Console.Write("{0:d2} ", m[i,j]);
                }
                Console.WriteLine();//После строки - переход
            }
        }
        static void Main(string[] args)
        {
            int[,] table = new int[4, 6]
            {
                {1, 1, 1, 1, 1, 1 },
                {2, 2, 2, 2, 2, 2 },
                {3, 3, 3, 3, 3, 3 },
                {4, 4, 4, 4, 4, 4 }
            };
            Print2dArray(table);

            FillRandom2dArray(table);
            Print2dArray(table);

            Console.ReadLine();
        }
    }
}
