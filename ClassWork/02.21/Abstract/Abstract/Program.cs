using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo Abstract");
            RacerUnit[] units new RacerUnit[]
            {
                new Car(), new Baloon(), new Plane()
            };
            RacerUnit unit = new Plane();
            while (true)
            {
                foreach (RacerUnit u in units)
                {
                    unit.Draw();
                    unit.Move();
                }
                Console.ReadKey(true);
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}
