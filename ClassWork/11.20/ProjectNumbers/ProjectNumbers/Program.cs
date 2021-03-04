using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNumbers
{
    class Program
    {
        static void PrintArray(int[] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("{0} ", m[i]);
            }
            Console.WriteLine();
        }
        static void ProofOfConcept()
        {
            int number = 1945;
            while (number != 0)
            {
                int digit = number % 10;
                Console.WriteLine(number);
                Console.WriteLine(digit);
                number = number / 10;
                Console.ReadLine();
            }
            Console.WriteLine("Готово!");
        }
        //Считать кол-во цифр в числе
        static int CountDigits(int number)
        {
            int counter = 0;
            while (number != 0)
            {
                number = number / 10;
                counter++;
            }
            return counter;
        }
        //Разбивать число на цифры
        static int[] SplitToDigits(int number)
        {
            //Выделим память для массива с цифрами
            int counter = CountDigits(number);
            int[] digits = new int[counter];
            //Получение и сохранение цифр
            while (number != 0)
            {
                counter--;
                int digit = number % 10;
                number = number / 10;
                //Цифру закинуть в массив
                digits[counter] = digit;
            }
            return digits;
        }
        //В массиве значения в обратном порядке
        static void ReverseArray(int[] m)
        {
            int last = m.Length - 1;
            for (int i = 0; i < m.Length / 2; i++)
            {
                int temp = m[i];
                m[i] = m[last];
                m[last] = temp;
                last--;
            }
        }
        //Преобразуем цифры в число
        static long DigitsToNumber (int[]digits)
        {
            int last = digits.Length - 1;
            long total = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                int digit = digits[last-i];
                int category = i;//Индекс - разряд числа
                long number = digit * (long)Math.Pow(10, category);//Цифру умножаем на 10 в степени разряда
                total += number;
            }
            return total;
        }
        static void Main(string[] args)
        {
            int number = 1945;
            int[] digits = SplitToDigits(number);
            PrintArray(digits);
            ReverseArray(digits);
            PrintArray(digits);
            //Преобразуем цифры в число
            digits = new int[] { 9, 5, 4, 6, 2 };
            long result = DigitsToNumber(digits);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
