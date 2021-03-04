using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Baloon : RacerUnit
    {
        public Baloon() : base()
        {

        }
        public override void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("0");
        }

        public override void Move()
        {
            y += vy;
        }
    }
}
