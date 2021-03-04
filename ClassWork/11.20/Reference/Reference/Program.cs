using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reference
{
    class Program
    {
        //Версия с передачей параметров по значению
        static void Add_v1(ref int a)
        {
            a += 1;
        }
        //Версия с передачей параметра по ссылке
        static void Add_v2(ref int a)
        {
            a += 1;
        }
        static void Example(int a, int b, out int diff, out int sum)
        {
            diff = a - b;
            sum = a + b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Передача параметров по ссылке");
            int x = 10;
            Console.WriteLine("исходный x={0}", x);
            Add_v1(ref x);
            Console.WriteLine("после Add_v1 x={0}", x);
            Add_v2(ref x);
            Console.WriteLine("после Add_v2 x={0}", x);
            int s, d;
            Example(4, 3, out d, out s);
            Console.WriteLine("разница {0}, сумма {1}", d, s);
            Console.ReadLine();
        }
    }
}
