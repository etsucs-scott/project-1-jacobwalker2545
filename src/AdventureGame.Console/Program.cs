using System;                 
using AdventureGame.Core;      

namespace AdventureGameUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Adventure Game"; 

            var engine = new GameEngine(); 

            Console.Clear();
            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("Controls: W = up, A = left, S = down, D = right");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true);

            engine.Run(); 

            Console.WriteLine("Thanks for playing!");
        }
    }
}

