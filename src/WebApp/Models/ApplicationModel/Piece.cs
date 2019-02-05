﻿using Newtonsoft.Json;

namespace WebApp.Models.ApplicationModel
{
    public class Piece
    {
        [JsonProperty(PropertyName = "pieceId")]
        public int PieceId { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }
    }
}
