using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class GameObject
    {
        private int width;
        private int height;
        private int x;
        private int y;
        private char[,] body;
        private  ConsoleColor color;
        public GameObject(int _x, int _y, string _filePath)
        {
            x = _x;
            y = _y;

            LoadAsset(_filePath);
            color = ConsoleColor.Yellow;
        }

        private void LoadAsset(string filePath)
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

        public void Display()
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                string row = "";
                for (int j = 0; j < width; j++)
                {
                    row += body[i, j];
                }
                Console.WriteLine(row);
            }

            Console.ResetColor();
        }

        private bool Collsion(GameObject obj)
        {
            return X < (obj.X + obj.Width) && X + Width > obj.X &&
                   Y < (obj.Y + obj.Height) && Y + Height > obj.Y;
        }

        //public void Display()
        //{
        //    Console.ForegroundColor = color;

        //    for (int yY = 0; yY < Height; yY++)
        //    {
        //        for (int xX = 0; xX < Width; xX++)
        //        {
        //            Console.SetCursorPosition(xX + X, yY + Y);
        //            Console.Write(Body[0, 0]);
        //        }
        //    }
        //    Console.ResetColor();

        //}

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
