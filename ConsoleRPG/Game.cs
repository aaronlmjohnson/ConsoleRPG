using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Game
    {
        private Window screen;
        private Player player;
        private Scene currentScene;
        private Hud hud;
        public Game()
        {

        }
        public void Create()
        {
            screen = new Window();
            player = new Player(0, 0, screen);

            currentScene = new Scene("./assets/scenes/Hub.json", screen, player);
            currentScene.Create();
            hud = new Hud(player);
            
        }
        public void Update()
        {
            while (true)
            {
                hud.PlayerPosition();
                if(player.Active)
                {
                    player.Draw();
                    player.Move();
                }
                    

                if (player.EnteredDoor())
                {
                    foreach(Building building in currentScene.Buildings)
                    {
                        if(building.EntranceX == player.X && building.EntranceY == player.Y)
                        {
                            player.Active = false;
                            changeScene(building.entrancePath);
                        }
                    }
                }
            }
        }

        public void Start()
        {
            Create();
            Update();
        }

        private void changeScene(string path)
        {
            currentScene = new Scene(path, screen, player);
            screen.Clear();
            currentScene.Create();
            
        }

       
    }
}
