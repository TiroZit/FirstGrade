using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String03
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = "Ivanov Ivan Ivanovich";
            Console.WriteLine(st);
            Console.WriteLine("1. Разбить строку на кусочки");
            string[] fio = st.Split(' ');
            Console.WriteLine("Фамилия = {0}", fio[0]);
            Console.WriteLine("Имя = {0}", fio[1]);
            Console.WriteLine("Отчество = {0}", fio[2]);

            string record = "GeForce RTX 3090, 150000";
            //Нам нужно - отдельно название и цену
            string[] parts = record.Split(',');
            string productName = parts[0];
            int price = int.Parse(parts[1]);
            Console.WriteLine("Продукт = {0}", productName);
            Console.WriteLine("Цена = {0}", price);

            Console.WriteLine("2. Join");
            string[] mass = { "one", "two", "three", "four", "five" };
            string result = string.Join("-", mass);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
