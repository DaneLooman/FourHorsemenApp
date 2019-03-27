using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.ApplicationUserViewModels
{
    public class ApplicationUserView
    {
        public ApplicationUserView()
        {
        }
        public string Title { get; set; }
        public IEnumerable<AppRole> Roles { get; set; }
        public IEnumerable<ApplicationUser> UsersNoRole { get; set; }
        public IEnumerable<ApplicationUser> Customers { get; set; }
        public IEnumerable<ApplicationUser> Organizers { get; set; }
        public IEnumerable<ApplicationUser> Employees { get; set; }
        public IEnumerable<ApplicationUser> Admins { get; set; }

        [Display(Name = "AppRoleID")]
        [Required]
        public string AppRoleID { get; set; }

        [Display(Name = "User")]
        [Required]
        public string UserID { get; set; }

        public ApplicationUserView(ApplicationUser user, AppRole role)
        {
            AppRoleID = role.Id;
            UserID = user.Id;
        }

    }
}
