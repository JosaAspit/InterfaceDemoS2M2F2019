using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace InterfaceGameDemo
{
    public class WillGame : IGame
    {

        private bool isGameFinished;
        public bool IsGameFinished { get { return isGameFinished; } }

        private List<List<string>> players;
        private int currentPlayer;
        private int numOfRounds;
        private int roundNumber;

        public string Start()
        {
            players = new List<List<string>>();
            isGameFinished = false;
            currentPlayer = 0;
            roundNumber = 1;

            while (!int.TryParse(AskPlayer("How many rounds should there be ?"), out numOfRounds))
            {
                Console.WriteLine("That is not a valid number. Try again...");
            }

            return "All set up. /n Starting game";
        }

        public string EnterPlayerName(string name)
        {
            if (name == "AI")
                return "You're not an AI";


            if (name.ToLower() == "start")
                players.Add(new List<string>() { "AI", "0" });

            if (players.Count > 2)
                return "Max players reached";

            players.Add(new List<string>() { name, "0" });
            Console.WriteLine("To play with an AI type: Start");

            return "Player Added";
        }


        public string EnterHighScore(string playerName, int score)
        {
            return "";
        }

        public (bool isValid, string output) TakeTurn(string action)
        {
            if (roundNumber > numOfRounds)
            {
                isGameFinished = true;
                if (int.Parse(players[0][1]) > int.Parse(players[1][1]))
                {
                    Console.WriteLine($"{players[0][0]} Won the game!");
                    Console.WriteLine(GetCurrentScores());
                }
                return (true, "Game is over");
            }

            Console.Clear();
            string output = "";
            int winner;

            string player2Action = "paper";

            Console.WriteLine($"Round {roundNumber} /n" + GetCurrentScores());


            // player 1 input checks
            action = action.ToLower();
            if (IsValidAction(action))
            {
                output = $"{action} is not a valid action. /n You can use the following: 'Rock' 'Paper' 'Scissors' ";
                return (false, output);
            }
            Thread.Sleep(500);

            if (players[1][0] == "AI")
            {
                winner = DetermineRoundWinner(action, GetAiChoice());
            }
            else // player 2 input
            {
                Console.Clear();
                Console.WriteLine($"Round {roundNumber} /n" + GetCurrentScores());

                while (!IsValidAction(player2Action = AskPlayer($"{players[1][0]} what do you choose?")))
                {
                    output = $"{player2Action} is not a valid action. /n You can use the following: 'Rock' 'Paper' 'Scissors' ";
                    Console.WriteLine(output);
                }
                winner = DetermineRoundWinner(action, player2Action);
            }


            output = $"{players[winner][0]} Won the round!";
            roundNumber++;

            return (true, output);
        }

        private string GetAiChoice()
        {
            return "scissors";
        }

        public void PostGame()
        {

        }

        private int DetermineRoundWinner(string player1Action, string player2Action)
        {
            return 0;
        }


        #region Utility

        private string AskPlayer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine().ToLower();
        }
        private string GetCurrentScores()
        {
            string scores;
            if (int.Parse(players[0][1]) > int.Parse(players[1][1]))
            {
                scores = $"{players[0][0]} leads with: {players[0][1]} / {players[1][1]}";
            }
            else
            {
                scores = $"{players[1][0]} leads with: {players[1][1]} / {players[0][1]}";
            }
            return scores;
        }
        private bool IsValidAction(string action)
        {
            return action == "scissors" || action == "rock" || action == "paper" ? true : false;
        }

        public string[] GetHighscores()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
