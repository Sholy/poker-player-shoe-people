using System;
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            //Random r = new Random();
            //return r.Next(300, 500);
			return currentBuyIn+100;
        }

        public static void ShowDown(JObject gameState)
        {
            //TODO: Use this method to showdown
        }
    }
}

