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
            List<Card> communityCards = new List<Card>();
            try
            {
                // Fetch player cards
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

                // Fetch community cards
                //JToken communityCards = gameState.SelectToken("community_cards");
                //foreach(JToken card in communityCards.Children())
                //{
                //    string rank = (string)card.SelectToken("rank");
                //    string suit = (string)card.SelectToken("suit");

                //    Card resultCard = new Card();
                //    resultCard.RankString = rank;
                //    resultCard.SuitString = suit;
                //    resultCard.Rank = resultCard.ToCardRank(resultCard.RankString);
                //    resultCard.Suit = resultCard.ToCardSuit(resultCard.SuitString);
                //    resultCard.getCardValue(resultCard);
                //    resultCards.Add(resultCard);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            //Random r = new Random();
            //return r.Next(300, 500);

            int bet = currentBuyIn + currentBuyIn;
            if (resultCards.Count == 2)
            {
                Card c1 = resultCards.First();
                Card c2 = resultCards.Last();
                int handIndex = getHandIndex(c1, c2);
                Console.WriteLine(c1);
                Console.WriteLine(c2);
                Console.WriteLine("Hand index: " + handIndex);
                if (handIndex >= 15) {
                    bet = currentBuyIn + currentBuyIn;
                }else if	(handIndex >= 8) {
                    bet = currentBuyIn + currentBuyIn / 2;
                }else if (handIndex >= 6) {
                    bet = currentBuyIn;
                }else{
                    bet = 0;
                }
            }
            else
            {
                bet = currentBuyIn + currentBuyIn / 2;
            }

            Console.WriteLine("Bet: " + bet);
            return bet;
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
                baseScore = baseScore * 2+5;
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

