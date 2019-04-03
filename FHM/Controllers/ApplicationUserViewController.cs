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
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = _context.findUser(id);
            var roleIds = _userManager.GetRolesAsync(user).Result;
            List<AppRole> roles = new List<AppRole>();

            foreach (string element in roleIds)
            {
                var role = _context.findRole(element);
                roles.Add(role);
            }

            if (user == null)
            {
                return NotFound();
            }
            if (roles == null)
            {
                return NotFound();
            }

            var appUserAndRoleView = new ApplicationUserView()
            {
                Roles = roles,
                User = user
            };

            return View(appUserAndRoleView);
        }
        [HttpPost]
        public IActionResult Delete(string userID, string AppRoleID)
        {
            if (ModelState.IsValid)
            {
                _context.DropRole(userID, AppRoleID);
                return RedirectToAction("Index");
            }
            return View(userID);
        }
        public IActionResult Add(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = _context.findUser(id);
            IEnumerable<AppRole> roles = _context.GetAllRoles();
            if (user == null)
            {
                return NotFound();
            }
            var appUserAndRoleView = new ApplicationUserView()
            {
                Roles = roles,
                User = user
            };

            return View(appUserAndRoleView);
        }
        [HttpPost]
        public IActionResult Add(string userID, string AppRoleID)
        {
            if (ModelState.IsValid)
            {
                _context.AddRole(userID, AppRoleID);
                return RedirectToAction("Index");
            }
            return View(userID);
        }
    }
}