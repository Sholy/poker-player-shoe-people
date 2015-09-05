using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class GameState
    {
        public List<Player> Players { get; set; }

        public string TournamentId { get; set; }
        public string GameId { get; set; }
        public int Round { get; set; }
        public int BetIndex { get; set; }
        public int SmallBlind { get; set; }
        public int Orbits { get; set; }
        public int Dealer { get; set; }
        
        public void ParseGameState(JObject gameStateObject)
        {
        }
    }
}
