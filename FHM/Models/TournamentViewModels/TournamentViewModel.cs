using FHM.Models.GameModel;
using FHM.Models.TournamentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.TournamentViewModels
{
    public class TournamentViewModel
    {
        public string Title { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Game> Games { get; set; }

    }
}
