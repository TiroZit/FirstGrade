using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceBrackets
{
    class Program
    {
        static void PrintBrackets(int[]m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("{0} ", m[i]);
            }
            Console.WriteLine();
        }
        //Прибавляет +1
        //
        static bool IsNextVariantExists(int[] m)
        {
            //1. Выбираем последний элемент массива (индекс).
            int index = m.Length - 1;
            //2. Цикл.
            while (index >= 0)
            {
                //3. Проверяем если 0, то меняем на 1 - закончили
                if (m[index] == 0)//если 0
                {
                    m[index] = 1;//меняем на 1
                    return true;//закончили
                }
                else
                {//Если 1, меняем на 0 и сдвигаемся влево и на шаг 2.
                    m[index] = 0;
                    index--;
                }
            }
            return false;
        }
        static bool IsSyntaxCorrect(int[]m)
        {
            int left = 0, right = 0;
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] == 0) left++;

                else right++;
                //5. Если правая чаша перевесила - выход ложь
                if (right > left) return false;
            }//6. Конец цикла.
            //7. Если чаши в равновесиии - вариант хороший иначе плохой
            if (left == right) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            int[] brackets = new int[8];
            long counter = 0;
            do
            {
                if (IsSyntaxCorrect(brackets))
                {
                    PrintBrackets(brackets);
                    counter++;
                }
            } while (IsNextVariantExists(brackets));
            Console.WriteLine("Готово!");
            Console.WriteLine("Вариантов = {0}", counter);
            Console.ReadLine();
        }
    }
}
