using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParameters
{
    class Program
    {
        static void Commsion(int age, int weight)
        {
            Console.WriteLine("Студент {0} лет, {1} кг", age, weight);

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Пример передачи параметров по имени");
            //параметры переданы в правильном виде
            Commsion(18, 65);
            //перепутанные параметры
            Commsion(90, 19);
            //передача в произвольном порядке
            Commsion(weight: 70, age: 20);
            Console.ReadLine();
        }
    }
}
