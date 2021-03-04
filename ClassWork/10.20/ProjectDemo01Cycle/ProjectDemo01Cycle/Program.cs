using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo01Cycle
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Введите количество досок для покраски");
            int numberOfActions = int.Parse(Console.ReadLine());
            int i = 0;//Счетчик цикла, проинициализировали.
            while (i < numberOfActions)//Заголовок цикла с условием.
            {//тело цикла.
                Console.WriteLine("Кисточку в ведро с краской");
                Console.WriteLine("Кисточкой проводим по доске сверху вниз");
                Console.WriteLine("Смещаемся вправо к след доске");
                i++;//Приращение, шаг счетчика (+1 за раз).
                Console.WriteLine("1 доска покрашена");
                //Console.ReadLine();
            }
            */
            //1 Вариант
            Console.WriteLine("Сотрудников");
            int quantity = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantity; i++)
            {
                int total = 0;
                Console.WriteLine("Зп сотрудника: ");
                int salary = int.Parse(Console.ReadLine());
                total += salary;
                Console.WriteLine("Общая сумма: {0}", total);
                Console.WriteLine("Средняя зп: {0}",total / 10);
            }
            //2 Вариант
            for (int i = 0; i < 10; i += 2)
            {
                Console.WriteLine(i + 1);
            }
            Console.WriteLine();
            //3 Вариант (меняем счетчик, условие, шаг)
            for (int i = 10; i >= 0; i -= 1)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
