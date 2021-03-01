using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Building : GameObject
    {
        private string[] colorPalette; //0: Roof 1: body 2: other
        private int entranceX;
        private int entranceY;
        private string name;
        public Building(int _x, int _y, Window _screen, string _filePath, string[] _colorPalette, int _entranceX, int _entranceY, string _name)
            : base(_x, _y, _screen, _filePath)
        {
            colorPalette = _colorPalette;
            entranceX = _entranceX;
            entranceY = _entranceY;
            name = _name;
        }

         public override void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x + X, y + Y);
                    ColorMaterial(x, y, '^', colorPalette[0]);
                    ColorMaterial(x, y, '#', colorPalette[1]);
                    ColorMaterial(x, y, 'D', colorPalette[2]);

                    Console.Write(body[y, x]);
                    Console.ResetColor();
                }
            }
            

        }

        private void ColorMaterial(int x, int y, char material, string color)
        {
            if (body[y, x] == material)
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
        }

        public int EntranceX
        {
            get => entranceX;
        }

        public int EntranceY
        {
            get => entranceY;
        }

        public string Name
        {
            get => name;
        }
    }
}
