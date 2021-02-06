using System;

namespace ConsoleRPG
{
    class Program
    {
        class Window
        {
            private int[,] window;
            public Window(int row, int col)
            {
                window = new int[row, col];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
