using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo01
{
    class Program
    {
        static void PringGreetings(string name)
        {
            Console.WriteLine("Привет");
            Console.WriteLine("Как дела?");
        }
        static void Main(string[] args)
        {
            PringGreetings("Вася");
            Console.WriteLine("Привет");
            Console.WriteLine("Как дела?");
            int a = 100, b = 10;
            int c = a / b;
            string petya = "петя";
            PringGreetings(petya);
            Console.WriteLine("Привет Вася");
            Console.WriteLine("Как дела Петя?");
            Console.WriteLine("Введите ваше имя");
            string name = Console.ReadLine();
            PringGreetings(name);
            a = 100;
            b = 10;
            c = a / b;
            Console.ReadLine();
        }
    }
}
