using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceGameDemo
{
    class AsgerGame : IGame
    { 
        private List<Card> Player1Cards = new List<Card>();
        private List<Card> Player2Cards = new List<Card>();
        private List<string> players = new List<string>();
        public bool IsGameFinished { get; set; }
        

        public string EnterHighScore(string playerName, int Score)
        {
            throw new NotImplementedException();
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
            ShuffleAndDeal();
            
            return "start game!";
        }

        public (bool isValid, string output) TakeTurn(string action)
        {
            if (Player1Cards.Count == 0)
            {
                IsGameFinished = true;
                return (true, "Player 1 doesn't have any cards. Player 2 wins the game!\n");
            }
            if (Player2Cards.Count == 0)
            {
                IsGameFinished = true;
                return (true, "Player 2 doesn't have any cards. Player 1 wins the game!\n");
            }
            string output = $"Player 1 has {Player1Cards[0].Name} of {Player1Cards[0].Color} \n Player 2 has {Player2Cards[0].Name} of {Player2Cards[0].Color} \n";
            if (Player1Cards[0].Value > Player2Cards[0].Value)
            {
                Player1Cards.Add(Player2Cards[0]);
                Player2Cards.Remove(Player2Cards[0]);
                Player1Cards.Add(Player1Cards[0]);
                Player1Cards.Remove(Player1Cards[0]);
                output += "Player 1 wins! \n";
            }
            else if (Player2Cards[0].Value > Player1Cards[0].Value)
            {
                Player2Cards.Add(Player1Cards[0]);
                Player1Cards.Remove(Player1Cards[0]);
                Player2Cards.Add(Player2Cards[0]);
                Player2Cards.Remove(Player2Cards[0]);
                output += "Player 2 wins! \n";
            }
            else
            {
                bool e = true;
                List<Card> cardPool = new List<Card>();
                while (e)
                {
                    output += "war! \n";
                    if (Player1Cards.Count < 5)
                    {
                        IsGameFinished = true;
                        return (true, output += "Player 1 doesn't have enught cards. Player 2 wins the game!\n");
                    }
                    if (Player2Cards.Count < 5)
                    {
                        IsGameFinished = true;
                        return (true, output += "Player 2 doesn't have enught cards. Player 1 wins the game!\n");
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        cardPool.Add(Player1Cards[0]);
                        Player1Cards.Remove(Player1Cards[0]);
                        cardPool.Add(Player2Cards[0]);
                        Player2Cards.Remove(Player2Cards[0]);
                    }
                    output += $"Player 1 has {Player1Cards[0].Name} of {Player1Cards[0].Color} \n Player 2 has {Player2Cards[0].Name} of {Player2Cards[0].Color} \n";
                    if (Player1Cards[0].Value > Player2Cards[0].Value)
                    {
                        cardPool.Add(Player1Cards[0]);
                        Player1Cards.Remove(Player1Cards[0]);
                        cardPool.Add(Player2Cards[0]);
                        Player2Cards.Remove(Player2Cards[0]);
                        foreach (Card card in cardPool)
                        {
                            Player1Cards.Add(card);
                            e = false;
                        }
                        output += $"Player 1 wins {cardPool.Count} cards!\n";
                    }
                    else if (Player2Cards[0].Value > Player1Cards[0].Value)
                    {
                        cardPool.Add(Player1Cards[0]);
                        Player1Cards.Remove(Player1Cards[0]);
                        cardPool.Add(Player2Cards[0]);
                        Player2Cards.Remove(Player2Cards[0]);
                        foreach (Card card in cardPool)
                        {
                            Player2Cards.Add(card);
                            e = false;
                        }
                        output += $"Player 1 wins {cardPool.Count} cards!\n";
                    }
                }
            }
            output += $"Player 1 has {Player1Cards.Count} cards. \n Player 2 has {Player2Cards.Count} cards. \n";
            return (true, output);
        }

        private void ShuffleAndDeal()
        {
            List<Card> Cards = new List<Card>()
        {
            new Card("Hearts", 1, "two"),
            new Card("Hearts", 2, "three"),
            new Card("Hearts", 3, "four"),
            new Card("Hearts", 4, "five"),
            new Card("Hearts", 5, "six"),
            new Card("Hearts", 6, "seven"),
            new Card("Hearts", 7, "eight"),
            new Card("Hearts", 8, "nine"),
            new Card("Hearts", 9, "ten"),
            new Card("Hearts", 10, "jack"),
            new Card("Hearts", 11, "queen"),
            new Card("Hearts", 12, "king"),
            new Card("Hearts", 13, "ace"),
            new Card("Hearts", 1, "two"),
            new Card("Diamonds", 2, "three"),
            new Card("Diamonds", 3, "four"),
            new Card("Diamonds", 4, "five"),
            new Card("Diamonds", 5, "six"),
            new Card("Diamonds", 6, "seven"),
            new Card("Diamonds", 7, "eight"),
            new Card("Diamonds", 8, "nine"),
            new Card("Diamonds", 9, "ten"),
            new Card("Diamonds", 10, "jack"),
            new Card("Diamonds", 11, "queen"),
            new Card("Diamonds", 12, "king"),
            new Card("Diamonds", 13, "ace"),
            new Card("Clubs", 1, "two"),
            new Card("Clubs", 2, "three"),
            new Card("Clubs", 3, "four"),
            new Card("Clubs", 4, "five"),
            new Card("Clubs", 5, "six"),
            new Card("Clubs", 6, "seven"),
            new Card("Clubs", 7, "eight"),
            new Card("Clubs", 8, "nine"),
            new Card("Clubs", 9, "ten"),
            new Card("Clubs", 10, "jack"),
            new Card("Clubs", 11, "queen"),
            new Card("Clubs", 12, "king"),
            new Card("Clubs", 13, "ace"),
            new Card("Spades", 1, "two"),
            new Card("Spades", 2, "three"),
            new Card("Spades", 3, "four"),
            new Card("Spades", 4, "five"),
            new Card("Spades", 5, "six"),
            new Card("Spades", 6, "seven"),
            new Card("Spades", 7, "eight"),
            new Card("Spades", 8, "nine"),
            new Card("Spades", 9, "ten"),
            new Card("Spades", 10, "jack"),
            new Card("Spades", 11, "queen"),
            new Card("Spades", 12, "king"),
            new Card("Spades", 13, "ace")
        };
            List<Card> randomList = new List<Card>();

            Random r = new Random();
            int randomIndex = 0;
            while (Cards.Count > 0)
            {
                randomIndex = r.Next(0, Cards.Count); //Choose a random object in the list
                randomList.Add(Cards[randomIndex]); //add it to the new, random list
                Cards.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            SplitCards(randomList);

        }

        private void SplitCards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (i%2 == 0)
                {
                    Player1Cards.Add(cards[i]);
                }
                else
                {
                    Player2Cards.Add(cards[i]);
                }
            }
        }
    }
}
