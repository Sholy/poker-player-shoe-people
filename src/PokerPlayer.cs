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
            List<Card> resultCards = new List<Card>();
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
                            JToken holeCards = child.SelectToken("hole_cards");

                            foreach(JToken card in holeCards.Children())
                            {
                                Console.WriteLine("reading cards as children");
                                string rank = (string)card.SelectToken("rank");
                                string suit = (string)card.SelectToken("suit");

                                Console.WriteLine("rank child: " + rank);
                                Console.WriteLine("suit child: " + suit);

                                Card resultCard = new Card();
                                resultCard.RankString = rank;
                                resultCard.SuitString = suit;
                                //resultCard.Rank = resultCard.ToCardRank(resultCard.RankString);
                                //resultCard.Suit = resultCard.ToCardSuit(resultCard.SuitString);
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

			double handIndex = getHandIndex (c1, c2);
			if (handIndex >= 8.5) {
				return currentBuyIn * currentBuyIn;
			} else {
				return 0;
			}

            
        }

		public static double getHandIndex (Card c1,Card c2){
			double baseScore;
			double gap;
			if (c1.index > c2.index) {
				baseScore = c1.index;
			}else{
				baseScore = c2.index;
			}
			if (c1.index == c2.index) {
				baseScore = baseScore * 2;
			}
			if (c1.Suit == c2.Suit) {
				baseScore = baseScore + 2;
			}
			gap = Math.Abs (c1.index - c2.index);
			switch (gap) {
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

