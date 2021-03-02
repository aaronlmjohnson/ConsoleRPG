using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class GameObject
    {
        protected int width;
        protected int height;
        private int x;
        private int y;
        protected char[,] body;

        Window screen;
        public GameObject(int _x, int _y, Window _screen,  string _filePath)
        {
            x = _x;
            y = _y;
            screen = _screen;
            LoadAsset(_filePath);
        }

        protected void LoadAsset(string filePath)
        {
            string[] assetInfo;
            assetInfo = System.IO.File.ReadAllLines(filePath);
            width = assetInfo[0].Length;
            height = assetInfo.Length;

            body = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    body[i, j] = assetInfo[i][j];
                }
            }
        }

        public virtual void Draw()
        {

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x + X, y + Y);
                    Console.Write(body[y,x]);
                    
                }
            }

        }

        public int Width
        {
            get => width;
            set { width = value; }
        }

        public int Height
        {
            get => height;
            set { height = value; }
        }

        public int X
        {
            get => x;
            set { x = value; }
        }

        public int Y
        {
            get => y;
            set { y = value; }
        }

        public char[,] Body
        {
            get => body;
        }
    }
}
