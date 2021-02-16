using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Window
    {
        private char[,] window;
        private int height = 50;
        private int width = 100;
        private Player player { get;  set; }
        private GameObject[] gObjs { get; set; }
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
                }
                Console.WriteLine(row);
            }
        }

        public void DrawObject(GameObject gObj)
        {
            for (int y = 0; y < gObj.Height; y++)
            {
                for (int x = 0; x < gObj.Width; x++)
                {
                    if (InBounds(gObj))
                        window[gObj.Y + y, gObj.X + x] = gObj.Body[y, x];
                    else
                        return;
                }
            }

        }

        public void DrawScene()
        {
            Console.Clear();
            Display();
            

            player.Draw();
        }

        public void Update()
        {
            foreach (GameObject gObj in gObjs)
            {
                DrawObject(gObj);
            }
            while (true)
            {
                DrawScene();
                player.Move();
                System.Threading.Thread.Sleep(20);

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
