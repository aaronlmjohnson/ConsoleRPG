using System;

namespace ConsoleRPG
{
    class Program
    {
        class Window
        {
            private char[,] window;
            private int width = Console.WindowWidth;
            private int height = Console.WindowHeight;
            public Window()
            {
                window = new char[height, width];
            }

            public void Fill(char fillChar)
            {
                for(int i = 0; i < height; i++)
                {
                    for(int j = 0; j < width; j++)
                    {
                        window[i, j] = fillChar;
                    }
                }
            }
            
            public void Display()
            {
                for (int i = 0; i < height; i++)
                {
                    string row = "";
                    for (int j = 0; j < width; j++)
                    {
                        row += window[i, j];
                    }
                    Console.WriteLine(row);
                }
            }

            public void Draw(int rowStart, int colStart, char fill)
            {
                int objWidth = 5;
                int objHeight = 3;

                for (int i = rowStart; i < (rowStart + objHeight); i++)
                {
                    for (int j = colStart; j < (colStart + objWidth); j++)
                    {
                        window[i, j] = fill;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Window screen = new Window();
            screen.Fill('.');
            screen.Draw(0, 0, '#');
            screen.Display();
        }
    }
}
