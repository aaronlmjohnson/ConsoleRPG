using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Building : GameObject
    {
        private ConsoleColor bodyColor;
        public Building(int _x, int _y, Window _screen, string _filePath, ConsoleColor _bodyColor)
            : base(_x, _y, _screen, _filePath)
        {
            bodyColor = _bodyColor;
        }

         public override void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                
                for (int x = 0; x < width; x++)
                {
                    
                    Console.SetCursorPosition(x + X, y + Y);
                    if (body[y, x] == '#')
                        Console.ForegroundColor = bodyColor;
                    Console.Write(body[y, x]);
                    Console.ResetColor();
                }
                
            }
            

        }
    }
}
