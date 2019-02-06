using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ApplicationModel;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        LudoGameAPIProccessor api = new LudoGameAPIProccessor();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Ludo/Game/{gameID}")]
        public IActionResult Game(int gameID)
        {
            var game = api.GameById(gameID);

            if(game != null && game._gameState == "0")
            {
                ViewBag.GameID = gameID;
                return View();
            }

            return NotFound();
        }
        
        [HttpPost("Ludo/Game")]
        public IActionResult Game()
        {
            var players = new Dictionary<string, int> { };

            for (int i = 0; i < 4; i++)
            {
                if (Request.Form["P" + (i + 1) + "Name"] != "")
                {
                    players.Add(
                        Request.Form["P" + (i + 1) + "Name"],
                        Convert.ToInt32(Request.Form["P" + (i + 1) + "Color"]));
                }
            }

            int gameID = Convert.ToInt32(api.CreateNewGame());

            foreach (var pair in players)
            {
                api.AddNewPlayer(gameID, pair.Key, pair.Value.ToString());
            }

            api.StartGame(gameID);

            ViewBag.GameID = gameID;

            return View(gameID);
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