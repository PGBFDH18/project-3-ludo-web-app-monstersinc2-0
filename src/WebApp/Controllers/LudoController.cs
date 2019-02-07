using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ApplicationModel;
using WebApp.Models.BindingModel;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        ILudoGameAPIProccessor _ludoProccessor;
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