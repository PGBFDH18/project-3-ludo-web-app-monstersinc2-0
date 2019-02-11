using System.Collections.Generic;
using WebApp.Models.ApplicationModel;

namespace WebApp.Models
{
    public class GameViewModel
    {
        public int GameID { get; set; }
        public string CurrentPlayerName { get; set; }
        public int CurrentDieRoll { get; set; }
        public List<Player> Players { get; set; }

        private LudoGameAPIProccessor api = new LudoGameAPIProccessor();

        public void UpdateCurrentPlayerName()
        {
            var player = api.GetCurrentPlayer(GameID);
            CurrentPlayerName = player.Name;
        }

        public void UpdateCurrentDieRoll()
        {
            CurrentDieRoll = api.RollDiece(GameID);
        }

        public void UpdatePlayers()
        {
            var game = api.GameById(GameID);
            Players = game._players;
        }
    }
}
