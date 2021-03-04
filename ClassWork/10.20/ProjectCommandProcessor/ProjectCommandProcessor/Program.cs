using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCommandProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int i = 1;
            for (; ; )//бесконечный цикл
            {
                i += 2;
                Console.Write(i);
            }
            */
            bool isWorking = true;
            while (true)
            {
                Console.Write("введите команду ");//1) приглашение - command promt
                string command = Console.ReadLine();//2) чтение
                switch (command)//3) анализ и выполнение команды
                {
                    case "hi": Console.WriteLine("qq"); break;
                    case "bye": Console.WriteLine("bb"); break;
                    case "cc": Console.Clear(); break;
                    case "exit": isWorking = false; break;
                    default: Console.WriteLine("Error 404"); break;
                }
                if (isWorking == false) break;
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
