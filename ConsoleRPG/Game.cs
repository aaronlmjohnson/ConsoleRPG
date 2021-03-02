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
                    foreach(Building building in currentScene.Buildings)
                    {
                        if(building.EntranceX == player.X && building.EntranceY == player.Y)
                        {
                            Console.SetCursorPosition(71, 0);
                            
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
