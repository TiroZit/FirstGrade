using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Time_Table
{
    /*
       1) Модуль «Директор», позволяет производить:
       Создание/редактирование информации об имеющихся в школе
       а) учителях (ФИО),
       б) предметах,
       в) классах,
       г) кабинетах,
       д) время звонков.

       2) Модуль «Завуч», позволяет
       формировать расписание: по классам на каждый день недели на каждый урок – учитель, предмет и кабинет

       3) Модуль «Информер», позволяет производить: 
       выдачу расписания для выбранного класса на выбранный день недели
       выдачу расписания для выбранного учителя на выбранный день недели
    */
    class Program
    {
        const string fileDirector = @"DataStorage\Director.txt";
        const string fileTeachers = @"DataStorage\Teachers.txt";
        const string fileSubjects = @"DataStorage\Subjects.txt";
        const string fileClasses = @"DataStorage\Classes.txt";
        const string fileCabinets = @"DataStorage\Cabinets.txt";
        const string fileCallTimes = @"DataStorage\Call_times.txt";
        const string fileDays = @"DataStorage\Days.txt";
        const string fileAuth = @"DataStorage\Auth.txt";
        const string fileMonday = @"DataStorage\Monday.txt";
        const string fileTuesday = @"DataStorage\Tuesday.txt";
        const string fileWednesday = @"DataStorage\Wednesday.txt";
        const string fileThursday = @"DataStorage\Thursday.txt";
        const string fileFriday = @"DataStorage\Friday.txt";
        static string[] Director;
        static string[] Teachers;
        static string[] Subjects;
        static string[] Classes;
        static string[] Cabinets;
        static string[] CallTimes;
        static string[] Days;
        static string[] Monday;
        static string[] Tuesday;
        static string[] Wednesday;
        static string[] Thursday;
        static string[] Friday;
        static void LoadFile(string name, ref string[] nameArray)
        {
            using (FileStream fs = new FileStream(name, FileMode.Open))
            {
                StreamReader sr = new StreamReader(fs);
                string st = sr.ReadLine();
                int quantity = int.Parse(st);
                nameArray = new string[quantity];
                for (int i = 0; i < quantity; i++)
                {
                    st = sr.ReadLine();
                    nameArray[i] = st;
                }
            }
        }
        static void LoadAllData()
        {
            LoadFile(fileDirector, ref Director);
            LoadFile(fileClasses, ref Classes);
            LoadFile(fileDays, ref Days);

            LoadFile(fileTeachers, ref Teachers);
            LoadFile(fileSubjects, ref Subjects);
            LoadFile(fileClasses, ref Classes);
            LoadFile(fileCabinets, ref Cabinets);
            LoadFile(fileCallTimes, ref CallTimes);

            LoadFile(fileDays, ref Days);
            LoadFile(fileMonday, ref Monday);
            LoadFile(fileTuesday, ref Tuesday);
            LoadFile(fileWednesday, ref Wednesday);
            LoadFile(fileThursday, ref Thursday);
            LoadFile(fileFriday, ref Friday);
        }
        static void Draw(int x, int y, string[] menu, int active)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < menu.Length; i++)
            {

               Console.SetCursorPosition(x, y + i);
               Console.Write(menu[i]);

            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(x, y + active);
            Console.Write(menu[active]);
        }
        static int Select(int x, int y, string[] menu)
        {
            bool IsWorking = true;
            int active = 0;
            while (IsWorking)
            {
                if (active < 0) active = menu.Length - 1;
                else if (active > menu.Length - 1) active = 0;
                Draw(x, y, menu, active);
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        active--;
                        break;
                    case ConsoleKey.DownArrow:
                        active++;
                        break;
                    case ConsoleKey.Enter:
                        IsWorking = false;
                        break;
                }
            }
            return active;
        }
        static string MyTextEdit(int maxLen, string text)
        {
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            int x = 0;
            bool isWorking = true;
            while (isWorking)
            {
                Console.SetCursorPosition(startX, startY);
                Console.Write(text + " ");
                Console.SetCursorPosition(startX + x, startY);
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.Delete:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x, 1);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (text.Length > 0 && x > 0)
                        {
                            text = text.Remove(x - 1, 1);
                            x--;
                        }
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
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.F1:
                    case ConsoleKey.F2:
                    case ConsoleKey.F3:
                    case ConsoleKey.F4:
                    case ConsoleKey.F5:
                    case ConsoleKey.F6:
                    case ConsoleKey.F7:
                    case ConsoleKey.F8:
                    case ConsoleKey.F9:
                    case ConsoleKey.F10:
                    case ConsoleKey.F11:
                    case ConsoleKey.F12:
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
                    default:
                        if (!char.IsControl(info.KeyChar) ||
                            !char.IsSurrogate(info.KeyChar))
                        {
                            if (text.Length < maxLen)
                            {
                                text = text.Insert(x, info.KeyChar + "");
                                x++;
                            }
                        }
                        break;
                }
            }
            Console.SetCursorPosition(0, startY + 1);
            return text;
        }
        static void EditSelected(int n, string[] nameArray, string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FillFrame(0, 1, 55, 2);
            Console.CursorVisible = true;
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", text);
            string name = nameArray[n];
            Console.SetCursorPosition(1, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            name = MyTextEdit(50, name);
            nameArray[n] = name;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        static void Save(string[] name, string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(name.Length);
            for (int i = 0; i < name.Length; i++)
            {
                sw.WriteLine("{0}", name[i]);
            }
            sw.Close();
            fs.Close();
        }
        static string[] Create(ref string[] dest, string name2)
        {
            string[] massNew = new string[dest.Length + 1];
            for (int i = 0; i < massNew.Length - 3; i++)
            {
                massNew[i] = dest[i];
            }
            massNew[massNew.Length - 4] = name2;
            for (int i = massNew.Length - 3; i < massNew.Length; i++)
            {
                massNew[i] = dest[i - 1];
            }
            dest = massNew;
            return dest;
        }
        static string[] Delete(ref string[] array, int number)
        {
            if (number != array.Length - 1 && number != array.Length - 3 && number != array.Length - 2 && number < array.Length)
            {
                string[] massNew = new string[array.Length - 1];
                for (int i = 0; i < number; i++)
                {
                    massNew[i] = array[i];
                }
                for (int i = number; i < massNew.Length; i++)
                {
                    massNew[i] = array[i + 1];
                }
                array = massNew;
                return array;
            }
            return array;
        }
        static string[] Delete2(ref string[] array, int number)
        {
            string[] massNew = new string[array.Length - 1];
            for (int i = 0; i < number; i++)
            {
                massNew[i] = array[i];
            }
            for (int i = number; i < massNew.Length; i++)
            {
                massNew[i] = array[i + 1];
            }
            array = massNew;
            return array;
        }
        static string MyReadPassword(int maxLen)
        {
            string text = "";
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            int x = 0;
            bool isWorking = true;
            while (isWorking)
            {
                Console.SetCursorPosition(startX + x, startY);
                ConsoleKeyInfo info = Console.ReadKey(true);
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
                    case ConsoleKey.Delete:
                        if (text.Length > 0)
                        {
                            text = text.Remove(x, 1);
                        }
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
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
                                text = text.Insert(x, info.KeyChar + "");
                                x++;
                            }
                        }
                        break;
                }
                Console.SetCursorPosition(startX, startY);
                string stars = new string('*', text.Length);
                Console.Write(stars + " ");
            }
            Console.SetCursorPosition(0, startY + 1);
            return text;
        }
        static int Auth(int current)
        {
            int j = current;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = true;
            Console.Clear();
            string lineText = "";
            using (FileStream fs = new FileStream(fileAuth, FileMode.Open))
            {
                StreamReader sr = new StreamReader(fs);
                if (j == 1)
                {
                    j = 2;
                }
                else if (j == 2)
                {
                    j = 4;
                }
                while (!sr.EndOfStream)
                {
                    lineText += sr.ReadLine();
                    lineText += ",";
                }
                string[] parts = lineText.Split(',');
                FillFrame(41, 10, 20, 6);
                Console.SetCursorPosition(46, 10);
                Console.WriteLine("Авторизация");
                Console.SetCursorPosition(46, 12);
                Console.Write("Логин: ");
                string login = Console.ReadLine();
                Console.SetCursorPosition(46, 14);
                Console.Write("Пароль: ");
                string pass = MyReadPassword(5);
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (login == parts[j])
                    {
                        if (pass == parts[j + 1])
                        {
                            break;
                        }
                        else
                        {
                            current = 3;
                            break;
                        }
                    }
                    else if (i == parts.Length - 1)
                        current = 3;
                }
                Console.Clear();
                return current;

            }
        }
        static void FillFrame(int left, int top, int width, int height)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
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
            Console.SetCursorPosition(left + 1, top);
            Console.Write(horizontal);
            Console.SetCursorPosition(left + 1, top + height);
            Console.Write(horizontal);
            for (int i = 1; i < height; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write("║");
                Console.Write(spaces);
                Console.Write("║");
            }
        }
        static void ModuleDirector()
        {
            FillFrame(0, 0, 14, Director.Length + 1);//46 11
            bool IsWorking = true;
            Console.CursorVisible = false;
            int n = Select(1, 1, Director);
            while (IsWorking)
            {
                switch (n)
                {
                    case 0:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        FillFrame(0, 0, 30, Teachers.Length + 1);//46 11
                        int s = Select(1, 1, Teachers);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        if (s == Teachers.Length - 1)
                        {
                            FillFrame(0, 0, 14, Director.Length + 1);//46 11
                            n = Select(1, 1, Director);
                            Save(Teachers, fileTeachers);
                            break;
                        }
                        else if (s != Teachers.Length - 2 && s != Teachers.Length - 3)
                        {
                            EditSelected(s, Teachers, "Редактируем учителя");
                        }
                        if (s == Teachers.Length - 2)
                        {
                            Console.Clear();
                            Console.CursorVisible = true;
                            FillFrame(0, 1, 30, 2);
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Введите номер учителя (от 0)");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Delete(ref Teachers, Convert.ToInt32(Console.ReadLine()));
                            Console.CursorVisible = false;
                        }
                        if (s == Teachers.Length - 3)
                        {
                            Console.CursorVisible = true;
                            FillFrame(0, 1, 30, 2);
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Создаем учителя");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Create(ref Teachers, Console.ReadLine());
                            Console.Clear();
                            Console.CursorVisible = false;
                        }
                        break;
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        FillFrame(0, 0, 15, Subjects.Length + 1);
                        s = Select(1, 1, Subjects);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        if (s == Subjects.Length - 1)
                        {
                            FillFrame(0, 0, 14, Director.Length + 1);//46 11
                            n = Select(1, 1, Director);
                            Save(Subjects, fileSubjects);
                            break;
                        }
                        else if (s != Subjects.Length - 2) EditSelected(s, Subjects, "Редактируем предмет");
                        if (s == Teachers.Length - 2)
                        {
                            Console.CursorVisible = true;
                            FillFrame(0, 1, 30, 2);
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Введите номер учителя (от 0)");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Delete(ref Teachers, Convert.ToInt32(Console.ReadLine()));
                            Console.CursorVisible = false;
                        }
                        if (s == Subjects.Length - 3)
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Создаем предмет");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Create(ref Subjects, Console.ReadLine());
                            Console.CursorVisible = false;
                        }
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        FillFrame(0, 0, 10, Classes.Length + 1);
                        s = Select(1, 1, Classes);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        if (s == Classes.Length - 1)
                        {
                            FillFrame(0, 0, 14, Director.Length + 1);//46 11
                            n = Select(1, 1, Director);
                            Save(Classes, fileClasses);
                            break;
                        }
                        else if (s != Classes.Length - 2 && s != Classes.Length - 3) EditSelected(s, Classes, "Редактируем класс");
                        if (s == Classes.Length - 3)
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Создаем класс");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Create(ref Classes, Console.ReadLine());
                            Console.CursorVisible = false;
                        }
                        if (s == Classes.Length - 2)
                        {
                            Console.CursorVisible = true;
                            FillFrame(0, 1, 30, 2);
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Введите номер класса (от 0)");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Delete(ref Classes, Convert.ToInt32(Console.ReadLine()));
                            Console.CursorVisible = false;
                        }
                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        FillFrame(0, 0, 10, Cabinets.Length + 1);
                        s = Select(1, 1, Cabinets);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        if (s == Cabinets.Length - 1)
                        {
                            FillFrame(0, 0, 14, Director.Length + 1);//46 11
                            n = Select(1, 1, Director);
                            Save(Cabinets, fileCabinets);
                            break;
                        }
                        else if ((s != Cabinets.Length - 2 && s != Cabinets.Length - 3)) EditSelected(s, Cabinets, "Редактируем кабинет");
                        if (s == Cabinets.Length - 2)
                        {
                            Console.CursorVisible = true;
                            FillFrame(0, 1, 30, 2);
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Введите номер кабинета (от 0)");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Delete(ref Cabinets, Convert.ToInt32(Console.ReadLine()));
                            Console.CursorVisible = false;
                        }
                        if (s == Cabinets.Length - 3)
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Создаем кабинет");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Create(ref Cabinets, Console.ReadLine());
                            Console.CursorVisible = false;
                        }
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        FillFrame(0, 0, 15, CallTimes.Length + 1);
                        s = Select(1, 1, CallTimes);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        if (s == CallTimes.Length - 1)
                        {
                            FillFrame(0, 0, 14, Director.Length + 1);//46 11
                            n = Select(1, 1, Director);
                            Save(CallTimes, fileCallTimes);
                            break;
                        }
                        else if ((s != CallTimes.Length - 2 && s != CallTimes.Length - 3)) EditSelected(s, CallTimes, "Редактируем время звонка");
                        if (s == CallTimes.Length - 2)
                        {
                            Console.CursorVisible = true;
                            FillFrame(0, 1, 30, 2);
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Введите номер звонка (от 0)");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Delete(ref CallTimes, Convert.ToInt32(Console.ReadLine()));
                            Console.CursorVisible = false;
                        }
                        if (s == CallTimes.Length - 3)
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(1, 1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Создаем время звонка");
                            Console.SetCursorPosition(1, 2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Create(ref CallTimes, Console.ReadLine());
                            Console.CursorVisible = false;
                        }
                        break;
                    case 5:
                        IsWorking = false;
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }
            }
        }
        static void ModuleHeadTeacher()
        {
            int s;
            bool IsWorking = true;
            bool IsWorking2;
            Console.CursorVisible = false;
            Delete2(ref Classes, Classes.Length - 3);
            Delete2(ref Classes, Classes.Length - 2);
            Console.BackgroundColor = ConsoleColor.Black;
            FillFrame(0, 0, 8, Classes.Length + 1);
            int n = Select(1, 1, Classes);
            while (IsWorking)
            {
                switch (n)
                {
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        if (n == Classes.Length - 1)
                        {
                            IsWorking = false;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        }
                        FillFrame(0, 0, 13, Days.Length + 1);
                        n = Select(1, 1, Days);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        if (n == Days.Length - 1)
                        {
                            FillFrame(0, 0, 8, Classes.Length + 1);
                            n = Select(1, 1, Classes);
                            Save(Days, fileDays);
                            break;
                        }
                        else
                        {
                            IsWorking2 = true;
                            while (IsWorking2)
                            {
                                switch (n)
                                {
                                    case 0:
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        FillFrame(0, 0, 55, Monday.Length + 1);
                                        s = Select(1, 1, Monday);
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        if (s == Monday.Length - 1)
                                        {
                                            FillFrame(0, 0, 13, Days.Length + 1);
                                            n = Select(1, 1, Days);
                                            Save(Monday, fileMonday);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }
                                        else if (s != Monday.Length - 2 && s != Monday.Length - 3) EditSelected(s, Monday, "Редактируем урок");
                                        if (s == Monday.Length - 2)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 30, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Введите номер учителя (от 0)");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Delete(ref Monday, Convert.ToInt32(Console.ReadLine()));
                                            Console.CursorVisible = false;
                                        }
                                        if (s == Monday.Length - 3)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 55, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Создаем урок");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Create(ref Monday, Console.ReadLine());
                                            Console.CursorVisible = false;
                                        }
                                        break;
                                    case 1:
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        FillFrame(0, 0, 55, Tuesday.Length + 1);
                                        s = Select(1, 1, Tuesday);
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        if (s == Tuesday.Length - 1)
                                        {
                                            FillFrame(0, 0, 13, Days.Length + 1);
                                            n = Select(1, 1, Days);
                                            Save(Tuesday, fileTuesday);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }
                                        else if (s != Tuesday.Length - 2 && s != Tuesday.Length - 3) EditSelected(s, Tuesday, "Редактируем урок");
                                        if (s == Tuesday.Length - 2)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 30, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Введите номер учителя (от 0)");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Delete(ref Tuesday, Convert.ToInt32(Console.ReadLine()));
                                            Console.CursorVisible = false;
                                        }
                                        if (s == Tuesday.Length - 3)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 55, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Создаем урок");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Create(ref Tuesday, Console.ReadLine());
                                            Console.CursorVisible = false;
                                        }
                                        break;
                                    case 2:
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        FillFrame(0, 0, 55, Wednesday.Length + 1);
                                        s = Select(1, 1, Wednesday);
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        if (s == Wednesday.Length - 1)
                                        {
                                            FillFrame(0, 0, 13, Days.Length + 1);
                                            n = Select(1, 1, Days);
                                            Save(Wednesday, fileWednesday);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }
                                        else if (s != Wednesday.Length - 2 && s != Wednesday.Length - 3) EditSelected(s, Wednesday, "Редактируем урок");
                                        if (s == Wednesday.Length - 2)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 30, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Введите номер учителя (от 0)");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Delete(ref Wednesday, Convert.ToInt32(Console.ReadLine()));
                                            Console.CursorVisible = false;
                                        }
                                        if (s == Wednesday.Length - 3)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 55, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Создаем урок");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Create(ref Wednesday, Console.ReadLine());
                                            Console.CursorVisible = false;
                                        }
                                        break;
                                    case 3:
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        FillFrame(0, 0, 55, Thursday.Length + 1);
                                        s = Select(1, 1, Thursday);
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        if (s == Thursday.Length - 1)
                                        {
                                            FillFrame(0, 0, 13, Days.Length + 1);
                                            n = Select(1, 1, Days);
                                            Save(Thursday, fileThursday);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }
                                        else if (s != Thursday.Length - 2 && s != Thursday.Length - 3) EditSelected(s, Thursday, "Редактируем урок");
                                        if (s == Thursday.Length - 2)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 30, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Введите номер учителя (от 0)");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Delete(ref Thursday, Convert.ToInt32(Console.ReadLine()));
                                            Console.CursorVisible = false;
                                        }
                                        if (s == Thursday.Length - 3)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 55, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Создаем урок");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Create(ref Thursday, Console.ReadLine());
                                            Console.CursorVisible = false;
                                        }
                                        break;
                                    case 4:
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        FillFrame(0, 0, 55, Friday.Length + 1);
                                        s = Select(1, 1, Friday);
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        if (s == Friday.Length - 1)
                                        {
                                            FillFrame(0, 0, 13, Days.Length + 1);
                                            n = Select(1, 1, Days);
                                            Save(Friday, fileFriday);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }
                                        else if (s != Friday.Length - 2 && s != Friday.Length - 3) EditSelected(s, Friday, "Редактируем урок");
                                        if (s == Friday.Length - 2)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 30, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Введите номер учителя (от 0)");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Delete(ref Friday, Convert.ToInt32(Console.ReadLine()));
                                            Console.CursorVisible = false;
                                        }
                                        if (s == Friday.Length - 3)
                                        {
                                            Console.CursorVisible = true;
                                            FillFrame(0, 1, 55, 2);
                                            Console.SetCursorPosition(1, 1);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Создаем урок");
                                            Console.SetCursorPosition(1, 2);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Create(ref Friday, Console.ReadLine());
                                            Console.CursorVisible = false;
                                        }
                                        break;
                                    case 5:
                                        IsWorking2 = false;
                                        Console.Clear();
                                        FillFrame(0, 0, 8, Classes.Length + 1);
                                        n = Select(1, 1, Classes);
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
        }
        static void ModuleInfo()
        {
            int s;
            bool IsWorking = true;
            bool IsWorking2 = true;
            bool IsWorking3 = true;
            Console.CursorVisible = false;
            Delete2(ref Classes, Classes.Length - 3);
            Delete2(ref Classes, Classes.Length - 2);
            Delete2(ref Monday, Monday.Length - 3);
            Delete2(ref Monday, Monday.Length - 2);
            Delete2(ref Tuesday, Tuesday.Length - 3);
            Delete2(ref Tuesday, Tuesday.Length - 2);
            Delete2(ref Wednesday, Wednesday.Length - 3);
            Delete2(ref Wednesday, Wednesday.Length - 2);
            Delete2(ref Thursday, Thursday.Length - 3);
            Delete2(ref Thursday, Thursday.Length - 2);
            Delete2(ref Friday, Friday.Length - 3);
            Delete2(ref Friday, Friday.Length - 2);
            string[] info = { "Ученик", "[Выход]" };
            Console.BackgroundColor = ConsoleColor.Black;
            FillFrame(0, 0, 8, info.Length + 1);
            int n = Select(1, 1, info);
            while (IsWorking3)
            {
                switch (n)
                {
                    default:
                        if (n == info.Length - 1)
                        {
                            IsWorking3 = false;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        }
                        IsWorking = true;
                        while (IsWorking)
                        {
                            switch (n)
                            {
                                default:
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    FillFrame(0, 0, 8, Classes.Length + 1);
                                    n = Select(1, 1, Classes);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    if (n == Classes.Length - 1)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        FillFrame(0, 0, 8, info.Length + 1);
                                        n = Select(1, 1, info);
                                        IsWorking = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        FillFrame(0, 0, 13, Days.Length + 1);
                                        n = Select(1, 1, Days);
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        if (n == Days.Length - 1)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            FillFrame(0, 0, 8, Classes.Length + 1);
                                            n = Select(1, 1, Classes);
                                            break;
                                        }
                                        else
                                        {
                                            IsWorking2 = true;
                                            while (IsWorking2)
                                            {
                                                switch (n)
                                                {
                                                    case 0:
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        FillFrame(0, 0, 55, Monday.Length + 1);
                                                        s = Select(1, 1, Monday);
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        if (s == Monday.Length - 1)
                                                        {
                                                            FillFrame(0, 0, 13, Days.Length + 1);
                                                            n = Select(1, 1, Days);
                                                            Console.BackgroundColor = ConsoleColor.Black;
                                                        }
                                                        break;
                                                    case 1:
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        FillFrame(0, 0, 55, Tuesday.Length + 1);
                                                        s = Select(1, 1, Tuesday);
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        if (s == Tuesday.Length - 1)
                                                        {
                                                            FillFrame(0, 0, 13, Days.Length + 1);
                                                            n = Select(1, 1, Days);
                                                            Console.BackgroundColor = ConsoleColor.Black;
                                                        }
                                                        break;
                                                    case 2:
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        FillFrame(0, 0, 55, Wednesday.Length + 1);
                                                        s = Select(1, 1, Wednesday);
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        if (s == Wednesday.Length - 1)
                                                        {
                                                            FillFrame(0, 0, 13, Days.Length + 1);
                                                            n = Select(1, 1, Days);
                                                            Console.BackgroundColor = ConsoleColor.Black;
                                                        }
                                                        break;
                                                    case 3:
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        FillFrame(0, 0, 55, Thursday.Length + 1);
                                                        s = Select(1, 1, Thursday);
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        if (s == Thursday.Length - 1)
                                                        {
                                                            FillFrame(0, 0, 13, Days.Length + 1);
                                                            n = Select(1, 1, Days);
                                                            Console.BackgroundColor = ConsoleColor.Black;
                                                        }
                                                        break;
                                                    case 4:
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        FillFrame(0, 0, 55, Friday.Length + 1);
                                                        s = Select(1, 1, Friday);
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.Clear();
                                                        if (s == Friday.Length - 1)
                                                        {
                                                            FillFrame(0, 0, 13, Days.Length + 1);
                                                            n = Select(1, 1, Days);
                                                            Console.BackgroundColor = ConsoleColor.Black;
                                                        }
                                                        break;
                                                    case 5:
                                                        IsWorking2 = false;
                                                        Console.Clear();
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            LoadAllData();
            while (true)
            {
                // Авторизация
                Console.CursorVisible = false;
                FillFrame(45, 10, 17, 6);
                Console.SetCursorPosition(46, 10);
                Console.WriteLine("Выберите модуль:");
                string[] auth = { "Директор", "Завуч", "Информер" };
                int n = Select(50, 12, auth);
                n = Auth(n);
                //------------
                switch (n)
                {
                    case 0:
                        ModuleDirector();
                        Console.Clear();
                        break;
                    case 1:
                        ModuleHeadTeacher();
                        Console.Clear();
                        break;
                    case 2:
                        ModuleInfo();
                        Console.Clear();
                        break;
                    case 3:
                        Console.CursorVisible = false;
                        FillFrame(45, 9, 27, 2);
                        Console.SetCursorPosition(46, 10);
                        Console.WriteLine("Введенные данные неверные.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
