using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelOne
{
    class Program
    {
        //Сумма
        static int SummaryArray(int[] m)
        {
            int total = 0;
            for (int i = 0; i < m.Length; i++)
            {
                total += m[1];
            }
            return total;
        }
        static int FindMinInArray(int[]m)
        {
            int min = m[0];
            for (int i = 1; i < m.Length; i++)
            {
                if (m[i]<min)
                {
                    min = m[i];
                }
            }
            return min;
        }
        //Найти индекс минимума в массиве
        static int FindIndexMinInArray(int[]m)
        {
            int index = 0;
            int min = m[0];
            for (int i = 1; i < m.Length; i++)
            {
                if (m[i] < min)
                {
                    min = m[i];
                    index = i;
                }
            }
            return index;
        }
        //Найти индекс заданного элемента
        static int IndexOf(int[]m, int search)
        {
            int index = -1;
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] == search)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static void FillArrayRandom(int[] m)
        {
            //1) Генератор псевдо случайных чисел.
            Random rnd = new Random();
            for (int i = 0; i < m.Length; i++)
            {
                //закидываем в ячейку массива
                //Next - следующее случайное число
                m[i] = rnd.Next(1, 100);
            }
        }
        static void PrintArray(string name, int[] m)
        {
            Console.Write("{0}: ", name);
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("{0}, ", m[i]);
                /*
                if (i != m.Length - 1)
                    Console.Write("{0}, ", m[i]);
                else
                    Console.WriteLine("{0}.", m[i]);
                */
            }
            Console.Write("{0}.", m[m.Length - 1]);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] mas1 = new int[15];
            FillArrayRandom(mas1);
            PrintArray("mas1", mas1);
            int sum = SummaryArray(mas1);
            Console.WriteLine(sum);
            int min = FindMinInArray(mas1);
            Console.WriteLine(min);
            int indexMin = FindIndexMinInArray(mas1);
            Console.WriteLine(indexMin);
            int search = 12;
            int index = IndexOf(mas1, 12);
            if (index < 0)
            {
                Console.WriteLine("Число {0} в массиве не найдено", search);
            }
            else
            {
                Console.WriteLine("Число {0} найдено, индекс {1}",search, index);
            }
            Console.WriteLine(index);
            Console.ReadLine();
        }
    }
}
