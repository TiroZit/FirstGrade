using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo ToString");
            Vector a = new Vector();
            Vector b = new Vector(5, 7);
            //Упаковка:
            Console.WriteLine(a);
            Console.WriteLine(b);
            //для переданного объекта - вызов ToString()
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
