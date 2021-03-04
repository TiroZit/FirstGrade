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
            Console.WriteLine("Китайский год");
            Console.Write("Введите год >");
            int year = int.Parse(Console.ReadLine());// 2020..2032
            int yearStartPoint = 2020; // Крыса

            string nameOfYear = "";

            if (year >= 2020)
            {
                int difference = year - yearStartPoint;
                int remains = difference % 12;            
                switch (remains)
                {
                    case 0: nameOfYear = "крыса"; break;
                    case 1: nameOfYear = "бык"; break;
                    case 2: nameOfYear = "тигр"; break;
                    case 3: nameOfYear = "кролик"; break;
                    case 4: nameOfYear = "дракон"; break;
                    case 5: nameOfYear = "змея"; break;
                    case 6: nameOfYear = "лошадь"; break;
                    case 7: nameOfYear = "овца"; break;
                    case 8: nameOfYear = "обезьяна"; break;
                    case 9: nameOfYear = "петух"; break;
                    case 10: nameOfYear = "собака"; break;
                    case 11: nameOfYear = "свинья"; break;
                }
            } else
            {
                int difference = yearStartPoint - year;//2020-2019
                int remains = difference % 12;
                switch (remains)
                {
                    case 0: nameOfYear = "крыса"; break;
                    case 1: nameOfYear = "свинья"; break;
                    case 2: nameOfYear = "собака"; break;
                    case 3: nameOfYear = "петух"; break;
                    case 4: nameOfYear = "обезьяна"; break;
                    case 5: nameOfYear = "овца"; break;
                    case 6: nameOfYear = "лошадь"; break;
                    case 7: nameOfYear = "змея"; break;
                    case 8: nameOfYear = "дракон"; break;
                    case 9: nameOfYear = "кролик"; break;
                    case 10: nameOfYear = "тигр"; break;
                    case 11: nameOfYear = "бык"; break;   
                }
            }

            
            Console.WriteLine("Год {0} => Животное \"{1}\" ", year, nameOfYear);

            Console.ReadLine();
        }
    }
}
