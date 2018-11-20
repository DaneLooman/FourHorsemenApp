using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.PlayerIDModel;
using FHM.Models.PlayerIdViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FHM.Controllers
{
    public class PlayerIDController : Controller
    {
        private readonly IPlayerIDRepository _context;

        public PlayerIDController(IPlayerIDRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var playerIDs = _context.GetAllPlayerIDs();
            return View(playerIDs);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerID = _context.GetPlayerIDByID(id);
            if (playerID == null)
            {
                return NotFound();
            }

            return View(playerID);
        }
        public IActionResult Create()
        {
            var games = _context.GetAllGames();
            var players = _context.GetAllPlayers();

            var viewModel = new PlayerIdViewModel
            {
                Games = games,
                Players = players

            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PlayerIdViewModel playerID)
        {
            if (ModelState.IsValid)
            {
                _context.AddPlayerIdView(playerID);
                return RedirectToAction("Index");
            }
            return View(playerID);
        }
    }
}