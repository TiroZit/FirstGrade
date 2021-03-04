using System;

namespace HomeworkArrayLVL2
{
    /*
     * Авдеев Н. Р. ПИ-124
     * 
     * 1. Вставка элемента в массив
     * 2. Удаления элемента из массива
     * 3. Слияние двух массивов 
     * 4. Копирование элементов из массива в другой массив
     * 5. Вставка в массив Другого массива
     * 6. Удаление из массива группы элементов
    */
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
        static void Main(string[] args)
        {
            //1. Добавленяет 20 во 2 позицию
            int[] m1 = {1, 2, 3, 4, 5, 6, 7};
            Array.Resize(ref m, m.Length + 1);
            m[2] = 20;
            PrintArray(m1);
            
            //5. Добавляет другой массив в конец
            int[] m5 = {1, 2, 3, 4, 5, 6, 7};
            Array.Resize(ref m5, m5.Length + 3);
            m5[8] = 8;
            m5[9] = 9;
            m5[10] = 10;
            PrintArray(m5);

            //2. Удаляет элемент из 2 позиции
            int[] m2 = {1, 2, 3, 4, 5, 6, 7};
            for (int i = 0, j = 0; j < m2.Length && i < m2.Length - 1; j++, i++)
            {
                if (m2[i] != m2[2]) m2[i] = m2[j];
                else { m2[i] = m2[j + 1]; ++j; }
            }
            Array.Resize(ref m2, m2.Length - 1);
            PrintArray(m2);
            //6. Удаляет 3 элемента со 2 позиции
            for (int i = 0, j = 0; j < m6.Length && i < m6.Length - 1; ++j, ++i)
            {
                if (m6[i] != m6[2])
                    m6[i] = m6[j];
                else { m6[i] = m6[j]; j += 3; }
            }
            Array.Resize(ref m6, m6.Length - 3);
            PrintArray(m6);
            
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
            int[] a = { 1, 2, 3, 4, 5 };
            int[] m4 = { 0, 0, 0, 0, 0 };
            Array.Copy(a, 1, m, 1, 3);
            PrintArray(m4);
            Console.ReadLine();
            
        }
    }
}
