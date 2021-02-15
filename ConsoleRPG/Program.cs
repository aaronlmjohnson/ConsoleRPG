using System;


namespace ConsoleRPG
{
    class Program
    {
        
        

        
        static void Main(string[] args)
        {
            Window screen = new Window();
           screen.Fill(' ');


            //GameObject shop = new GameObject(50, 0, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\shop.txt");
            //GameObject house = new GameObject(0, 10, @"C:\Users\Aaron\Desktop\c# projects\ConsoleRPG\assets\house.txt");
            Player player = new Player(0, 0, screen);
            //screen.Draw(shop);
            //screen.Draw(house);
            //screen.Draw(player);
            //screen.Draw(house);

            screen.Update(player);




        }
    }
}
