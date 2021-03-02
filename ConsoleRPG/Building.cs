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
        private BuildingData data; 
        public Building(BuildingData _data, Window _screen, string _filePath = " ", int _x = 0, int _y = 0)
            : base(_x, _y, _screen, _filePath)
        {
            data = _data;
            colorPalette = data.ColorPalette;
            X = data.Position["X"];
            Y = data.Position["Y"];
            entranceX = data.Entrance["X"];
            entranceY = data.Entrance["Y"];
            name = data.Name;
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
