using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. IO = Input-Output
using System.IO;


namespace CreateFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. Файловый поток
            FileStream fs = new FileStream(@"d:\Visual Studio 2010\error404.txt", FileMode.Create);
            //3. Создаем файловый “писатель”
            StreamWriter sw = new StreamWriter(fs);
            //4. 
            for (int i = 0; i < 10000; i++)
            {
                sw.WriteLine("Строка {0}", i);
            }
            sw.Close();
            fs.Close();
            Console.WriteLine("Complete!");
            Console.ReadLine();
        }
    }
}
