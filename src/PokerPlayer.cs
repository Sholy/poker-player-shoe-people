using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState)
		{
			//TODO: Use this method to return the value You want to bet
			JToken token = JObject.Parse(gameState);

			int buyIn = (int)token.SelectToken("current_buy_in");
			
			Random r = new Random();
			int result=r.next(10,20)+buyIn;
			return result;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

