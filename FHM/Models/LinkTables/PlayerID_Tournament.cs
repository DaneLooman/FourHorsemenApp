using FHM.Models.PlayerIDModel;
using FHM.Models.TournamentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.LinkTables
{
    public class PlayerID_Tournament
    {
        public int PlayerIDID { get; set; }
        public PlayerID Player { get; set; }
        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; }
    }
}
