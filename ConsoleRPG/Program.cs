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
                    for (int j = 0; j < gObject.Width; j++)
                        window[gObject.Y + i, gObject.X + j] = gObject.Body[i, j];
            }

            public void Update()
            {
                Display();
                Console.SetCursorPosition(0, Console.WindowHeight);
                Console.WriteLine();
                
                //foreach(GameObject gObject in gObjects)
                //    Draw(gObject);


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

        class Player : GameObject
        {
            public Player(int _x, int _y) 
                :base(_x, _y, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\Player.txt")
            {

            }

        }
        static void Main(string[] args)
        {
            //Window screen = new Window();
            //screen.Fill('.');
   

            GameObject shop = new GameObject(10, 10, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\shop.txt");
            GameObject house = new GameObject(0, 10, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\house.txt");
            Player player = new Player(20, 20);
            //screen.Draw(shop);
            //screen.Draw(house);
            //screen.Draw(player);
            
            for(int y = 0; y < shop.Body.GetLength(0); y++)
            {
                for(int x = 0; x < shop.Body.GetLength(1); x++)
                {
                    Console.SetCursorPosition(shop.X + x, shop.Y + y);
                    Console.Write(shop.Body[y, x]);
                }
            }
            
            //while (true)
            //{
            //    screen.Update();
            //}
        }
    }
}
