using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings01
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = "Hlo friend Ivan";
            Console.WriteLine(st);

            Console.WriteLine("1. Вставка (Insert)");
            st = st.Insert(1, "el");
            Console.WriteLine("2. Удаление Remove");
            st = st.Remove(6, 7);
            Console.WriteLine("3. Подстрока SubString");
            st = st.Substring(6, st.Length-6);
            Console.WriteLine("4. Замена Replace");
            st = st.Replace("Ivan", "Petr");
            Console.WriteLine(st);

            Console.ReadLine();
        }
    }
}
