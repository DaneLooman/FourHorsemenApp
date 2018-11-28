using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models;
using FHM.Models.TournamentModels;
using FHM.Models.TournamentViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FHM.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _context;
        public TournamentController(ITournamentRepository appDbContext)
        {
            _context = appDbContext;
        }

        //private readonly UserManager<ApplicationUser> _userManager;


        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.GetUserAsync(User);

            var tournamentViewModel = new TournamentViewModel()
            {
                Title = "Tournaments",
                Games = _context.GetAllGames().ToList(),
                Tournaments = _context.GetAllTournaments().ToList()
            };

            return View(tournamentViewModel);
        }
    }
}