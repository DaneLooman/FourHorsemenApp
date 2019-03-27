using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models;
using FHM.Models.ApplicationUserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FHM.Controllers
{
    public class ApplicationUserViewController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserViewRepo _context;

        public ApplicationUserViewController (IApplicationUserViewRepo context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var _Roles = _context.GetAllRoles();
            var _UsersNoRole = _context.GetAllUsersNoRole();
            var _Customers = _context.GetAllCustomers();
            var _Organizers = _context.GetAllOrganizers();
            var _Employees = _context.GetAllEmployees();
            var _Admins = _context.GetAllAdmins();

            var applicationUserView = new ApplicationUserView()
            {
                Title = "Adjust Roles",
                Roles = _Roles,
                UsersNoRole = _UsersNoRole,
                Customers = _Customers,
                Organizers = _Organizers,
                Employees = _Employees,
                Admins = _Admins
            };

            return View(applicationUserView);

        }
    }
}