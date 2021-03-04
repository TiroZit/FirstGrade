using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Plane : RacerUnit
    {
        public Plane() : base()
        {
            vx = 1;
            vy = -1;
        }
        public override void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("112");
        }

        public override void Move()
        {
            x += vx;
            y += vy;
        }
    }
}
