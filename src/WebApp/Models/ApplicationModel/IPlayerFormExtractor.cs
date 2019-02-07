using System.Collections.Generic;
using WebApp.Models.BindingModel;

namespace WebApp.Models.ApplicationModel
{
    public interface IPlayerFormExtractor
    {
        /// <summary>
        /// Return a dictionary with players names and colors
        /// </summary>
        /// <param name="P">Object with values from user from form in View.Ludo.Index.cshtml</param>
        /// <returns></returns>
        Dictionary<string, string> AddedPlayers(PlayerBindingModel P);
    }
}
