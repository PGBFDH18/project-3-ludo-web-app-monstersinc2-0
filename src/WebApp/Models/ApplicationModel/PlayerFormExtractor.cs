using System.Collections.Generic;
using WebApp.Models.ApplicationModel;

namespace WebApp.Models.BindingModel

{
    public class PlayerFormExtractor : IPlayerFormExtractor
    {
        public PlayerFormExtractor()
        {
            players = new Dictionary<string, string>();
        }

        public Dictionary<string, string> players;

        /// <summary>
        /// Return a dictionary with players names and colors
        /// </summary>
        /// <param name="P">Object with values from user from form in View.Ludo.Index.cshtml</param>
        /// <returns></returns>
        public Dictionary<string, string> AddedPlayers(PlayerBindingModel P)
        {
            if (P.Player1Name != null)
                players.Add(P.Color1.ToString(), P.Player1Name);
            if (P.Player2Name != null)
                players.Add(P.Color2.ToString(), P.Player2Name);
            if (P.Player3Name != null)
                players.Add(P.Color3.ToString(), P.Player3Name);
            if (P.Player4Name != null)
                players.Add(P.Color4.ToString(), P.Player4Name);

            return players;

        }


    }
}
