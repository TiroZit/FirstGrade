using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteLine/ReadLine - Статические методы.
            Console.WriteLine("Demo Static");
            /* Задача - обеспечить каждому объекту класса Customer
             * Наличие собственного уникального номера / индентификатор.
             */
            Customer kolya = new Customer("Коля", "Николаев");
            Customer tolya = new Customer("Толя", "Николаев");
            Console.WriteLine(kolya);
            Console.WriteLine(tolya);
            Console.WriteLine($"Количество: {Customer.GetQuantity()}");
            Console.ReadLine();
        }
    }
}
