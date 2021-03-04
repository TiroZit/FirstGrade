using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Car : RacerUnit
    {
        public Car() : base()
        {

        }
        public override void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("12");
        }
        public override void Move()
        {
            
        }
    }
}
