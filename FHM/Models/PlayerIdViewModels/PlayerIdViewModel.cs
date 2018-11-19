using FHM.Models.GameModel;
using FHM.Models.PlayerIDModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.PlayerIdViewModels
{
    public class PlayerIdViewModel
    {
        public PlayerIdViewModel()
        {
        }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<ApplicationUser> Players { get; set; }

        public int? PlayerIDID { get; set; }

        [Display(Name = "Game")]
        [Required]
        public int GameID { get; set; }

        [Display(Name = "PlayerGameID")]
        [Required]
        public string PlayerGameID { get; set; }

        [Display(Name = "User")]
        [Required]
        public string UserID { get; set; }

        public string Title
        {
            get
            {
                return PlayerIDID != 0 ? "Edit PlayerID" : "New PlayerID";
            }
        }

        public PlayerIdViewModel(PlayerID playerID)
        {
            PlayerIDID = playerID.PlayerIDID;
            PlayerGameID = playerID.PlayerGameID;
            UserID = playerID.PlayerId;
            GameID = playerID.GameId;
        }
    }
}
