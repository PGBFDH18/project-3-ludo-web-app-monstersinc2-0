using System.Collections.Generic;
using WebApp.Models.ApplicationModel;

namespace WebApp.Models.BindingModel

{
    public class PlayerFormExtractor : IPlayerFormExtractor
    {
        public PlayerFormExtractor()
        {
            players = new List<Player>();
        }

        public List<Player> players;

        /// <summary>
        /// Return a dictionary with players names and colors
        /// </summary>
        /// <param name="P">Object with values from user from form in View.Ludo.Index.cshtml</param>
        /// <returns></returns>
        public List<Player> AddedPlayers(PlayerBindingModel P)
        {
            if (P.Player1Name != null)
                players.Add(new Player { Name = P.Player1Name, PlayerColor = P.Color1.ToString() });
            if (P.Player2Name != null)
                players.Add(new Player { Name = P.Player2Name, PlayerColor = P.Color2.ToString() });
            if (P.Player3Name != null)
                players.Add(new Player { Name = P.Player3Name, PlayerColor = P.Color3.ToString() });
            if (P.Player4Name != null)
                players.Add(new Player { Name = P.Player4Name, PlayerColor = P.Color4.ToString() });

            return players;

        }


    }
}
