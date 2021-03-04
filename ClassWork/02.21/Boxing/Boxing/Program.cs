using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
    class Program
    {
        //2. Транспортировка:
        static void DoSomething(object obj)
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Demo Boxing");
            int n = 1200;
            string message = "Hello";
            Random rnd = new Random();
            //Упакуем.
            //1. Хранение:
            object[] array = { n, message, rnd };
            object obj1 = n;
            object obj2 = (object)message;
            //2. Транспортировка:
            DoSomething(n);
            DoSomething(message);
            DoSomething(rnd);
            DoSomething(1243);
            //Unboxing/Распаковка:
            int count = (int)array[0];
            Console.WriteLine("Complete:");
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
