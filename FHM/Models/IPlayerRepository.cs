using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models
{
    public interface IPlayerRepository
    {
        void UpdatePlayerFirstName(ApplicationUser player, string firstName);
        void UpdatePlayerLastName(ApplicationUser player, string lastName);
    }
}
