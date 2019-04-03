using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.ApplicationUserViewModels
{
    public interface IApplicationUserViewRepo
    {
        IEnumerable<AppRole> GetAllRoles();
        IEnumerable<ApplicationUser> GetAllUsersNoRole();
        IEnumerable<ApplicationUser> GetAllCustomers();
        IEnumerable<ApplicationUser> GetAllOrganizers();
        IEnumerable<ApplicationUser> GetAllEmployees();
        IEnumerable<ApplicationUser> GetAllAdmins();
        ApplicationUser findUser(string id);

        Task DropRole(string userId, string roleId);
        Task AddRole(string userId, string roleId);
    }
}
