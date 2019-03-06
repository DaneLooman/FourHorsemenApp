using FHM.Models.TournamentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.LinkTables
{
    public class Player_Event
    {
        [Key]
        public int RegID { get; set; }
        public DateTime RegTime { get; set; }
        public bool Paid { get; set; }
        public bool StoreCredit { get; set; }

        //Foreign Keys
        public ApplicationUser Player { get; set; }
        public Tournament  Event { get; set; }

    }
}
