using FHM.Models.FormatModels;
using FHM.Models.GameModel;
using FHM.Models.TournamentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.TournamentViewModels
{
    public class TournamentViewModel
    {
        public TournamentViewModel()
        {
        }
        public string Title { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Game> Games { get; set; }
        public List<Format> Formats { get; set; }

        //used for making new tournament 
        public int? TournamentID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Game name is required")]
        public string TournamentName { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage = "Short Desc is required")]
        public string TournamentDescription { get; set; }
        public bool IsMajorTournament { get; set; }
        public decimal TournamentFee { get; set; }
        public DateTime TournamentStartTime { get; set; }
        public int? GameID { get; set; }
        public Game TournamentGame { get; set; }
        public Format TournamentFormat { get; set; }
        public int? FormatID { get; set; }
        public TournamentViewModel(Tournament tournament)
        {
            TournamentID = tournament.TournamentID;
            TournamentName = tournament.TournamentName;
            TournamentDescription = tournament.TournamentDescription;
            IsMajorTournament = tournament.IsMajorTournament;
            TournamentFee = tournament.TournamentFee;
            TournamentStartTime = tournament.TournamentStartTime;
            GameID = tournament.GameID;
            TournamentGame = tournament.TournamentGame;
            TournamentFormat = tournament.TournamentFormat;
            FormatID = tournament.FormatID;
        }


    }
}
