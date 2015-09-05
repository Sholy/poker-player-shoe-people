using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
    {
        public static readonly string VERSION = "Default C# folding player";

        public static int BetRequest(JObject gameState)
        {
            //TODO: Use this method to return the value You want to bet
            int currentBuyIn = (int)gameState.SelectToken("current_buy_in");
            try
            {
                IEnumerable<JToken> players = gameState.SelectTokens("players");
                IEnumerable<JToken> gameChildren = gameState.Children();
                foreach(JToken child in gameChildren)
                {
                    //Console.WriteLine(child);
                }
                Console.WriteLine("players parsed");


                foreach(JToken playerToken in players)
                {
                    IEnumerable<JToken> childrenTokens = playerToken.Children();
                    
                    foreach(JToken child in childrenTokens)
                    {
                        string playerName = (string)child.SelectToken("name");
                        Console.WriteLine("pl name: " + playerName);
                        if (playerName == "Shoe People")
                        {
                            JToken holeCards = playerToken.SelectToken("hole_cards");

                            IEnumerable<JToken> cards = holeCards.Values();
                            Console.WriteLine("hole cards type: " + holeCards.Type);
                            Console.WriteLine("cards: " + cards.ToString());
                            Console.WriteLine("parsed cards");

                            foreach (JToken card in cards)
                            {
                                Console.WriteLine("reading cards");
                                string rank = (string)card.SelectToken("rank");
                                string suit = (string)card.SelectToken("suit");

                                Console.WriteLine("rank: " + rank);
                                Console.WriteLine("suit: " + suit);
                            }
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            //Random r = new Random();
            //return r.Next(300, 500);
            return currentBuyIn*currentBuyIn;
        }

        public static void ShowDown(JObject gameState)
        {
            //TODO: Use this method to showdown
        }
    }
}

