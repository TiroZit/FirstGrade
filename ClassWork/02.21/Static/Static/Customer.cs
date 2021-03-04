using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    class Customer
    {
        //Статическое поле - глобальный счетчик
        protected static int counter = 1;
        //уникальный номер у каждого свой:
        protected int identifier;
        protected string firstname;
        protected string lastname;
        public static int GetQuantity()
        {
            return counter-1;
        }
        public Customer(string name, string lastname)
        {
            this.identifier = counter;
            this.firstname = name;
            this.lastname = lastname;
            counter++;
        }
        public override string ToString()
        {
            //Format - статический метод класса string
            return string.Format($"{firstname}, {lastname}, {identifier}");
        }
    }
}
