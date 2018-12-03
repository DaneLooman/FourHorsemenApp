using FHM.Models.FormatModels;
using FHM.Models.GameModel;
using FHM.Models.LinkTables;
using FHM.Models.PlayerIDModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.TournamentModels
{
    public class Tournament
    {
        [Key]
        public int TournamentID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Game name is required")]
        public string TournamentName { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage = "Short Desc is required")]
        public string TournamentDescription { get; set; }
        public bool IsMajorTournament { get; set; }
        public decimal TournamentFee { get; set; }
        public DateTime TournamentStartTime { get; set; }

        //Foregin Keys
        public int? GameID { get; set; }
        public Game TournamentGame { get; set; }
        public int? FormatID { get; set; }
        public Format TournamentFormat { get; set; }
        public ICollection<PlayerID_Tournament> PlayerIDIDs { get; } = new List<PlayerID_Tournament>();

    }
}
