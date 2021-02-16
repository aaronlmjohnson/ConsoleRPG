using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Player : GameObject
    {
        private ConsoleColor playerColor;
        private int windowHeight;
        private int windowWidth;
        private Window window;
        public Player(int _x, int _y, int _windowHeight, int _windowWidth, Window _window)
            : base(_x, _y, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\Player.txt")
        {
            playerColor = ConsoleColor.Blue;
            windowHeight = _windowHeight;
            windowWidth = _windowWidth;
            window = _window;
        }

        public void Move()
        {
            ConsoleKeyInfo input;

            input = Console.ReadKey();

            if (input.Key == ConsoleKey.LeftArrow)
                X += InBounds(-1, 0) ? -1 : 0;
            if (input.Key == ConsoleKey.RightArrow)
                X += InBounds(1, 0) ? 1 : 0;
            if (input.Key == ConsoleKey.UpArrow)
                Y += InBounds(0, -1) ? -1 : 0;
            if (input.Key == ConsoleKey.DownArrow)
                Y += InBounds(0, 1)  ? 1 : 0;
        }

        public void Draw()
        {
            Console.ForegroundColor = playerColor;

            for(int yY = 0; yY < Height; yY++)
            {
                for(int xX = 0; xX < Width; xX++)
                {
                    Console.SetCursorPosition(xX + X, yY + Y);
                    Console.Write(Body[0, 0]);
                }
            }
            Console.ResetColor();
            
        }

        private bool InBounds(int xMove, int yMove)
        {
            bool valid;
            if (yMove > 0)
                valid =  Y + yMove >= windowHeight - 1 ? false : true;
            else if (yMove < 0)
                valid =  Y + yMove < 0 ? false : true;
            else if (xMove > 0)
                valid =  X + xMove >= windowWidth - 1 ? false : true;
            else if (X + xMove < 0)
                valid =  X + xMove < 0 ? false : true;

            valid = window.Grid[Y + yMove, X + xMove + 2] == ' ' && window.Grid[Y + yMove + 1, X + xMove] == ' ' ? true : false;


            return valid;
        }

        private bool Collided(int xMove, int yMove)
        {
            for (int i = Y; i < 2; i++)
            {
                for (int j = X; j < 3; j++)
                {
                    if (window.Grid[i + yMove, j + xMove] == '#')
                        return true;
                }
            }
            return false;
        }

        public void DisplayPosition()
        {
            Console.SetCursorPosition(20, 20);
            Console.WriteLine($"meow:{X}");

        }
    }
}
