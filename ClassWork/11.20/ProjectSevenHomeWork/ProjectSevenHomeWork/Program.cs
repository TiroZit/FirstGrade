using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ProjectSevenHomeWork
{
    class Program
    {
        static double InputNumber(string subject)
        {
            Console.Write("Введите {0} > ", subject);
            string st = Console.ReadLine();
            double a = double.Parse(st);
            return a;
        }
        static void Main(string[] args)
        {
            // Авдеев Никита Романович, ПИ-124.
            while (true)
            {
                double a, b, c, x, y, x1, x2, y1, y2, A, B, C, v1, v2, t1, t2, v, t, p, RadOpOkr, RadVpOkr;
                Console.ForegroundColor = ConsoleColor.Gray;
                //Задачи:
                Console.WriteLine("1. Вычислить, какой процент составляет число А от числа В.");
                Console.WriteLine("2.1 Смешано а1 литров воды температуры t1 с а2 литрами воды температуры t2. Найти объём и температуру образовавшейся жидкости.");
                Console.WriteLine("2.2 Треугольник задан длинами сторон. Найти радиусы вписанной и описанной окружностей.");
                Console.WriteLine("3. Найти (в градусах) все угла треугольника со сторонами а, b, c.");
                Console.WriteLine("4. Даны три действительные числа. Возвести в квадрат те из них, значения которые неотрицательны, и в четвертую степень - отрицательные.");
                Console.WriteLine("5. Определить, принадлежит ли точка с координатами (X,Y) прямоугольнику с координатами (x1, y2), (x1, y2)");
                Console.WriteLine("6. Дана последовательность из N вещественных чисел. Первое число в последовательности нечетное. Найти сумму всех идущих подряд в начале последовательности нечетных чисел. Условный оператор не использовать");
                Console.WriteLine("7. Дано натуральное число n. Выяснить, можно ли представить n! в виде произведения трех последовательных целых чисел. Факториал числа равен n1=1*2*3*…*n).");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        a = InputNumber("A");
                        b = InputNumber("B");
                        double percent = a / b * 100;
                        Console.WriteLine("Ответ > {0}%", percent);
                        Console.ReadLine();
                        break;
                    case "2.1":
                        v1 = InputNumber("v1");
                        t1 = InputNumber("t1");
                        v2 = InputNumber("v2");
                        t2 = InputNumber("t2");
                        v = v1 + v2;
                        t = (v1 * t1 + v2 * t2) / v;
                        Console.WriteLine("Объём и температура = {0}, {1}°", v, t);
                        Console.ReadLine();
                        break;
                    case "2.2":
                        a = InputNumber("A");
                        b = InputNumber("B");
                        c = InputNumber("C");
                        p = (a + b + c) / 2;//полупериметр
                        RadOpOkr = (a * b * c) / (4 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
                        RadVpOkr = Math.Sqrt(((p - a) * (p - b) * (p - c)) / p);
                        Console.WriteLine("Радиус описанной окружности = {0}", RadOpOkr);
                        Console.WriteLine("Радиус вписанной окружности = {0}", RadVpOkr);
                        Console.ReadLine();
                        break;
                    case "3":
                        a = InputNumber("A");
                        b = InputNumber("B");
                        c = InputNumber("C");
                        A = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)) * 180 / Math.PI;
                        B = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)) * 180 / Math.PI;
                        C = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)) * 180 / Math.PI;
                        Console.WriteLine("Угол A = {0}", A);
                        Console.WriteLine("Угол B = {0}", B);
                        Console.WriteLine("Угол C = {0}", C);
                        Console.ReadLine();
                        break;
                    case "4":
                        a = InputNumber("A");
                        b = InputNumber("B");
                        c = InputNumber("C");
                        if (a > 0)
                        {
                            A = Math.Pow(a, 2);
                            Console.WriteLine("Число A неотрицательное = {0}", A);
                        }
                        else
                        {
                            A = Math.Pow(a, 4);
                            Console.WriteLine("Число A отрицательное = {0}", A);
                        }
                        if (b > 0)
                        {
                            B = Math.Pow(b, 2);
                            Console.WriteLine("Число B неотрицательное = {0}", B);
                        }
                        else
                        {
                            B = Math.Pow(b, 4);
                            Console.WriteLine("Число B отрицательное = {0}", B);
                        }
                        if (c > 0)
                        {
                            C = Math.Pow(c, 2);
                            Console.WriteLine("Число C неотрицательное = {0}", C);
                        }
                        else
                        {
                            C = Math.Pow(c, 4);
                            Console.WriteLine("Число C отрицательное = {0}", C);
                        }
                        Console.ReadLine();
                        break;
                    case "5":
                        x = InputNumber("X");
                        y = InputNumber("Y");
                        x1 = InputNumber("X1");
                        x2 = InputNumber("X2");
                        y1 = InputNumber("Y1");
                        y2 = InputNumber("Y2");
                        if ((x >= x2 && x <= x1) || (y >= y2 && y <= y1)) Console.WriteLine("Точка A принадлежит прямоугольнику");
                        else Console.WriteLine("Точка A не принадлежит прямоугольнику");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Write("Введите числа (нечетные и четные) > ");
                        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();//массив, ввод нескольких значений и 
                        int sum = 0, i = 0;
                        for ( ; array[i] % 2 != 0; i++) sum += array[i];
                        Console.WriteLine("Сумма последовательности нечетных чисел = {0}", sum);
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.Write("Введите факториал n! > ");
                        string st = Console.ReadLine();
                        int n = int.Parse(st);
                        long facto = 1;
                        for (i = n; i > 0; --i)
                        {
                            facto *= i;//нахождение факториала
                        }
                        for (i = 3; i < facto; i++)
                        {
                            if (i * (i - 1) * (i - 2) == facto)//множители факториала
                            {
                                Console.WriteLine("Факториал {0}! = {1} = {2} * {3} * {4}", n, facto, i - 2, i - 1, i);
                            }
                        }
                        Console.ReadLine();
                        break;
                    default:
                        Console.Write("Error 404");
                        Thread.Sleep(100);
                        Console.Clear();
                        break;
                }
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}
