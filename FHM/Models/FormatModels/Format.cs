using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.FormatModels
{
    public class Format
    {
        public int FormatID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Game name is required")]
        public string FormatName { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage = "Short Desc is required")]
        public string FormatDescription { get; set; }
        [Required]
        public string FormatLink { get; set; }
        [Required]
        public Game Game { get; set; }
        [Required]
        public int GameID { get; set; }

    }
}
