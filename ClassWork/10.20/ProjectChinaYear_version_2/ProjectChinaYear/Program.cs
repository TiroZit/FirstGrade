using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChinaYear
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Применить к новым условиям (для года цвет)
            Console.WriteLine("Китайский год");
            Console.Write("Введите год >");
            int year = int.Parse(Console.ReadLine());// 2020..2032
            int yearStartPoint = 0; // Крыса
            string nameOfYear = "";
            int difference = year - yearStartPoint;
            int remains = difference % 12;
            switch (remains)
            {
                case 0: nameOfYear = "обезьяна"; break;
                case 1: nameOfYear = "петух"; break;
                case 2: nameOfYear = "собака"; break;
                case 3: nameOfYear = "свинья"; break;
                case 4: nameOfYear = "крыса"; break;
                case 5: nameOfYear = "бык"; break;
                case 6: nameOfYear = "тигр"; break;
                case 7: nameOfYear = "кролик"; break;
                case 8: nameOfYear = "дракон"; break;
                case 9: nameOfYear = "змея"; break;
                case 10: nameOfYear = "лошадь"; break;
                case 11: nameOfYear = "овца"; break;

            }
            */
            Console.WriteLine("Китайский год");
            Console.Write("Введите год >");
            int year = int.Parse(Console.ReadLine());// 2020..2032
            int yearStartPoint = 0; // Крыса
            string nameOfYear = "";
            int difference = (year - yearStartPoint) / 2;
            int remains = difference % 5;
            switch (remains)
            {
                case 0: nameOfYear = "белый"; break;
                case 1: nameOfYear = "черный"; break;
                case 2: nameOfYear = "зеленый"; break;
                case 3: nameOfYear = "красный"; break;
                case 4: nameOfYear = "желтый"; break;
            }
            Console.WriteLine(nameOfYear);

            Console.ReadLine();
        }
    }
}
