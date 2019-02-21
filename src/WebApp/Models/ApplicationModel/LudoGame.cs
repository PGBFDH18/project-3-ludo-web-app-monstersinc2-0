using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApp.Models.ApplicationModel
{
    public class LudoGame
    {
        
        [JsonProperty(PropertyName = "_players")]
        public List<Player> _players { get; set; }

        [JsonProperty(PropertyName = "_gameState")]
        public string _gameState { get; set; }

        [JsonProperty(PropertyName = "currentPlayerId")]
        public int currentPlayerId { get; set; }
    }
}
