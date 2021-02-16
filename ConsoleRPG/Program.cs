using System;


namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Window screen = new Window();
            Player player = new Player(0, 0, screen.Height, screen.Width);
            screen.Player = player;
            GameObject shop = new GameObject(20, 0, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\shop.txt");
            GameObject house = new GameObject(0, 10, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\house.txt");
            GameObject[] gObjs = { shop, house };

            screen.GObjs = gObjs;
            


            

            //screen.Draw(shop);
            //screen.Draw(house);
            //screen.Draw(player);

            screen.Update();




        }
    }
}
