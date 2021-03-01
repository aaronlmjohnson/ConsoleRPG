using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Game
    {
        private Window screen;
        private Player player;
        private Scene Hub;
        public Game()
        {

        }
        public void Create()
        {
            screen = new Window();
            player = new Player(0, 0, screen);

            Hub = new Scene("./assets/scenes/Hub.json", screen, player);
            Hub.Create();
            
        }
        public void Update()
        {
            Scene currentScene = Hub;
            while (true)
            {
                player.Update(currentScene);
            }
        }

        public void Start()
        {
            Create();
            Update();
        }
    }
}
