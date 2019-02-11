using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models;
using WebApp.Models.ApplicationModel;
using WebApp.Models.BindingModel;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {

        public LudoController(ILudoGameAPIProccessor ludoProccessor, IPlayerFormExtractor extractor)
        {
            _ludoProccessor = ludoProccessor;
            _extractor = extractor;
        }

        private ILudoGameAPIProccessor _ludoProccessor { get; }
        private IPlayerFormExtractor _extractor { get; }

        /// <summary>
        /// Retruns an unvalidated new empty form to fill by user
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult NewForm()
        {
            return View("Index");
        }

        /// <summary>
        /// validates entry retruned by form then sends 
        /// request to the LudoAPI with info to start an ew game   
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Eitehr return an index view if 
        /// validation fails along with error messages
        /// or redirect to Game view</returns>
        public IActionResult Index(PlayerBindingModel players)
        {
            if (!ModelState.IsValid)
            {
                return View(players);
            }

            List<Player> addedPlayers = _extractor.AddedPlayers(players);

            int gameID =_ludoProccessor.CreateNewGame();

            foreach (var p in addedPlayers)
            {
                _ludoProccessor.AddNewPalyer(gameID, p.Name, p.PlayerColor);
            }

            _ludoProccessor.StartGame(gameID);

            var model = new GameViewModel() { GameID = gameID};
            model.CurrentDieRoll = 6;
            var game = _ludoProccessor.GameById(gameID);
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;

            return View("Game", model);
            //return RedirectToAction("Game", model);
        }

        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Manual()
        {
            return View();
        }

        public IActionResult Stats()
        {
            return View();
        }


    }
}