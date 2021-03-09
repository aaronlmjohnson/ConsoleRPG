using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Player
    {
        private ConsoleColor playerColor;
        private Window screen;
        public char body { get; set; }
        private int x;
        private int y;
        private bool active;
        public int X { get => x; }
        public int Y { get => y; }
        private int health;
        private int mana;
        private int strength;
        private int magic;

        public Player(int _x, int _y, Window _screen)
        {
            x = _x;
            y = _y;
            screen = _screen;
            body = 'P';
            playerColor = ConsoleColor.Blue;
            active = true;

            health = 100;
            mana = 3;
            strength = 10;
            magic = 8;

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
            return screen.Grid[y, x] == ' ' || 
                   screen.Grid[y, x] == 'D' ||
                   screen.Grid[y, x] == 'E';
        }

        public bool EnteredDoor()
        {
            return screen.Grid[y, x] == 'D';
        }

        public bool ExitedScene()
        {
            return screen.Grid[y, x] == 'E';
        }

        public void SetPosition(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public bool Active
        {
            get => active;
            set => active = value;
        }

        public int Health
        {
            get => health;
            set => health = value;
        }
        public int Mana
        {
            get => mana;
            set => mana = value;
        }

        public int Strength
        {
            get => strength;
            set => strength = value;
        }

        public int Magic
        {
            get => magic;
            set => magic = value;
        }

    }
}
