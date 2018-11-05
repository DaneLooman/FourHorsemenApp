using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.GameModel
{
    public class Game
    {
        public int GameID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Game name is required")]
        public string GameName { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage = "Short Desc is required")]
        public string GameShortDescription { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage = "Long Desc is required")]
        public string GameLongDescription { get; set; }
        public string GameImageUrl { get; set; }
        public string GameImageThumbnailURL { get; set; }
        public bool GameIsGameOfTheWeek { get; set; }
    }
}
