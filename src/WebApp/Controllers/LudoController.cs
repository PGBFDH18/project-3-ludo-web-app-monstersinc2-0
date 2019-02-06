using Microsoft.AspNetCore.Mvc;
using WebApp.Models.BindingModel;
using System.Collections.Generic;
namespace WebApp.Controllers
{
    public class LudoController : Controller
    {

        public IActionResult NewForm()
        {
            return View("Index");
        }

        public IActionResult Index(PlayerBindingModel player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            var _player = player;
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