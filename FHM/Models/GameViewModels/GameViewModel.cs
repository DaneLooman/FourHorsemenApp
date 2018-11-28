using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.FormatModels;
using FHM.Models.GameModel;
using FHM.Models.TournamentModels;

namespace FHM.Models.GameViewModels
{
    public class GameViewModel
    {
        public string Title { get; set; }
        public List<Game> Games { get; set; }
        public List<Format> Formats { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public Game Game { get; set; }
    }
}
