using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHalf
{
    class Program
    {
        static void Main(string[] args)
        {
            int left = 1;
            int right = 1000;
            int middle = 0;
            int counter = 0;//Счетчик
            Console.WriteLine("Загадайте число от {0} до {1}", left, right);
            Console.WriteLine("Сейчас угадаем...");
            bool isWorking = true;
            while (isWorking)
            {
                middle = (left + right) / 2;
                Console.WriteLine("1. Ваше число {0}?", middle);
                Console.WriteLine("2. Ваше число больше {0}", middle);
                Console.WriteLine("3. Ваше число меньше {0}", middle);
                Console.WriteLine("Введите номер вашего ответа > ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": isWorking = false; break;//Угадали
                    case "2": left = middle; break;
                    case "3": right = middle; break;
                    default:
                        break;
                }
                Console.Clear();
                counter++;//Счетчик
            }
            Console.WriteLine("Готово, загаданное число: {0}", middle);
            Console.WriteLine("Было выполнено: {0} шагов", counter);
            Console.ReadLine();
        }
    }
}
