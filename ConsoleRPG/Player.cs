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
        public Player(int _x, int _y, int _windowHeight, int _windowWidth)
            : base(_x, _y, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\Player.txt")
        {
            playerColor = ConsoleColor.Blue;
            windowHeight = _windowHeight;
            windowWidth = _windowWidth;
        }

        public void Move()
        {
            ConsoleKeyInfo input;

            input = Console.ReadKey();

            if (input.Key == ConsoleKey.LeftArrow)
                MoveLeft();
            if (input.Key == ConsoleKey.RightArrow)
                MoveRight();
            if (input.Key == ConsoleKey.UpArrow)
                MoveUp();
            if (input.Key == ConsoleKey.DownArrow)
                MoveDown();
            // TODO: Clear grid of old player position
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

        private void MoveRight()
        {
            if (X + 1 >= windowWidth - 2)
            {
                return;
            }
            else
            {
                X += 1;
            }

        }

        private void MoveLeft()
        {
            if (X - 1 < 0)
                return;
            else
            {

                X -= 1;
            }

        }

        private void MoveUp()
        {
            if (Y - 1 < 0)
                return;
            else
                Y -= 1;
        }

        private void MoveDown()
        {
            if (Y + 1 >= windowHeight - 1)
                return;
            else
                Y += 1;
        }

        public void DisplayPosition()
        {
            Console.SetCursorPosition(20, 20);
            Console.WriteLine($"meow:{X}");

        }
    }
}
