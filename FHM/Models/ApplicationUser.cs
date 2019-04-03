using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.LinkTables;
using FHM.Models.PlayerIDModel;
using Microsoft.AspNetCore.Identity;

namespace FHM.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<PlayerID> PlayerIDs { get; set; }
        public ICollection<Player_Event> Registrations { get; set; }
    }
}
