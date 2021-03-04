using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkLVL2
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
        /// <summary>
        /// Метод
        /// </summary>
        /// <param name="dest">Массив в который вставляем</param>
        /// <param name="pos">Позиция в который вставляем</param>
        /// <param name="source">Источник массива который будем вставлять</param>
        /// <returns></returns>
        static int[] InsertArray(int[]dest, int pos, int[]source, int[]result)
        {

            for (int i = 0; i < pos; i++)
            {
                result[i] = dest[i];
            }
            int shift = pos;
            for (int i = 0; i < source.Length; i++)
            {
                result[i + shift] = source[i];
            }
            int shift1 = pos + source.Length;
            int shift2 = pos;
            //Третий цикл - скопировать остатки первого массива
            for (int i = 0; i < dest.Length - pos; i++)
            {
                result[i + shift] = dest[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            //1. Добавленяет 20 во 2 позицию
            int[] m1 = { 1, 2, 3, 4, 5, 6, 7 };
            Array.Resize(ref m1, m1.Length + 1);
            m1[2] = 20;
            PrintArray(m1);

            //2. Удаляет элемент из 2 позиции
            int[] m2 = { 1, 2, 3, 4, 5, 6, 7 };
            for (int i = 0, j2 = 0; j2 < m2.Length && i < m2.Length - 1; j2++, i++)
            {
                if (m2[i] != m2[2]) m2[i] = m2[j2];
                else { m2[i] = m2[j2 + 1]; j2++; }
            }
            Array.Resize(ref m2, m2.Length - 1);
            PrintArray(m2);

            //3. СЛияние массивов
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 6, 7, 8, 9, 10 };
            int[] m3 = new int[a.Length + b.Length];
            int j = 0;
            for (int i = 0; i < a.Length; i++, j++)
                m3[j] = a[i];
            for (int i = 0; i < b.Length; i++, j++)
                m3[j] = b[i];
            PrintArray(m3);

            //4. Копирование
            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] m4 = { 0, 0, 0, 0, 0 };
            Array.Copy(a, 1, m4, 1, 3);
            PrintArray(m4);
            Console.ReadLine();

            //5. Добавляет другой массив в конец
            int[] m5 = { 1, 2, 3, 4, 5, 6, 7 };
            Array.Resize(ref m5, m5.Length + 3);
            m5[8] = 8;
            m5[9] = 9;
            m5[10] = 10;
            PrintArray(m5);

            //6. Удаляет 3 элемента со 2 позиции
            int[] m6 = { 1, 2, 3, 4, 5, 6, 7 };
            for (int i = 0, j6 = 0; j6 < m6.Length && i < m6.Length - 1; j6++, i++)
            {
                if (m6[i] != m6[2])
                    m6[i] = m6[j6];
                else { m6[i] = m6[j]; j6 += 3; }
            }
            Array.Resize(ref m6, m6.Length - 3);
            PrintArray(m6);
            /*
            int[] mas1 = { 1, 1, 1, 1, 1 };
            int[] mas2 = { 2, 2, 2, 2, 2 };
            int[] mas3 = InsertArray(mas2, 2, mas1);
            PrintArray(mas3);
            Console.ReadLine();
            */
        }
    }
}
