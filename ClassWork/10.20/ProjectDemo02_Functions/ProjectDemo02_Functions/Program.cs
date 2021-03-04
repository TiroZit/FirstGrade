using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo02_Functions
{
    class Program
    {
        static int SumSquares(int x, int y)
        {
            int square1 = x * x;
            int square2 = y * y;
            int result = square1 + square2;
        }
        static void Main(string[] args)
        {
            int a = 3;
            int b = 4;
            int s1 = SumSquares(a, b);
            Console.WriteLine("получилось = {0}",s1);
            int c = 7;
            int d = 6;
            int s2 = SumSquares(c, d);
            Console.WriteLine("получилось = {0}",s2);
            Console.ReadLine();
        }
    }
}
