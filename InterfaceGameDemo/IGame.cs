using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceGameDemo
{
    public interface IGame
    {
        //Properties
        bool IsGameFinished { get; }

        //Methods
        string Start();
        string EnterPlayerName(string Name);
        string[] GetHighscores();
        string EnterHighScore(string playerName, int Score);
        (bool isValid, string output) TakeTurn(string action);
        void PostGame();
    }
}
