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

            public void Draw(GameObject gObject)
            {
                for (int i = 0; i < gObject.Height; i++)
                {
                    for (int j = 0; j < gObject.Width; j++)
                    {

                        window[gObject.Y + i, gObject.X + j] = gObject.Body[i, j];
                        
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
            public GameObject(int _x, int _y, string _filePath)
            {
                x = _x;
                y = _y;
                LoadAsset(_filePath);  
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
        static void Main(string[] args)
        {
            Window screen = new Window();
            screen.Fill('.');
   

            //GameObject shop = new GameObject(0, 0, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\shop.txt");
            GameObject house = new GameObject(0, 10, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\house.txt");
            //screen.Draw(shop);
            screen.Draw(house);

            screen.Display();
        }
    }
}
