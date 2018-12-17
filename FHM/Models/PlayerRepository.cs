using FHM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PlayerRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void UpdatePlayerFirstName(ApplicationUser player, string firstName)
        {
            ApplicationUser user = _appDbContext.Users.FirstOrDefault(u => u.Id == player.Id);
            user.FirstName = firstName;
            _appDbContext.Update(user);
            _appDbContext.SaveChanges();
        }

        public void UpdatePlayerLastName(ApplicationUser player, string lastName)
        {
            ApplicationUser user = _appDbContext.Users.FirstOrDefault(u => u.Id == player.Id);
            user.LastName = lastName;
            _appDbContext.Update(user);
            _appDbContext.SaveChanges();
        }
    }
}
