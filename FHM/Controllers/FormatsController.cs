using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FHM.Data;
using FHM.Models.FormatModels;
using FHM.Models.FormatViewModels;

namespace FHM.Controllers
{
    public class FormatsController : Controller
    {
        private readonly IFormatRepository _context;

        public FormatsController(IFormatRepository appDbContext)
        {
            _context = appDbContext;
        }

        // GET: Formats
        public  IActionResult Index()
        {
            return View(_context.GetAllFormats());
        }

        // GET: Formats/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var format = _context.GetAllFormats();
            if (format == null)
            {
                return NotFound();
            }

            return View(format);
        }

        // GET: Formats/Create
        public IActionResult Create()
        {
            var games = _context.GetAllGames();

            var viewModel = new FormatFormViewModel
            {
            Games = games
            };
            return View(viewModel);
        }

        // POST: Formats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Format format)
        {
            if (ModelState.IsValid)
            {
                _context.AddFormat(format);
                return RedirectToAction("AddGameComplete");
            }
            return View(format);
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

            var format =  _context.GetFormatByID(id);
            if (format == null)
            {
                return NotFound();
            }

            return View(format);
        }
    }
}
