﻿using Microsoft.AspNetCore.Mvc;
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
            model.CurrentDieRoll = 0;
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

        public IActionResult RollDie(int gameID)
        {
            var model = new GameViewModel() { GameID = gameID};
            model.CurrentDieRoll = _ludoProccessor.RollDiece(gameID);
            var game = _ludoProccessor.GameById(gameID);
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;
            model.TimeToMove = true;

            return View("Game", model);
        }

        public IActionResult MovePiece(int pieceID, int gameID, int roll, int currentPlayer)
        {
            _ludoProccessor.MovePiece(gameID, pieceID, roll);
            string temp = _ludoProccessor.EndTurn(gameID, currentPlayer);
            var game = _ludoProccessor.GameById(gameID);
            var model = new GameViewModel() { GameID = gameID};
            model.CurrentPlayerID = game.currentPlayerId;
            model.Players = game._players;
            model.CurrentDieRoll = roll;
            model.TimeToMove = false;

            return View("Game", model);
        }

    }
}