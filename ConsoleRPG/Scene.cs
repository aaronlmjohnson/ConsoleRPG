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
        public Scene(string _path, Window _screen, Player _player)
        {
            string jsonData = System.IO.File.ReadAllText(_path);
            Data = JsonSerializer.Deserialize<SceneData>(jsonData);
            player = _player;
            buildings = new Building[Data.Buildings.Length];
            screen = _screen;
            
        }

        public void Create()
        {
            player.SetPosition(Data.PlayerStart["X"], Data.PlayerStart["Y"]);
            player.Draw();
            CreateBuildings();
            foreach(Building building in buildings)
            {
                screen.Add(building);
                building.Draw();
            }
                
        }

        public void CreateBuildings()
        {

            
            for (int i = 0; i < buildings.Length; i++)
            {
                //BuildingData[]  = Data.Buildings;
                BuildingData building = Data.Buildings[i];
                //ConsoleColor[] colorPalette = new ConsoleColor[] { ConsoleColor.DarkYellow, ConsoleColor.Green, ConsoleColor.DarkBlue };
                string[] colorPalette = building.ColorPalette;
                buildings[i] = new Building(building.Position["X"], building.Position["Y"], screen, building.Path, colorPalette);
            }

          //  GameObject[] _objs = ;
           // return _objs;
        }
    }
}
