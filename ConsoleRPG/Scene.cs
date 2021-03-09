using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleRPG
{
    class Scene
    {
        public SceneData Data { get; set; }

        private Player player;
        private Window screen;
        private Building[] buildings;
        private char[,] background;
        public Scene(string _path, Window _screen, Player _player)
        {
            string jsonData = System.IO.File.ReadAllText(_path);
            Data = JsonSerializer.Deserialize<SceneData>(jsonData);
            player = _player;
            if(Data.Buildings != null)
                buildings = new Building[Data.Buildings.Length];

            screen = _screen;
            
        }

        public void Create()
        {
            player.SetPosition(Data.PlayerStart["X"], Data.PlayerStart["Y"]);
            LoadBackground();
            DrawBackground();

            if(Data.Buildings != null)
            {
                CreateBuildings();

                foreach (Building building in buildings)
                {
                    screen.Add(building);
                    building.Draw();
                }
            }  
        }

        public void CreateBuildings()
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                BuildingData building = Data.Buildings[i];
                string[] colorPalette = building.ColorPalette;

                int eX = building.Entrance["X"];
                int eY = building.Entrance["Y"];
                buildings[i] = new Building(building, screen, building.Path);
            }
        }

        public void LoadBackground()
        {
            string[] backgroundData = System.IO.File.ReadAllLines(Data.Background);
            background = new char[screen.Height, screen.Width];
            for(int y = 0; y < screen.Height; y++)
            {
                for(int x = 0; x < screen.Width; x++)
                {
                    background[y, x] = backgroundData[y][x];
                    screen.Grid[y, x] = background[y, x];
                }
            }
        }

        public void DrawBackground()
        {
            for (int y = 0; y < background.GetLength(0); y++)
            {
                for(int x = 0; x < background.GetLength(1); x++)
                {
                    Console.ForegroundColor = SelectColor(background[y, x]);
                    Console.SetCursorPosition(x, y);
                    Console.Write(background[y, x]);
                    Console.ResetColor();
                }
            }
        }

        public ConsoleColor SelectColor(char cell)
        {
            ConsoleColor color;
            switch (cell)
            {
                case 'E':
                    color = ConsoleColor.DarkRed;
                    break;
                case '^':
                    color = ConsoleColor.Green;
                    break;
                case '▄':
                    color = ConsoleColor.DarkYellow;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
                    
            }
            return color;
        }

        public Building[] Buildings
        {
            get => buildings;
        }
    }
}
