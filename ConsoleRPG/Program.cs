using System;
using System.Text.Json;
using System.Collections.Generic;


namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game consoleRPG = new Game();
            //consoleRPG.Start();

            string fileName = @".\assets\startScene.json";
            string startJson = System.IO.File.ReadAllText(fileName);
            var scene = JsonSerializer.Deserialize<SceneData>(startJson);
            Console.Write(scene.PlayerStart);
            //IDictionary<string, int> playerStart = new Dictionary<string, int>();

            //playerStart.Add("x", 10);
            //playerStart.Add("y", 10);
            //Console.WriteLine(playerStart["x"]); 
        }
    }
}
