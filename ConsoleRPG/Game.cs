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

            Hub = new Scene("./assets/scenes/Forest1.json", screen, player);
            Hub.Create();
            
        }
        public void Update()
        {
            while (true)
            {
                player.Draw();
                player.Move();
                if (player.EnteredDoor())
                {
                    break;
                }
                //System.Threading.Thread.Sleep(20);
            }
        }

        public void Start()
        {
            Create();
            Update();
        }
    }
}
