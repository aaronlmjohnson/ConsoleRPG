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

        class GameObject
        {
            private int width;
            private int height;
            private int x;
            private int y;
            private char[,] body;
            public GameObject(int _x, int _y)
            {
                x = _x;
                y = _y;
                LoadAsset(@"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\shop.txt");  
            }

            private void LoadAsset(string filePath)
            {
                string[] assetInfo;
                assetInfo = System.IO.File.ReadAllLines(filePath);
                width = assetInfo[0].Length;
                height = assetInfo.Length;

                body = new char[height, width];

                for(int i = 0; i < height; i++)
                {
                    for(int j = 0; j < width; j++)
                    {
                        body[i, j] = assetInfo[i][j];
                    }
                }
            }

            public void Display()
            {
                for(int i = 0; i < height; i++)
                {
                    string row = "";
                    for(int j = 0; j < width; j++)
                    {
                        row += body[i, j];
                    }
                    Console.WriteLine(row);
                }
            }
        }
        static void Main(string[] args)
        {
            //Window screen = new Window();
            //screen.Fill('.');
            //screen.Draw(0, 0, '#');
            //screen.Display();

            GameObject shop = new GameObject(0, 0);
            shop.Display();
        }
    }
}
