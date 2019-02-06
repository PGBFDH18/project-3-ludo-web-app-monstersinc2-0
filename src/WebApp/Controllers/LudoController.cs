using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        List<Guid> sessionIds = new List<Guid> { };

        public IActionResult Index()
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

        public IActionResult Game()
        {
            return View();
        }
        
        public bool OnPost()
        {
            var players = new List<string> { };
            foreach (var p in Request.Form)
            {
                if (p.Value != "" && p.Key != "__RequestVerificationToken")
                    players.Add(p.Value);
            }
            if (players.Count < 2 || players.Count > 4)
                return false;

            return true;
        }
    }
}