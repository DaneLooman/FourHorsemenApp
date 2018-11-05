using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FHM.Models.GameViewModels;

namespace FHM.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGames().OrderBy(g => g.GameName);

            var gameViewModel = new GameViewModel()
            {
                Title = "Games at Four Horsemen",
                Games = games.ToList()
            };

            return View(gameViewModel);
        }

        public IActionResult GameDetails(int gameId)
        {
            var game = _gameRepository.GetGameByID(gameId);
            if (game == null)
                return NotFound();

            return View(game);
        }
        [Authorize]
        public IActionResult AddGame()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            if (ModelState.IsValid)
            {
                _gameRepository.AddGame(game);
                return RedirectToAction("AddGameComplete");
            }
            return View(game);
        }

        public IActionResult AddGameComplete()
        {
            return View();
        }

    }
}