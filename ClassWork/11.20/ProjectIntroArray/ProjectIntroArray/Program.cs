using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIntroArray
{
    class Program
    {
        //Хотим печатать массив на экране
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
            Console.Write("{0}.", m[m.Length-1]);
            Console.WriteLine();
        }
        //Хотим заполнить массив случайными числами
        static void FillArrayRandom(int[] m)
        {
            //1) Генератор псевдо случайных чисел.
            Random rnd = new Random();
            for (int i = 0; i < m.Length; i++)
            {
                //закидываем в ячейку массива
                //Next - следующее случайное число
                m[i] = rnd.Next(1,100);
            }
        }
        //пользователь вводит целое число
        static int UserIntputNumber(string help)
        {
            Console.Write("Введите {0} > ", help);
            string st = Console.ReadLine();
            int a = int.Parse(st);
            return a;
        }
        //Пользователь указывает длину массива\
        static int[] UserCreateArray()
        {
            int len = UserIntputNumber("Длину массива");
            int[] mas = new int[len];
            return mas;
        }
        //Пользователь вводил числа для всех ячеек массива
        static void UserFillArray(int []m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                string help = string.Format("{0}-й элемент", i);
                int number = UserIntputNumber(help);
                m[i] = number;
            }
        }
        static void Main(string[] args)
        {
            int[] mass;//Объявили массив
            mass = new int[5];//Выделили память
            mass[0] = 10;//C# индексация массивов с 0
            mass[1] = 12;
            mass[2] = 14;
            mass[3] = 16;
            mass[4] = 18;// - ошибка index out of bounds
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine("{0} = {1}", i, mass[i]);
            }
            //Иниализация массива:
            int[] mass2 = { 18, 20, 22, 24, 26 };//три шага сразу: объявление, создание и заполнение
            PrintArray("mass2", mass2);

            int[] mass3 = new int[10];
            PrintArray("mass3", mass3);

            int[] mass4 = new int[20];
            FillArrayRandom(mass4);
            PrintArray("mass4",mass4);

            int[] mass5;
            mass5 = UserCreateArray();
            UserFillArray(mass5);
            PrintArray("mass5: ", mass5);
            Console.ReadLine();
        }
    }
}
