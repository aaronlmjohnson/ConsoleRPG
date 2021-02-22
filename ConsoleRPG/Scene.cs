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

        public Scene(string _path, Player _player)
        {
            string jsonData = System.IO.File.ReadAllText(_path);
            Data = JsonSerializer.Deserialize<SceneData>(jsonData);
            player = _player;
        }

        public string Create()
        {
            string sceneStr = "";
            for(int y = 0; y < Data.Height; y++) { 
                for(int x = 0; x < Data.Width; x++)
                {
                    if(x == Data.PlayerStart["X"] && y == Data.PlayerStart["Y"])
                    {
                        sceneStr += player.body;
                    }
                    else
                    {
                        sceneStr += ' ';
                    }
                }
                sceneStr += "\n";
            }
            return sceneStr;
        }
    }
}
