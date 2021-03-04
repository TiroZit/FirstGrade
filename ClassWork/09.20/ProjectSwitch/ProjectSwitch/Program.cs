using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            int day = int.Parse(Console.ReadLine());
            string dayOfWeek = "";
            switch (day)
            {
                case 1: dayOfWeek = "Пн"; break;
                case 2: dayOfWeek = "Вт"; break;
                case 3: dayOfWeek = "Ср"; break;
                case 4: dayOfWeek = "Чт"; break;
                case 5: dayOfWeek = "Пт"; break;
                case 6: dayOfWeek = "Сб"; break;
                case 7: dayOfWeek = "Вс"; break;
                default: dayOfWeek = "не существует такого дня недели"; break;
            }
            Console.WriteLine(dayOfWeek);
            //Касскадный if
            string nameOfNumber = "";
            if (day == 1)
                nameOfNumber = "один";
            else if (day == 2)
                nameOfNumber = "второй";
            else if (day == 3)
                nameOfNumber = "третий";
            else if (day == 4)
                nameOfNumber = "четвертый";
            else if (day == 5)
                nameOfNumber = "пятый";
            else if (day == 6)
                nameOfNumber = "шестой";
            else if (day == 7)
                nameOfNumber = "седьмой";
            else
                Console.WriteLine("Такого дня недели не существует");//default
            Console.WriteLine(nameOfNumber);
            Console.ReadLine();
            switch (month);
            {
                case 9:
                if (day < 23) zodiac = "Рак";
                else zodiac = "Весы";
                break;
            }
            switch (day)
            {
                case 1: 
                case 2: 
                case 3: 
                case 4: 
                case 5: 
                case 6: 
                case 7: 
                case 8: 
                case 9: 
                case 10: 
                case 11: 
                case 12: 
                case 13: 
                case 14: 
                case 15: 
                case 16: 
                case 17:
                    zodiac = "Рак";
                    break;


            }
        }
    }
}
