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

            private void AddToScene(GameObject gObj)
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

            public void Draw(GameObject gObj)
            {
                AddToScene(gObj);
                for(int y = 0; y < gObj.Height; y++)
                {
                    for(int x = 0; x < gObj.Width; x++)
                    {
                        Console.SetCursorPosition(gObj.X + x, gObj.Y + y);
                        Console.WriteLine(gObj.Body[y, x]);
                    }
                }
            }

            public void Update(Player player)
            {
                while (true)
                {
                    player.Move();
                    Draw(player);
                }
                


                //foreach(GameObject gObject in gObjects)
                //    Draw(gObject);


            }

            private bool InBounds(GameObject gObj)
            {
                if(gObj.X < 0  || gObj.Y < 0)
                {
                    return false;
                }
                else if (gObj.X + gObj.Width >= width || gObj.Y + gObj.Height >= height)
                {
                    return false;
                }
                return true;
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

            public void Move()
            {
                ConsoleKeyInfo input;

                input = Console.ReadKey();

                if (input.Key == ConsoleKey.LeftArrow)
                {
                    if (X - 1 < 0)
                        return;
                    else
                        X -= 1; 
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    if (X + 1 > 50)
                        return;
                    else
                        X += 1;
                }
                else if (input.Key == ConsoleKey.UpArrow)
                {
                    if (Y - 1 < 0)
                        return;
                    else
                        Y -= 1;
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    if (Y + 1 > 50)
                        return;
                    else
                        Y += 1;
                }// TODO: pass window dimensions to player
                // encapsulate movement code

            }
            // movement
            // when pressing the A button have character move left
            // when pressing the D button have the character move right
            // When A is pressed subtract -1 from all of the player's positions in its body
            //  if any of the values are less than 0 
            //    reset its body to its original state and return

        }
        static void Main(string[] args)
        {
            Window screen = new Window();
            //screen.Fill('.');


            GameObject shop = new GameObject(50, 0, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\shop.txt");
            GameObject house = new GameObject(0, 10, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\house.txt");
            Player player = new Player(20, 20);
            //screen.Draw(shop);
            //screen.Draw(house);
            //screen.Draw(player);
            screen.Update(player);
  
            //screen.Display();




        }
    }
}
