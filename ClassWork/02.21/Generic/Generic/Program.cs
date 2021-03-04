using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo Generic");
            int q = 7, w = 10;
            Console.WriteLine($"q = {q}, w = {w}");
            AlgoGeneric<int>.Swap(ref q, ref w);
            Console.WriteLine($"q = {q}, w = {w}");

            string q1 = "7", w1 = "10";
            AlgoGeneric<string>.Swap(ref q1, ref w1);
            Console.ReadLine();
        }
    }
}
