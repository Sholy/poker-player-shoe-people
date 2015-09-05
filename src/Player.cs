using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class Player
    {
        public List<Card> HoleCards { get; set; }
        public string Name { get; set; }
        public int Stack { get; set; }
        public string Status { get; set; }
        public int Bet { get; set; }
        public string Version { get; set; }
        public int Id { get; set; }

        public bool IsActive
        {
            get
            {
                return Status == "active";
            }
        }

        public void ParsePlayer(JObject playerObject)
        {
            Name = (string)playerObject.SelectToken("name");
            Stack = (int)playerObject.SelectToken("stack");
            Status = (string)playerObject.SelectToken("status");
            Bet = (int)playerObject.SelectToken("bet");
            Version = (string)playerObject.SelectToken("version");
        }
    }
}
