using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using FHM.Models.TournamentModels;
using FHM.Models.LinkTables;

namespace FHM.Models.PlayerIDModel
{
    public class PlayerID
    {
        //Identity for Player ID
        [Key]
        public int PlayerIDID { get; set; }
        //Id for Game such as DCI number
        public string PlayerGameID { get; set; }
        //game info
        public int GameId { get; set; }
        public Game Game { get; set; }
        //user info
        public string PlayerId { get; set; }
        public ApplicationUser Player { get; set; }
        public ICollection<PlayerID_Tournament> Tournaments { get; } = new List<PlayerID_Tournament>();
    }
}
