using FHM.Models.FormatModels;
using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.FormatViewModels
{
    public class FormatFormViewModel
    {
        public IEnumerable<Game> Games { get; set; }

        public int? FormatID { get; set; }

        [Display(Name = "Game")]
        [Required]
        public int GameID { get; set; }

        [Display(Name = "Format Name")]
        [Required]
        public string FormatName { get; set; }

        [Display(Name = "Format Description")]
        [Required]
        public string FormatDescription { get; set; }

        [Display(Name = "Format Link")]
        [Required]
        public string FormatLink { get; set; }

        public string Title
        {
            get
            {
                return FormatID != 0 ? "Edit Format" : "New Format";
            }
        }

        public FormatFormViewModel()
        {
            FormatID = 0;
        }

        public FormatFormViewModel(Format format)
        {
            FormatID = format.FormatID;
            FormatName = format.FormatName;
            FormatDescription = format.FormatDescription;
            FormatLink = format.FormatLink;
            GameID = format.GameID;
        }
    }
}
