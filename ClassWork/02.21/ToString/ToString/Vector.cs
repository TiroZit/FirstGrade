using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToString
{
    class Vector
    {
        protected int _x;
        protected int _y;
        public Vector()
        {
            _x = 0;
            _y = 0;
        }
        public Vector(int x, int y);
        {

        }
        //Применим полиморфизм.
        //Переопределим унаследованный метод.
        public overrude string ToString()
    {
        return string.Format("")
    }
    }
}
