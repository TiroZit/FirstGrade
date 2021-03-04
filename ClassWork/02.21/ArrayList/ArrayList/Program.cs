using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo ArrayList");
            ArrayList list = new ArrayList();
            //Добавляем элементы
            list.Add(10);
            list.Add(15);
            list.AddRange(new[] { 25, 30, 35, 40 });
            list.Add("Добавили строку");
            list.Add(3.123);//Boxing
            list.Add((object)33);
            //Вставка
            list.Insert(2, 177);
            //Remove
            list.Remove(35);
            //Выводим
            foreach (object item in list)
            {
                Console.WriteLine(item);
            }
            //Извлечение элементов из списка
            string number = (string)list[list.Count - 3];//unboxing
            Console.ReadLine();
        }
    }
}
