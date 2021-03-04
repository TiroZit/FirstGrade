using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemoEnumerate
{
    class Program
    {
        //Перечисление числовых констант время года
        enum Season { winter, spring, summer, autumn}
        enum DayWeek { monday=1, tuesday=2, wednesday=3, thurday=4, friday=5, saturday, sunday }
        static void Main(string[] args)
        {
            //С константами
            const int winter = 1;
            const int summer = 2;

            const int monday = 1;
            const int wednesday = 3;

            int Today = monday;
            int seasonNow = winter;
            //------------------------
            //С перечислениями
            Season season = Season.winter;
            DayWeek dayweek = DayWeek.monday;
            //Повысилась строгость
            //season = dayweek;
            int number = (int)season;
            //switch дружит с перечислениями
            switch (season)//sw 2 раза таб, se и 2 раза enter
            {
                case Season.winter:
                    Console.WriteLine("Поставить зимнюю резину");
                    break;
                case Season.spring:
                    Console.WriteLine("Поменять масло");
                    break;
                case Season.summer:
                    Console.WriteLine("Поставить ленюю резину");
                    break;
                case Season.autumn:
                    Console.WriteLine("Поменять фильтры");
                    break;
                default:
                    break;
            }
        }
    }
}
