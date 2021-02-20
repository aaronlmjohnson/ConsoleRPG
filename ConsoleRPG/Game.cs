using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Game
    {
        private Window screen;
        private Player player;
        private GameObject[] gObjs = new GameObject[2];
        public Game()
        {

        }
        public void Create()
        {
            screen = new Window();
            player = new Player(0, 0, screen);
            screen.Player = player;
            GameObject shop = new GameObject(20, 0, screen, @".\assets\shop.txt");
            GameObject house = new GameObject(0, 10, screen, @".\assets\house.txt");
            gObjs[0] = shop;
            gObjs[1] = house;
            screen.GObjs = gObjs;
        }
        public void Update()
        {
            screen.DrawScene();
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
