using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.FormatModels;
using FHM.Models.FormatViewModels;
using FHM.Models.GameModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FHM.Controllers
{
    public class FormatController : Controller
    {
        private readonly IFormatRepository _formatRepository;


        public FormatController(IFormatRepository formatRepository)
        {
            _formatRepository = formatRepository;
        }

        public IActionResult Index()
        {
            var formats = _formatRepository.GetAllFormats().OrderBy(f => f.Game.GameName).ThenBy(f => f.FormatName);
            var formatViewModel = new FormatViewModel()
            {
                Title = "Formats For All Games",
                Formats = formats.ToList()
            };
            return View(formatViewModel);
        }

        [Authorize]
        public IActionResult AddFormat()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddFormat(Format format)
        {
            if (ModelState.IsValid)
            {
                _formatRepository.AddFormat(format);
                return RedirectToAction("AddFormatComplete");
            }
            return View(format);
        }
        public IActionResult AddFormatComplete()
        {
            return View();
        }
    }
}