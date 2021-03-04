using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class Program
    {
        static void FillFrame(int left, int top, int width, int height)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
            Console.Write("╔");
            Console.SetCursorPosition(left + width, top);
            Console.Write("╗");
            Console.SetCursorPosition(left, top + height);
            Console.Write("╚");
            Console.SetCursorPosition(left + width, top + height);
            Console.Write("╝");
            string horizontal = new string('═', width - 1);
            string spaces = new string(' ', width - 1);
            // нижнюю и верхнюю горизонталь
            Console.SetCursorPosition(left + 1, top);
            Console.Write(horizontal);
            Console.SetCursorPosition(left + 1, top + height);
            Console.Write(horizontal);
            // левая и правая вертикаль
            for (int i = 1; i < height; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write("║");
                Console.Write(spaces);
                Console.Write("║");
            }
        }
        //Текстовый редактор
        static string MyReadLine()
        {
            string text = "";
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            int x = 0;//положение курсора внутри текста
            bool isWorking = true;
            //Бесконечный цикл для ввода букв
            while (isWorking)
            {
                //Выставляем курсор в нужную позицию
                Console.SetCursorPosition(startX + x, startY);
                //Считываем информацию о нажатой клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                //Букву с кнопки добавляем в текст
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < text.Length)
                        {
                            x++;
                        }
                        break;
                        //Стираем справа от курсора
                    case ConsoleKey.Delete:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x, 1);
                        }
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
                    //Стирать последний символ
                    case ConsoleKey.Backspace:
                        if (text.Length>0)
                        {
                            text = text.Remove(x - 1, 1);
                            x--;
                        }
                        break;
                    default:
                        if (!char.IsControl(info.KeyChar) || char.IsSurrogate(info.KeyChar))
                        {
                            //text += info.KeyChar;
                            text = text.Insert(x, info.KeyChar + "");
                            x++;
                        }
                        break;
                }
                Console.SetCursorPosition(startX, startY);
                //Печатаем текущий текст
                Console.Write(text + " ");
            }
            //Переход на строку ниже
            Console.SetCursorPosition(0, startY + 1);
            return text;
        }
        //Версия с ограничением по длине текста
        static string MyReadLineLimit(int maxLen)
        {
            string text = "";
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            int x = 0;//положение курсора внутри текста
            bool isWorking = true;
            //Бесконечный цикл для ввода букв
            while (isWorking)
            {
                //Выставляем курсор в нужную позицию
                Console.SetCursorPosition(startX + x, startY);
                //Считываем информацию о нажатой клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                //Букву с кнопки добавляем в текст
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < text.Length)
                        {
                            x++;
                        }
                        break;
                    //Стираем справа от курсора
                    case ConsoleKey.Delete:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x, 1);
                        }
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
                    //Стирать последний символ
                    case ConsoleKey.Backspace:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x - 1, 1);
                            x--;
                        }
                        break;
                    default:
                        if (!char.IsControl(info.KeyChar) || char.IsSurrogate(info.KeyChar))
                        {
                            if (text.Length < maxLen)
                            {
                                //text += info.KeyChar;
                                text = text.Insert(x, info.KeyChar + "");
                                x++;
                            }
                        }
                        break;
                }
                Console.SetCursorPosition(startX, startY);
                //Печатаем текущий текст
                Console.Write(text + " ");
            }
            //Переход на строку ниже
            Console.SetCursorPosition(0, startY + 1);
            return text;
        }
        static string MyReadPassword(int maxLen)
        {
            string text = "";
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            int x = 0;//положение курсора внутри текста
            bool isWorking = true;
            //Бесконечный цикл для ввода букв
            while (isWorking)
            {
                //Выставляем курсор в нужную позицию
                Console.SetCursorPosition(startX + x, startY);
                //Считываем информацию о нажатой клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                //Букву с кнопки добавляем в текст
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < text.Length)
                        {
                            x++;
                        }
                        break;
                    //Стираем справа от курсора
                    case ConsoleKey.Delete:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x, 1);
                        }
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
                    //Стирать последний символ
                    case ConsoleKey.Backspace:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x - 1, 1);
                            x--;
                        }
                        break;
                    default:
                        if (!char.IsControl(info.KeyChar) || char.IsSurrogate(info.KeyChar))
                        {
                            if (text.Length < maxLen)
                            {
                                //text += info.KeyChar;
                                text = text.Insert(x, info.KeyChar + "");
                                x++;
                            }
                        }
                        break;
                }
                Console.SetCursorPosition(startX, startY);
                //Печатаем текущий текст
                string stars = new string('*', text.Length);
                Console.Write(stars + " ");
            }
            //Переход на строку ниже
            Console.SetCursorPosition(0, startY + 1);
            return text;
        }
        static string MyTextEdit(int maxLen, string text)
        {
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            int x = 0;//положение курсора внутри текста
            bool isWorking = true;
            //Бесконечный цикл для ввода букв
            while (isWorking)
            {
                Console.SetCursorPosition(startX, startY);
                //Печатаем текущий текст
                Console.Write(text + " ");
                //Выставляем курсор в нужную позицию
                Console.SetCursorPosition(startX + x, startY);
                //Считываем информацию о нажатой клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                //Букву с кнопки добавляем в текст
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < text.Length)
                        {
                            x++;
                        }
                        break;
                    //Стираем справа от курсора
                    case ConsoleKey.Delete:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x, 1);
                        }
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
                    //Стирать последний символ
                    case ConsoleKey.Backspace:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x - 1, 1);
                            x--;
                        }
                        break;
                    default:
                        if (!char.IsControl(info.KeyChar) || char.IsSurrogate(info.KeyChar))
                        {
                            if (text.Length < maxLen)
                            {
                                //text += info.KeyChar;
                                text = text.Insert(x, info.KeyChar + "");
                                x++;
                            }
                        }
                        break;
                }
            }
            //Переход на строку ниже
            Console.SetCursorPosition(0, startY + 1);
            return text;
        }
        static long MyInputNumber(int maxLen)
        {
            string text = "";
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            int x = 0;//положение курсора внутри текста
            bool isWorking = true;
            //Бесконечный цикл для ввода букв
            while (isWorking)
            {
                //Выставляем курсор в нужную позицию
                Console.SetCursorPosition(startX + x, startY);
                //Считываем информацию о нажатой клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                //Букву с кнопки добавляем в текст
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < text.Length)
                        {
                            x++;
                        }
                        break;
                    //Стираем справа от курсора
                    case ConsoleKey.Delete:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x, 1);
                        }
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
                    //Стирать последний символ
                    case ConsoleKey.Backspace:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x - 1, 1);
                            x--;
                        }
                        break;
                    default:
                        if (!char.IsControl(info.KeyChar) || char.IsSurrogate(info.KeyChar))
                        {
                            if (text.Length < maxLen)
                            {
                                //Фильтр который пропускает только цифры
                                if (char.IsDigit(info.KeyChar))
                                {
                                    text = text.Insert(x, info.KeyChar + "");
                                    x++;
                                }
                                //text += info.KeyChar;
                            }
                        }
                        break;
                }
                Console.SetCursorPosition(startX, startY);
                //Печатаем текущий текст
                Console.Write(text + " ");
            }
            //Переход на строку ниже
            Console.SetCursorPosition(0, startY + 1);
            if (text == "") text = "0";
            return long.Parse(text);
        }

        static void Main(string[] args)
        {
            /*long number = MyInputNumber(10);
            Console.WriteLine(number);

            FillFrame(10, 5, 25, 2);
            Console.SetCursorPosition(11, 5);
            Console.Write("Изменить Фамилию");
            Console.SetCursorPosition(11, 6);
            string text = MyTextEdit(16,"Петрав");
            Console.WriteLine("Вы ввели текст: {0}", text);
            Console.ReadLine();*/
            string value = "88005553366";
            for (int i = 4; i < value.Length; i+=5)
            {
                value = value.Insert(i, "-");
            }
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
