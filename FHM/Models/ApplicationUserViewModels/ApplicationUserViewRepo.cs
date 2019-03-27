﻿using FHM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.ApplicationUserViewModels
{
    public class ApplicationUserViewRepo : IApplicationUserViewRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserViewRepo(ApplicationDbContext appDbContext, 
            UserManager<ApplicationUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;

        }
        public void AddRole(ApplicationUser user, AppRole role)
        {
            _userManager.AddToRoleAsync(user, role.Id);            
        }

        public void DropRole(ApplicationUser user, AppRole role)
        {
            _userManager.RemoveFromRoleAsync(user, role.Id);
        }

        public IEnumerable<ApplicationUser> GetAllAdmins()
        {
            List<string> userids = _appDbContext.UserRoles.Where(a => a.RoleId == "3019fe1a-3656-49cf-ab7e-c48645de38e9").Select(b => b.UserId).Distinct().ToList();

            List<ApplicationUser> listUsers = _appDbContext.Users.Where(a => userids.Any(c => c == a.Id)).ToList();

            return listUsers;
        }

        public IEnumerable<ApplicationUser> GetAllCustomers()
        {
            List<string> userids = _appDbContext.UserRoles.Where(a => a.RoleId == "d07f2102-a9a3-40cf-a44c-446c57588c14").Select(b => b.UserId).Distinct().ToList();

            List<ApplicationUser> listUsers = _appDbContext.Users.Where(a => userids.Any(c => c == a.Id)).ToList();

            return listUsers;
        }

        public IEnumerable<ApplicationUser> GetAllEmployees()
        {
            List<string> userids = _appDbContext.UserRoles.Where(a => a.RoleId == "1b657207-2604-4eaa-ad57-994e110b2842").Select(b => b.UserId).Distinct().ToList();

            List<ApplicationUser> listUsers = _appDbContext.Users.Where(a => userids.Any(c => c == a.Id)).ToList();

            return listUsers;
        }

        public IEnumerable<ApplicationUser> GetAllOrganizers()
        {
            List<string> userids = _appDbContext.UserRoles.Where(a => a.RoleId == "589ec030-6f47-466d-b944-47c03aee6960").Select(b => b.UserId).Distinct().ToList();

            List<ApplicationUser> listUsers = _appDbContext.Users.Where(a => userids.Any(c => c == a.Id)).ToList();

            return listUsers;
        }

        public IEnumerable<AppRole> GetAllRoles()
        {
            return _appDbContext.Roles.ToList();
        }

        public IEnumerable<ApplicationUser> GetAllUsersNoRole()
        {
            List<string> userids = _appDbContext.UserRoles.Select(b => b.UserId).Distinct().ToList();
            List<ApplicationUser> listUsers = _appDbContext.Users.Where(a => !userids.Any(c => c == a.Id)).ToList();
            return listUsers;

        }
    }
}
