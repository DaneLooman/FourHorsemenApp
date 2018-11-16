using FHM.Models.PlayerIDModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<PlayerID> PlayerIDs { get; set; }

    }
}
