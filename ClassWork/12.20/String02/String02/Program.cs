using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String02
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = "+++Hello world---";
            Console.WriteLine(st);
            Console.WriteLine("1. TrimStart");
            st = st.TrimStart('+');
            Console.WriteLine(st);
            Console.WriteLine("2. TrimEnd");
            st = st.TrimEnd('-');
            Console.WriteLine(st);
            st = "++--+-+-++Text****////////*";
            Console.WriteLine(st);
            Console.WriteLine("3. Trim");
            st = st.Trim('+', '-', '*', '/');
            Console.WriteLine(st);

            string login = "Vasya   ";
            if (login.Trim(' ') == "Vasya")
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.ReadLine();
        }
    }
}
