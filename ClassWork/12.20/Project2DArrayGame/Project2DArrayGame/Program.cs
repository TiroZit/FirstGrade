using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project2DArrayGame
{
    class Program
    {
        /*
         * На экран и в лабиринт добавить бонусы и ловушки
         * Бонусы - собирать (подсчет очков)
         * ловушки - конец игры.
         * Добавить на экан лабиринты 
         */
        // глобальные переменные
        static int labX = 40, labY = 5; //координаты лабиинта
        static int labX2 = 60, labY2 = 5;
        static int curX = 1, curY = 1; // текущие координаты
        static int prevX = 1, prevY = 1;  // previous предыдущие
        static int score = 0;
        
        //карта лабиринта глобальный массив - доступен всем методам
        static int[,] mas = // 15x15
        {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 1,0,0,1,0,0,0,1,1,1,1,1,1,0,1 },
            { 1,0,0,1,0,0,0,1,0,0,0,0,1,0,1 },
            { 1,2,0,1,0,0,0,1,0,0,0,0,0,0,1 },
            { 1,0,0,1,0,0,0,1,0,0,0,0,1,0,1 },
            { 1,0,0,1,1,1,1,1,0,0,0,0,1,0,1 },
            { 1,0,0,2,0,0,0,0,0,0,0,0,1,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,1,0,1 },
            { 0,0,0,1,1,1,1,1,1,1,1,0,1,0,1 },
            { 1,0,0,1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,2,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
        };
        static int[,] mas2 = // 15x15
{
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 1,0,0,0,0,0,0,2,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,2,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,2,0,0,0,0,0,0,1 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
        };

        static int[,] st = // 15x15
{
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 1,0,0,0,0,0,0,2,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,2,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,2,0,0,0,0,0,0,1 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
        };

        //отрисовка лабиринта на экране
        static void DrawLab()
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas2[i, j] = st[i, j];
                }
            }

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.SetCursorPosition(labX+j, labY+i);
                    if (mas[i, j] == 1)
                        Console.Write("█"); // 219 

                    if(mas[i,j] == 2)
                        Console.Write("☼");
                }
            }

            for (int i = 0; i < st.GetLength(0); i++)
            {
                for (int j = 0; j < st.GetLength(1); j++)
                {
                    Console.SetCursorPosition(labX2 + j, labY2 + i);
                    if (st[i, j] == 2)
                    {
                        Console.Write("♥");
                    }

                    if (st[i,j] == 1)
                    {
                        Console.Write("█");
                    }
                }
            }
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(score);
        }

        static void Restart()
        {
            score = 0;
            curX = 1; curY = 1;
            prevX = 1; prevY = 1;
            
            Console.Clear();
            DrawLab();
        }

        // проверка столкновений со стенами лабиинта
        static bool IsCollision() // да/нет
        {
            // тансофомиуем эканные координаты перс в локальные для лабиринты
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("экранные X:{0:d2}   Y:{1:d2}  ", curX, curY);
            int locX = curX - labX;
            int locY = curY - labY;
            Console.SetCursorPosition(10, 1);
            Console.WriteLine("локальные X:{0:d2}   Y:{1:d2}  ", locX, locY);
            // проверить -  перс в лабиинте или нет
            bool isInside = locX >= 0 && locX <= mas.GetLength(1) - 1 &&
                locY >= 0 && locY <= mas.GetLength(0) - 1;

            Console.SetCursorPosition(10, 2);
            if (isInside) Console.WriteLine("1");
            else Console.WriteLine("2");

            bool isCollide = false;
            if (isInside)
            {
                // проверка столкновений со стенами лабиринта
                int valueCell = mas[locY, locX]; // не как в математике, а наоборот
                isCollide = valueCell == 1;

            }
            Console.SetCursorPosition(10, 3);
            if(isCollide)
                Console.WriteLine("collide       ");
            else
                Console.WriteLine("                 ");
            return isCollide;
            
        }
        static bool IsCollision2() // да/нет
        {
            // тансофомиуем экранные координаты перс в локальные для лабиринты

            int locX = curX - labX;
            int locY = curY - labY;

            int locX2 = curX - labX2;
            int locY2 = curY - labY2;

            // провека на столкновение с массивом
            bool isInside = locX >= 0 && locX <= mas.GetLength(1) - 1 &&
                            locY >= 0 && locY <= mas.GetLength(0) - 1;
            bool isInside2 = locX2 >= 0 && locX2 <= mas.GetLength(1) - 1 &&
                             locY2 >= 0 && locY2 <= mas.GetLength(0) - 1;


            bool isCollide = false;
            if (isInside)
            {
                // проверка столкновений со стенами лабиринта
                
                int valueCell = mas[locY, locX]; // не как в математике, а наоборот

                isCollide = valueCell == 1;

                if (valueCell == 2)
                {
                    Restart();
                }
            }
            if (isInside2)
            {
                // проверка столкновений со стенами лабиринта

                int valueCell = mas2[locY2, locX2]; // не как в математике, а наоборот
                if(valueCell == 2)
                {
                    mas2[locY2, locX2] = 0;
                    Console.SetCursorPosition(2, 2);
                    Console.Write(++score);                                   
                }
                    
                isCollide = valueCell == 1;
            }

            return isCollide;

        }
        // пеермещение персонажа по экану
        static void Walk()
        {
                if (IsCollision2())
                {
                    curX = prevX;
                    curY = prevY;
                }
              
                Console.SetCursorPosition(curX, curY);
                Console.Write("☻");
                if (curX != prevX || curY != prevY)
                {
                    Console.SetCursorPosition(prevX, prevY);
                    Console.WriteLine(" ");                      
                }
                //Нажатие не блокирует
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);//Метод блокирует выполнение программы
                prevX = curX;
                prevY = curY;

                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        curX--;
                        break;
                    case ConsoleKey.RightArrow:
                        curX++;
                        break;
                    case ConsoleKey.UpArrow:
                        curY--;
                        break;
                    case ConsoleKey.DownArrow:
                        curY++;
                        break;
                }

            }
        }
        //Координаты врагов
        static int[] EnemiesX = { 8, 10 };
        static int[] EnemiesY = { 11, 13 };
        //Направления движения врагов
        static int[] EnemiesMoveX = { +1, -1 };
        static int[] EnemiesMoveY = { 0, 0 };

        static int LeftEdge = 1, RightEdge = 15;
        static void Enemies()
        {
            for (int i = 0; i < EnemiesX.Length; i++)
            {
                //Стираем врагов
                Console.SetCursorPosition(EnemiesX[i], EnemiesY[i]);
                Console.Write(" ");//11
                //Движение
                EnemiesX[i] += EnemiesMoveX[i];
                EnemiesY[i] += EnemiesMoveY[i];
                //Отрисовали врагов
                Console.SetCursorPosition(EnemiesX[i], EnemiesY[i]);
                Console.Write("♂");//11
                //Проверка границ
                if (EnemiesX[i] <= LeftEdge || EnemiesX[i] >= RightEdge)
                {
                    EnemiesMoveX[i] = -EnemiesMoveX[i];
                }
            }
        }
        static void Main(string[] args)
        {           
            Console.CursorVisible = false;
            DrawLab();
            Walk();
            while (true)
            {
                Walk();
                Enemies();
                Thread.Sleep(120);
            }
            Console.ReadLine();
        }
    }
}
