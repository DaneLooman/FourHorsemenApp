using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.TournamentModels;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}