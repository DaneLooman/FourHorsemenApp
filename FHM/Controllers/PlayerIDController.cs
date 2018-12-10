using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models;
using FHM.Models.PlayerIDModel;
using FHM.Models.PlayerIdViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FHM.Controllers
{
    public class PlayerIDController : Controller
    {
        private readonly IPlayerIDRepository _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerIDController(IPlayerIDRepository context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var playerIDs = _context.GetAllPlayerIDsByPlayer(user.Id);
            return View(playerIDs);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var games = _context.GetAllGames();
            var players = _context.GetAllPlayers();

            var viewModel = new PlayerIdViewModel
            {
                Games = games,
                Players = players,
                UserID = user.Id
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