using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InterfaceGameDemo
{
    /// <summary>
    /// Kryds og Bolle spillet
    /// </summary>
    public class JosaGame : IGame
    {
        private bool isGameFinished;
        private List<string> players = new List<string>();
        private string[,] map = new string[3, 3] { { "   ", "   ", "   " }, { "   ", "   ", "   " }, { "   ", "   ", "   " } };
        private int currentPlayer = 0;
        int turns = 0;

        public bool IsGameFinished
        {
            get
            {
                return isGameFinished;
            }
        }

        public string EnterHighScore(string playerName, int score)
        {
            string filePath = "C:/output/josaGameHighScores.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{playerName} - {score}");
                }
                return "Highscore was successfully updated";
            }
            catch (Exception ex)
            {
                return $"Error in adding highscore: {ex.Message}";
            }
        }

        public string EnterPlayerName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Please enter a players name";
            }

            if (players.Count < 2)
            {
                players.Add(name);
                if (players.Count == 2)
                {
                    return "Max players reached";
                }
                else
                {
                    return "Player added, please add another";
                }
            }
            else
            {
                return "Cant add more than 2 players";
            }

        }

        public string[] GetHighscores()
        {
            throw new NotImplementedException();
        }
        public void PostGame()
        {
            throw new NotImplementedException();
        }


        public string Start()
        {
            string output = "Game has finished setting up \n Here's the playing field:";
            output += $"{map[0, 0]} | {map[0, 1]} | {map[0, 2]}\n";
            output += $"{map[1, 0]} | {map[1, 1]} | {map[1, 2]}\n";
            output += $"{map[2, 0]} | {map[2, 1]} | {map[2, 2]}";

            return output;
        }

        /// <summary>
        /// main logic for the round
        /// </summary>
        /// <param name="action">a coordinate for where the player wants their symbol placed</param>
        /// <returns></returns>
        public (bool isValid, string output) TakeTurn(string action)
        {
            int curplayer = currentPlayer % 2;
            string output = "This is the board after your turn: \n";

            int x = 0;
            int y = 0;
            try
            {
                x = int.Parse(action.Split(',')[0]);
                y = int.Parse(action.Split(',')[1]);
            }
            catch (Exception)
            {
                return (false, "skriv nogle tal mellem 0 og 2, mand");
            }

            if (curplayer == 0)
            {
                map[x, y] = " x ";
            }
            else
            {
                map[x, y] = " o ";
            }

            output += $"{map[0, 0]} | {map[0, 1]} | {map[0, 2]}\n";
            output += $"{map[1, 0]} | {map[1, 1]} | {map[1, 2]}\n";
            output += $"{map[2, 0]} | {map[2, 1]} | {map[2, 2]}";

            currentPlayer++;
            turns++;
            return (true, output);
        }
    }
}
