using System;

namespace InterfaceGameDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGame game = new WillGame();

            game.Start();

            Console.WriteLine("Please enter player Name(s)");
            string line = "";
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                Console.WriteLine(game.EnterPlayerName(line));
            }

            Console.WriteLine("Game is now beginning!");
            while (!game.IsGameFinished)
            {
                (bool isValid, string output) actionResult = (false, "");

                while ((actionResult = game.TakeTurn(Console.ReadLine())).isValid == false)
                {
                    Console.WriteLine(actionResult.output);
                }

                Console.WriteLine(actionResult.output);
            }

            Console.WriteLine("The Game is now finished, postgame is being shown:");
            game.PostGame();
        }
    }
}
