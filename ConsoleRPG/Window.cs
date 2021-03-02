using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Window
    {
        private char[,] grid;
        private int height = 30;
        private int width = 70;

        public Window()
        {
            grid = new char[height, width];
        }

        public void Add(GameObject gObj)
        {
            for (int y = 0; y < gObj.Height; y++)
            {
                for (int x = 0; x < gObj.Width; x++)
                {
                    if (InBounds(gObj))
                        grid[gObj.Y + y, gObj.X + x] = gObj.Body[y, x];
                    else
                        return;
                }
            }
        }

        public void Clear()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y, x] = ' ';
                }
            }
        }

        private bool InBounds(GameObject gObj)
        {
            if (gObj.X < 0 || gObj.Y < 0)
            {
                return false;
            }
            else if (gObj.X + gObj.Width >= width || gObj.Y + gObj.Height >= height)
            {
                return false;
            }
            return true;
        }

        public int Height
        {
            get => height;
        }

        public int Width
        {
            get => width;
        }
        public char[,] Grid
        {
            get => grid;
        }
    }
}
