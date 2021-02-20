using System;
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
            if(input != null)
                Erase();

            int orgX = x;
            int orgY = y;
 
            if (input.Key == ConsoleKey.LeftArrow)
                x -= 1;
            if (input.Key == ConsoleKey.RightArrow)
                x += 1;
            if (input.Key == ConsoleKey.UpArrow)
                y -= 1;
            if (input.Key == ConsoleKey.DownArrow)
                y += 1;

            if (!InBounds() || !Walkable())
            {
                x = orgX;
                y = orgY;
            }
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

        private bool InBounds()
        {
            return y <= screen.Height - 1 && y >= 0 &&
                   x <= screen.Width - 1 && x >= 0;
        }

        private bool Walkable()
        {

            return screen.Grid[y, x] != '#' && screen.Grid[y, x] != '^';
        }

        public bool EnteredDoor()
        {
            return screen.Grid[y, x] == 'D';
        }
    }
}
