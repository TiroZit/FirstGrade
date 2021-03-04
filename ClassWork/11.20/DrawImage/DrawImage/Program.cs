using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawImage
{
    class Program
    {
        static void Draw(int x, int y, int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    ConsoleColor color = (ConsoleColor) m[i, j];
                    Console.ForegroundColor = color;

                    Console.SetCursorPosition(x + j, y + i);
                    Console.Write("█");//alt + numlock 219
                }
            }
        }
        /// <summary>
        /// Метод рисования картинки с растяжением по оси Х
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="m">матрица с картинкой</param>
        /// <param name="scaleX">Целое число - коэф масштабирования по Х</param>
        static void DrawScaleX(int x, int y, int[,] m, int scaleX)
        {
            string pixel = new string('█', scaleX);
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    ConsoleColor color = (ConsoleColor)m[i, j];
                    Console.ForegroundColor = color;

                    Console.SetCursorPosition(x + j * scaleX, y + i);//(x - j) * scaleX - зеркальный
                    Console.Write(pixel);//alt + numlock 219
                }
            }
        }
        static void Main(string[] args)
        {
            int[,] image =
            {
                {09, 15, 04, 00, 00, 00, 00, 00, 00, 00 },
                {09, 15, 04, 00, 00, 00, 00, 00, 00, 00 },
                {09, 15, 04, 00, 00, 00, 00, 00, 00, 00 },
                {09, 15, 04, 00, 00, 00, 00, 00, 00, 00 },
                {09, 15, 04, 00, 00, 00, 00, 00, 00, 00 },
                {09, 15, 04, 00, 00, 00, 00, 00, 00, 00 },
                {00, 00, 00, 00, 00, 00, 00, 00, 00, 00 },
                {00, 00, 00, 00, 00, 00, 00, 00, 00, 00 },
                {00, 00, 00, 00, 00, 00, 00, 00, 00, 00 },
                {00, 00, 00, 00, 00, 00, 00, 00, 00, 00 },
                {00, 00, 00, 00, 00, 00, 00, 00, 00, 00 },
            };
            DrawScaleX(10, 10, image, 4);
            Console.ReadLine();
        }
    }
}
