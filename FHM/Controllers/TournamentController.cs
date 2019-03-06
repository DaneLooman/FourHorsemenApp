using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models;
using FHM.Models.FormatModels;
using FHM.Models.LinkTables;
using FHM.Models.TournamentModels;
using FHM.Models.TournamentViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FHM.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _context;
        private readonly IFormatRepository _formatContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public TournamentController(ITournamentRepository appDbContext, IFormatRepository formatContext,
           UserManager<ApplicationUser> userManager)
        {
            _context = appDbContext;
            _formatContext = formatContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cancelledTournaments =  _context.GetAllCancelledTournaments().ToList();
            var tournamentViewModel = new TournamentViewModel()
            {
                Title = "Tournaments",
                Games = _context.GetAllGames().ToList(),
                Tournaments = _context.GetAllTournaments().ToList(),
                CancelledTournaments = cancelledTournaments
            };

            if (user is null)
            {
                return View(tournamentViewModel);
            }
            else
            {
                tournamentViewModel.PlayerTournaments = _context.GetAllTournaments(user.Id).ToList();
                return View(tournamentViewModel);
            }   
        }

        // GET: Formats/Create
        public IActionResult Create()
        {
            var games = _context.GetAllGames().ToList();
            var formats = _formatContext.GetAllFormats().ToList();

            var viewModel = new TournamentViewModel
            {
                Games = games,
                Formats = formats
                
            };
            return View(viewModel);
        }

        // POST: Formats/Create
        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _context.AddTournament(tournament);
                return RedirectToAction("Details", tournament.TournamentID);
            }
            return View(tournament);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thing = _context.GetTournamentByID(id);
            if (thing == null)
            {
                return NotFound();
            }

            return View(thing);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournament tournament = _context.GetTournamentByID(id);
            if (tournament == null)
            {
                return NotFound();
            }
            var tournaments = _context.GetAllTournaments();
            var games = _context.GetAllGames().ToList();
            var formats = _formatContext.GetAllFormats().ToList();
            TournamentViewModel viewModel = new TournamentViewModel
            {
               Tournament = tournament,
               Games = games,
               Formats = formats,
            };

            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Edit(Tournament tournament)
        {
            int tournamentID = tournament.TournamentID;
            if (ModelState.IsValid)
            {
                _context.EditTournament(tournament);
                return RedirectToAction("Details", new { id = tournamentID });
            }
            return View(tournament.TournamentID);
        }

        public IActionResult Register(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournament tournament = _context.GetTournamentByID(id);
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (tournament == null)
            {
                return NotFound();
            }
            
            return View(tournament);

        }
        [HttpPost]
        public IActionResult Register(int TournamentID)
        {
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            Tournament tournament = _context.GetTournamentByID(TournamentID);

            Player_Event reg = new Player_Event
            {
                Player = user,
                Event = tournament,
                RegTime = DateTime.Now
            };

            if (user != null && tournament != null)
            {
                _context.RegisterID(reg);
                return RedirectToAction("Index");
            }
            return View(TournamentID);
        }
        public IActionResult DropPlayer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player_Event reg = _context.GetRegistration(id);

            return View(reg);

        }
        [HttpPost]
        public IActionResult DropPlayer(int regID)
        {

            Player_Event reg = _context.GetRegistration(regID);

            if (reg != null)
            {
                _context.DropPlayer(reg);
                return RedirectToAction("Index");
            }
            return View(regID);
        }







    }
}