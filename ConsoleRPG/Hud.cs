using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Hud
    {
        private const int X = 71;
        private const int Y = 0;
        private Player player;
        public Hud(Player _player)
        {
            player = _player;

        }

        public void PlayerPosition()
        {
            Write($"X:{player.X},Y:{player.Y}");
        }

        private void Write(string message, int x = X, int y = Y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("                                           ");
            Console.SetCursorPosition(x, y);
            Console.Write(message);
        }
    }
}
