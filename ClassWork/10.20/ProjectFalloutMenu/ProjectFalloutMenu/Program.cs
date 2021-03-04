using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectFalloutMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string stateDoor = "closed";
            string stateCamera = "open";
            //Командное меню
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0}, {1}", stateDoor, stateCamera);
                Console.WriteLine("1. a");
                Console.WriteLine("2. b");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1": stateDoor="открыть"; break;
                    case "2": Console.WriteLine("vkl"); break;
                    default:
                        break;
                }
                Thread.Sleep(500);
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}
