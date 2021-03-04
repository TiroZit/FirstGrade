using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Algorythm
    {
        //Самый простой алгоритм обмена данных 
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        //перегрузка
        /*
        public static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }*/
        //Boxing
        public static void Swap(ref object a, ref object b)
        {
            object temp = a;
            a = b;
            b = temp;
        }

    }
}
