using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOverload
{
    class Program
    {
        //
        static int Summ(int a, int b)
        //Сигнатура метода:
        {
            int s = a + b;
            return s;
        }
        static int Summ(int a, string b)
        //Сигнатура метода:
        {
            int s = a + int.Parse(b);
            return s;
        }
        static int Summ(int a, int b, int c)
        //Сигнатура метода:
        {
            int s = a + b + c;
            return s;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Summ(4, 6));
            Console.WriteLine(Summ(4, 6, 3));
            Console.ReadLine();
        }
    }
}
