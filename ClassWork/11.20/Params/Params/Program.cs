using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Params
{
    class Program
    {
        static int Summ(params int[]m)
        {
            int s = 0;
            for (int i = 0; i < m.Length; i++)
            {
                s += m[i];
            }
            return s;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Summ(2, 3, 5, 6));
            Console.ReadLine();
        }
    }
}
