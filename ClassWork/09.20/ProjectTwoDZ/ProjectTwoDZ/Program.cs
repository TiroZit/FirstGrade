using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTwoDZ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region//Свернуть код
            Console.WriteLine("Введите 1 число");
            string st = Console.ReadLine();
            int a = int.Parse(st);
            Console.WriteLine("Введите 2 число");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите 3 число");
            int c = int.Parse(Console.ReadLine());
            #endregion
            //Способ 1
            //Попарное сравнение (самый быстрый, длинный, сложный)
            int min = 0, mid = 0, max = 0;
            /*
            if (a > b)
            {
                if (b > c)
                {
                    min = c;
                    mid = b;
                    max = a;
                }
                else//b<c
                {
                    if (c < a)
                    {
                        min = b;
                        mid = c;
                        max = a;
                    }
                    else//c>a
                    {
                        min = b;
                        mid = a;
                        max = c;
                    }
                }
            }
            else //a<b
            {
                if (a > c)
                {
                    min = c;
                    mid = a;
                    max = b;
                }
                else//a<c
                {
                    min = a;
                    if (b < c)
                    {
                        mid = b;
                        max = c;
                    }
                    else//b>c
                    {
                        mid = c;
                        max = b;
                    }
                }
            }
            */
            //Способ 2 (легкий, работает медленно, идиотский)
            /*
            if (a > b && b > c)
            {
                min = c;
                mid = b;
                max = a;
            }
            if (a > c && c > b)
            {
                min = b;
                mid = c;
                max = a;
            }
            if (c > a && a > b)
            {
                min = b;
                mid = c;
                max = a;
            }
            */
            /*
            //Способ 3 (короткий, работает быстро)
            min = a; mid = b; max = c;
            //Алгоритм SWAP (обмен значений)
            if (mid < min)
            {
                int t = min;
                min = mid;
                mid = t;
            }
            if (max < min) 
            {
                int t = min;
                min = max;
                max = t;
            }
            if (max < mid) 
            {
                int t = mid;
                mid = max;
                max = t;
            }
            */
            //Способ 4 (самый короткий, работает медленно)
            min = Math.Min(Math.Min(a, b), Math.Min(b, c));
            max = Math.Max(Math.Max(a, b), Math.Max(b, c));
            mid = (a + b + c) - (min + max);
            Console.WriteLine("По возрастанию: {0}, {1}, {2}", min, mid, max);
            Console.WriteLine("По убыванию: {0}, {1}, {2}", max, mid, min);
            Console.ReadLine();
        }
    }
}
