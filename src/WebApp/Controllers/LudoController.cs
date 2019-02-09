using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models.ApplicationModel;
using WebApp.Models.BindingModel;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {

        private ILudoGameAPIProccessor _ludoProccessor { get; }
        private IPlayerFormExtractor _extractor { get; }
        public LudoController(ILudoGameAPIProccessor ludoProccessor, IPlayerFormExtractor extractor)
        {
            _ludoProccessor = ludoProccessor;
            _extractor = extractor;
        }


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

            List<Player> addedPlayers = _extractor.AddedPlayers(players);
            _ludoProccessor.CreateNewGame();
            foreach (var p in addedPlayers)
            {
                _ludoProccessor.AddNewPalyer(1, p.Name, p.PlayerColor); // GameId is 1 for now As I need to get the new API from YOU, Joke.
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