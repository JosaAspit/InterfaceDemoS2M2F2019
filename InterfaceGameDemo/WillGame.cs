using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceGameDemo
{
    public class WillGame : IGame
    {

        private bool isGameFinished;
        public bool IsGameFinished { get { return isGameFinished; } }

        private List<string> players;
        private int currentPlayer;

        public string Start()
        {
            players = new List<string>();
            isGameFinished = false;
            currentPlayer = 0;

            return "All set up. /n Starting game";
        }

        public string EnterPlayerName(string name)
        {
           
        }

        public string[] GetHighScores()
        {

        }

        public string EnterHighScore(string playerName, int score)
        {

        }

        public (bool isValid, string output) TakeTurn(string action)
        {

        }

        public void PostGame()
        {

        }


        public string[] GetHighscores()
        {
            throw new NotImplementedException();
        }




        #region Utility
        private string GetPlayerInput(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }
        #endregion
    }
}
