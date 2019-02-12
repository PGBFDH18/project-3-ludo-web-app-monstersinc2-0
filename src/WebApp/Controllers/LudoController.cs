using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebApp.Models;
using WebApp.Models.ApplicationModel;
using WebApp.Models.BindingModel;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        /// <summary>
        /// Constructor for the controller that use DI for implmenting two needed class from application model and Logger calss. 
        /// </summary>
        /// <param name="ludoProccessor"></param>
        /// <param name="extractor"></param>
        /// <param name="log"></param>
        public LudoController(
            ILudoGameAPIProccessor ludoProccessor,
            IPlayerFormExtractor extractor,
            ILogger<LudoController> log)
        {
            _ludoProccessor = ludoProccessor;
            _extractor = extractor;
            _log = log;
        }

        private readonly ILogger _log;
        private ILudoGameAPIProccessor _ludoProccessor { get; }
        private IPlayerFormExtractor _extractor { get; }
        private Dictionary<string, int[]> patterns = new Dictionary<string, int[]>
        {
            ["0"] = new int[] { 0, 55, 56, 57, 58, 59, 60, 18, 17, 16,
15, 14, 13, 7, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 37,
38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 19, 20, 21, 22,
23, 24, 72, 71, 70, 69, 68, 67, 61, 62, 63, 64, 65, 66, 73},
            ["1"] = new int[] { 0, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 37,
38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 19, 20, 21, 22,
23, 24, 72, 71, 70, 69, 68, 67, 61, 55, 56, 57, 58, 59, 60, 18, 17, 16,
15, 14, 13, 7, 8, 9, 10, 11, 12, 73},
            ["2"] = new int[] { 0, 37,
38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 19, 20, 21, 22,
23, 24, 72, 71, 70, 69, 68, 67, 61, 55, 56, 57, 58, 59, 60, 18, 17, 16,
15, 14, 13, 7, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 44, 45, 46, 47, 48, 73},
            ["3"] = new int[] { 0, 19, 20, 21, 22,
23, 24, 72, 71, 70, 69, 68, 67, 61, 55, 56, 57, 58, 59, 60, 18, 17, 16,
15, 14, 13, 7, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 37,
38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 26, 27, 28, 29, 30, 73}
        };

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

            int gameID;
            try
            {
                gameID = _ludoProccessor.CreateNewGame();
                _log.LogInformation("New game Created with id: {gameId}.", gameID);
            }
            catch
            {
                _log.LogCritical("Connection to API Lost"); // Logging info 
                throw new Exception("Connection to Api Lost");

            }


            foreach (var p in addedPlayers)
            {
                _ludoProccessor.AddNewPalyer(gameID, p.Name, p.PlayerColor);
            }

            _ludoProccessor.StartGame(gameID);



            var model = new GameViewModel() { GameID = gameID };
            model.CurrentDieRoll = 0;
            var game = _ludoProccessor.GameById(gameID);
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;

            foreach (var p in model.Players)
            {
                p.Pattern = patterns[p.PlayerColor];
            }

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

        public IActionResult RollDie(int gameID)
        {
            var model = new GameViewModel() { GameID = gameID };
            model.CurrentDieRoll = _ludoProccessor.RollDiece(gameID);
            var game = _ludoProccessor.GameById(gameID);
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;
            model.TimeToMove = true;

            foreach (var p in model.Players)
            {
                p.Pattern = patterns[p.PlayerColor];
            }

            return View("Game", model);
        }

        public IActionResult MovePiece(int pieceID, int gameID, int roll, int currentPlayer)
        {
            _ludoProccessor.MovePiece(gameID, pieceID, roll);
            string temp = _ludoProccessor.EndTurn(gameID, currentPlayer);
            var game = _ludoProccessor.GameById(gameID);
            var model = new GameViewModel() { GameID = gameID };
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;
            model.CurrentDieRoll = roll;
            model.TimeToMove = false;

            foreach (var p in model.Players)
            {
                p.Pattern = patterns[p.PlayerColor];
            }

            return View("Game", model);
        }

    }
}