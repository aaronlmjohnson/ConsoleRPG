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
 

        public void Move(int distance)
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
                
        }

        public void Draw()
        {
            Console.ForegroundColor = playerColor;

            Console.SetCursorPosition(x, y);
            Console.Write(body);

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
            //return screen.Grid[y + 1 + yMove, x + xMove] != '#' &&
            //       screen.Grid[Y + yMove, X + 2 + xMove] != '#' &&
            //       screen.Grid[Y + 1 + yMove, X + xMove] != '^' &&
            //       screen.Grid[Y + yMove, X + 2 + xMove] != '^';
        }

    }
}
