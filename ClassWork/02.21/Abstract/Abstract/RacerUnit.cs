using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    abstract class RacerUnit
    {
        protected int x;
        protected int y;
        protected int vx;
        protected int vy;
        public RacerUnit()
        {
            this.x = 1;
            this.y = 15;
        }
        public abstract void Move();
        public abstract void Draw();
    }
}
