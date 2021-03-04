using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo03Usefull
{
    class Program
    {
        static int InputNumber(string subject)
        {
            Console.Write("введите {0} > ", subject);
            string st = Console.ReadLine();
            int a = int.Parse(st);
            return a;
        }
        static void Main(string[] args)
        {
            int a = InputNumber("a");
            int b = InputNumber("b");
            int cathetus = InputNumber("катет");
            int angle = InputNumber("угол");
            /*
            Console.Write("введите a");
            string st = Console.ReadLine();
            int a = int.Parse(st);
            Console.Write("введите b");
            st = Console.ReadLine();
            int b = int.Parse(st);
            */
        }
    }
}
