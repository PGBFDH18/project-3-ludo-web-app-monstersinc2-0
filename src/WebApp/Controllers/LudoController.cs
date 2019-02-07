using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models.ApplicationModel;
using WebApp.Models.BindingModel;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        ILudoGameAPIProccessor _ludoProccessor = new LudoGameAPIProccessor();
        IPlayerFormExtractor _players = new PlayerFormExtractor();


        public IActionResult NewForm()
        {
            return View("Index");
        }

        public IActionResult Index(PlayerBindingModel players)
        {
            if (!ModelState.IsValid)
            {
                return View(players);
            }

            Dictionary<string, string> addedPlayers = _players.AddedPlayers(players);
            _ludoProccessor.CreateNewGame();
            foreach (KeyValuePair<string, string> p in addedPlayers)
            {
                _ludoProccessor.AddNewPalyer(1, p.Value, p.Key); // GameId is 1 for now As I need to get the new API from YOU, Joke.
            }
            _ludoProccessor.StartGame(1);



            return RedirectToAction("Game");
        }

        public IActionResult Manual()
        {
            return View();
        }

        public IActionResult Stats()
        {
            return View();
        }

        public IActionResult Game()
        {
            return View();
        }

    }
}