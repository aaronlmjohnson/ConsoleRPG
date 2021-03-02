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
        public Game()
        {

        }
        public void Create()
        {
            screen = new Window();
            player = new Player(0, 0, screen);

            currentScene = new Scene("./assets/scenes/Hub.json", screen, player);
            currentScene.Create();
            
        }
        public void Update()
        {
            while (true)
            {
                player.Draw();
                player.Move();

                if (player.EnteredDoor())
                {
                    for (int i = 0; i < currentScene.Buildings.Length; i++)
                    {
                        if (currentScene.Buildings[i].EntranceX == player.X &&
                            currentScene.Buildings[i].EntranceY == player.Y)
                            player.DisplayHudMessage($"Entered {currentScene.Buildings[i].Name}");

                    }
                }
            }
        }

        public void Start()
        {
            Create();
            Update();
        }

        private void changeScene(Scene scene)
        {
            currentScene = scene;
        }

       
    }
}
