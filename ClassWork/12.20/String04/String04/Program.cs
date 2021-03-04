using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String04
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names =
            {
                "Петров",
                "Иванов",
                "Сидоров",
                "Иваненко",
                "Сидоровенко"
            };
            string prefix = "Петр";
            Console.WriteLine(prefix+":");
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].StartsWith(prefix))
                {
                    Console.WriteLine(names[i]);
                }
            }
            Console.WriteLine("-------------");
            string suffix = "ов";
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].EndsWith(suffix))
                {
                    Console.WriteLine(names[i]);
                }
            }
            Console.WriteLine("--------------");
            string item = "ро";
            Console.WriteLine("Вхождение '{0}", item);
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Contains(item))
                {
                    Console.WriteLine(names[i]);
                }
            }
            Console.ReadLine();
        }
    }
}
