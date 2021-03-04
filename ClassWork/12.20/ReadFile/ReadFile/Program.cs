using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"d:\Visual Studio 2010\error404.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            /*string st = sr.ReadLine();
            Console.WriteLine(st);*/
            while (! sr.EndOfStream)
            {
                string st = sr.ReadLine();
                Console.WriteLine(st);
                Console.ReadKey(true);
            }
            sr.Close();
            fs.Close();
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
