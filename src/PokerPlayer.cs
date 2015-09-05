﻿using System;
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
			int currentBuyIn=1;
            try
            {
                currentBuyIn = (int)gameState.SelectToken("current_buy_in");
                Console.WriteLine("Current buy in: " + currentBuyIn);

                IEnumerable<JToken> players = gameState.SelectTokens("players");

                foreach(JToken playerToken in players)
                {
                    JToken holeCards = playerToken.SelectToken("hole_cards");
                    IEnumerable<JToken> cards = holeCards.Values();

                    foreach(JToken card in cards)
                    {
                        string rank = (string) card.SelectToken("rank");
                        string suit = (string)card.SelectToken("suit");

                        Console.WriteLine("rank: " + rank);
                        Console.WriteLine("suit: " + suit);
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
			return currentBuyIn+currentBuyIn;
        }

        public static void ShowDown(JObject gameState)
        {
            //TODO: Use this method to showdown
        }
    }
}

