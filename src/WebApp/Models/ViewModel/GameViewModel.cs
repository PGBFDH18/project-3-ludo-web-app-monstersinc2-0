using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models.ApplicationModel;

namespace WebApp.Models
{
    public class GameViewModel
    {
        public int GameID { get; set; }
        public int CurrentPlayerID { get; set; }
        public int CurrentDieRoll { get; set; }
        public List<Player> Players { get; set; }
        public bool TimeToMove { get; set; } = false;
    }
}
