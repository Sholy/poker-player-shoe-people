using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Card> resultCards = new List<Card>();
            try
            {
                IEnumerable<JToken> players = gameState.SelectTokens("players");
                foreach(JToken playerToken in players)
                {
                    IEnumerable<JToken> childrenTokens = playerToken.Children();
                    
                    foreach(JToken child in childrenTokens)
                    {
                        string playerName = (string)child.SelectToken("name");
                        if (playerName == "Shoe People")
                        {
                            JToken holeCards = child.SelectToken("hole_cards");

                            foreach(JToken card in holeCards.Children())
                            {
                                string rank = (string)card.SelectToken("rank");
                                string suit = (string)card.SelectToken("suit");

                                Card resultCard = new Card();
                                resultCard.RankString = rank;
                                resultCard.SuitString = suit;
                                resultCard.Rank = resultCard.ToCardRank(resultCard.RankString);
                                resultCard.Suit = resultCard.ToCardSuit(resultCard.SuitString);
                                resultCard.getCardValue(resultCard);
                                resultCards.Add(resultCard);
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

            if (resultCards.Count == 2)
            {
                Card c1 = resultCards.First();
                Card c2 = resultCards.Last();
                int handIndex = getHandIndex(c1, c2);
                Console.WriteLine(c1);
                Console.WriteLine(c2);
                Console.WriteLine("Hand index: " + handIndex);
                if (handIndex >= 8)
                {
                    return currentBuyIn * currentBuyIn;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return currentBuyIn * currentBuyIn;
            }
        }

        public static int getHandIndex (Card c1,Card c2){
            int baseScore;
            int gap;
            if (c1.index > c2.index) {
                baseScore = (int)c1.index;
            }else{
                baseScore = (int)c2.index;
            }
            if (c1.index == c2.index) {
                baseScore = baseScore * 2;
            }
            if (c1.Suit == c2.Suit) {
                baseScore = baseScore + 2;
            }
            gap = (int)Math.Abs(c1.index - c2.index);
            switch (gap)
            {
                case 0:
                    break;
                case 1:
                    baseScore++;
                    break;
                case 2:
                    baseScore--;
                    break;
                case 3:
                    baseScore -= 2;
                    break;
                case 4:
                    baseScore -= 4;
                    break;
                default:
                    baseScore -= 5;
                    break;

            }
            return baseScore - gap;
        }

        public static void ShowDown(JObject gameState)
        {
            //TODO: Use this method to showdown
        }
    }
}

