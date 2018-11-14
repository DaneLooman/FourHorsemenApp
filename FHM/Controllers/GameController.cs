using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.GameModel;
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

        public IActionResult GameDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _gameRepository.GetGameByID(id);
            if (game == null)
            {
                return NotFound();
            }
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
                // GET: Formats/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _gameRepository.GetGameByID(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }
        [HttpPost]
        public IActionResult Delete(int gameID)
        {
            if (ModelState.IsValid)
            {
                _gameRepository.DeleteGame(gameID);
                return RedirectToAction("Index");
            }
            return View(gameID);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _gameRepository.GetGameByID(id);
            if (game == null)
            {
                return NotFound();
            }
            var games = _gameRepository.GetAllGames();

            return View(game);

        }
        [HttpPost]
        public IActionResult Edit(Game game)
        {
            int gameID = game.GameID;
            if (ModelState.IsValid)
            {
                _gameRepository.EditGame(game);
                return RedirectToAction("GameDetails", new { id = gameID });
            }
            return View(game.GameID);
        }

    }
}