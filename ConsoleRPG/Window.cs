using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Window
    {
        private char[,] grid;
        private int height = 30;
        private int width = 119;
        private Player player { get;  set; }
        private GameObject[] gObjs { get; set; }
        public Window()
        {
            grid = new char[height, width];
            Fill(' ');
        }

        public void Fill(char fillChar)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = fillChar;
                }
            }
        }

        public void Display()
        {
            string row = "";
            for (int i = 0; i < height; i++)
            {
                

                for (int j = 0; j < width; j++)
                {
                    row += grid[i, j];
                }
                row += "\n";
                
            }
            Console.WriteLine(row);
        }

        public void DrawObject(GameObject gObj)
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

        public void DrawScene()
        {
            foreach (GameObject gObj in gObjs)
                DrawObject(gObj);
            player.Draw();

            Display();


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

        public Player Player
        {
            get => player;

            set { player = value; }
        }

        public GameObject[] GObjs
        {
            get => gObjs;

            set { gObjs = value; }
        }
    }
}
