﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Player
    {
        private ConsoleColor playerColor;
        private Window screen;
        private char body;
        private int x;
        private int y;

        public Player(int _x, int _y, Window _screen)
        {
            x = _x;
            y = _y;
            screen = _screen;
            body = 'P';
            playerColor = ConsoleColor.Blue;

        }


        public void Move()
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey();
            
            if (input.Key == ConsoleKey.LeftArrow)
            {
                Erase();
                x += InBounds(-1, 0) && IsWalkable(-1, 0) ? -1 : 0;
            }

            if (input.Key == ConsoleKey.RightArrow)
            {
                Erase();
                x += InBounds(1, 0) && IsWalkable(1, 0) ? 1 : 0;
            }

            if (input.Key == ConsoleKey.UpArrow)
            {
                Erase();
                y += InBounds(0, -1) && IsWalkable(0, -1) ? -1 : 0;
            }
            if (input.Key == ConsoleKey.DownArrow)
            {
                Erase();
                y += InBounds(0, 1) && IsWalkable(0, 1) ? 1 : 0;
            }

            //try to move character
            //check if inbounds
            // if not set X/Y back to original value;


        }

        public void Draw()
        {
            Console.ForegroundColor = playerColor;

            Console.SetCursorPosition(x, y);
            Console.Write(body);
            Console.SetCursorPosition(x, y);
            Console.ResetColor();

        }

        private void Erase()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        private bool InBounds(int xMove, int yMove)
        {

            if (yMove == 1)
                return y + yMove <= screen.Height - 1;
            else if (yMove == -1)
                return y + yMove >= 0;
            else if (xMove == 1)
                return x + xMove <= screen.Width - 1;
            else if (xMove == -1)
                return x + xMove > 0;

            return false;
        }

        private bool IsWalkable(int xMove, int yMove)
        {

            return screen.Grid[y + yMove, x + xMove] != '#' &&
                   screen.Grid[y + yMove, x + xMove] != '^';
        }

        public bool EnteredDoor()
        {
            return screen.Grid[y, x] == 'D';
        }
    }
}
