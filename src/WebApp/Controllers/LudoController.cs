using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApp.Models;
using WebApp.Models.ApplicationModel;
using WebApp.Models.BindingModel;
using System.IO;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        /// <summary>
        /// Constructor for the controller that use DI for implmenting two classes from application model and Logger calss. 
        /// </summary>
        /// <param name="ludoProccessor"></param>
        /// <param name="extractor"></param>
        /// <param name="log"></param>
        public LudoController(ILudoGameAPIProccessor ludoProccessor, IPlayerFormExtractor extractor, ILogger<LudoController> log)
        {
            _ludoProccessor = ludoProccessor;
            _extractor = extractor;
            _log = log;
        }

        private readonly ILogger _log;
        private ILudoGameAPIProccessor _ludoProccessor { get; }
        private IPlayerFormExtractor _extractor { get; }

        /// <summary>
        /// Retruns an unvalidated new empty form to fill by user
        /// </summary>
        /// <returns>Index view</returns>

        [Route("Ludo")]
        [Route("Ludo/{gameID}")]
        public IActionResult Index(int? gameID)
        {
            if (gameID == null)
            {
                return View(_ludoProccessor);
            }

            var model = CreateGameViewModel((int)gameID);

            return View("Game", model);
        }

        public IActionResult Manual()
        {
            return View();
        }

        public IActionResult Stats()
        {
            var model = _ludoProccessor.GetStats();

            return View(model);
        }

        /// <summary>
        /// validates entry retruned by form then sends 
        /// request to the LudoAPI with info to start an ew game   
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Eitehr return an index view if 
        /// validation fails along with error messages
        /// or redirect to Game view</returns>
        public IActionResult CreateGame(PlayerBindingModel players)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateGame", players);
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
                _log.LogError("Connection to API Lost"); // Logging info 
                return View("TemporarErrorPage");
            }

            foreach (var p in addedPlayers)
            {
                _ludoProccessor.AddNewPalyer(gameID, p.Name, p.PlayerColor);
            }

            _ludoProccessor.StartGame(gameID);

            var model = CreateGameViewModel(gameID);

            return View("Game", model);
        }

        public GameViewModel CreateGameViewModel(int gameID)
        {
            var model = new GameViewModel() { GameID = gameID };
            model.CurrentDieRoll = 0;
            var game = _ludoProccessor.GameById(gameID);
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;
            if (game._gameState == "2")
            {
                model.Winner = _ludoProccessor.GetWinner(gameID);
            }

            return model;
        }

        /// <summary>
        /// Calls to the API to Rolle a dice for a specific game 
        /// and orders the Razo engine to render Game View
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns>Game ViewResult</returns>
        public IActionResult RollDie(int gameID)
        {
            var model = new GameViewModel() { GameID = gameID };
            model.CurrentDieRoll = _ludoProccessor.RollDiece(gameID);
            var game = _ludoProccessor.GameById(gameID);
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;
            model.TimeToMove = true;

            _log.LogInformation("Dice returned {DiceRollResult}, game id {gameId}", model.CurrentDieRoll, gameID); // Logging
            
            return View("Game", model);
        }

        /// <summary>
        /// Calls to the API to move a selected piece in a specific game 
        /// and orders the Razo engine to render Game View
        /// </summary>
        /// <param name="pieceID"></param>
        /// <param name="gameID"></param>
        /// <param name="roll"></param>
        /// <param name="currentPlayer"></param>
        /// <returns>Game ViewResutl</returns>
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
            if (game._gameState == "2")
            {
                model.Winner = _ludoProccessor.GetWinner(gameID);
                _ludoProccessor.AddWinner(model.Winner.Name);
            }

            _log.LogInformation("Dice returned {DiceRollResult} for the currnet player " +
                                "with ID {CurretnPalyerID}, game id {gameId}", roll, currentPlayer, gameID); // Logging
            
            return View("Game", model);
        }

    }
}