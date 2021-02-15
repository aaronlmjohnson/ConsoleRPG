using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
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
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
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
                    //char element = window[i, j];
                    //Console.SetCursorPosition(j, i);
                    //Console.Write(element);
                }
                Console.WriteLine(row);
            }
        }

        public void Draw(GameObject gObj)
        {
            for (int i = 0; i < gObj.Height; i++)
            {
                for (int j = 0; j < gObj.Width; j++)
                {
                    if (InBounds(gObj))
                        window[gObj.Y + i, gObj.X + j] = gObj.Body[i, j];
                    else
                        return;
                }
            }

        }

        public void Erase(int x, int y, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    window[y + i, x + j] = ' ';
                }
            }

        }

        //public void Draw(GameObject gObj)
        //{
        //    AddToScene(gObj);
        //    for(int y = 0; y < gObj.Height; y++)
        //    {
        //        for(int x = 0; x < gObj.Width; x++)
        //        {
        //            Console.SetCursorPosition(gObj.X + x, gObj.Y + y);
        //            Console.WriteLine(gObj.Body[y, x]);
        //        }
        //    }
        //}

        public void DrawScene(Player player)
        {
            Console.Clear();
            Display();
            
            player.Draw();
        }

        public void Update(Player player)
        {
            while (true)
            {
                DrawScene(player);
                player.Move();
                System.Threading.Thread.Sleep(10);

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
    }
}
