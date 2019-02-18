using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Data;
using FHM.Models.GameModel;
using FHM.Models.PlayerIdViewModels;
using Microsoft.EntityFrameworkCore;

namespace FHM.Models.PlayerIDModel
{
    public class PlayerIDRepository : IPlayerIDRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerIDRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPlayerIdView(PlayerIdViewModel viewModel)
        {
            PlayerID playerID = new PlayerID();

            playerID.PlayerId = viewModel.UserID;
            playerID.PlayerGameID = viewModel.PlayerGameID;
            playerID.GameId = viewModel.GameID;

            AddPlayerID(playerID);
        }

        public void AddPlayerID(PlayerID playerID)
        {
            var count = _context.PlayerIDs.Where(p => p.GameId == playerID.GameId && p.PlayerId == playerID.PlayerId).Count();
            PlayerID unclaimedID = _context.PlayerIDs.Where(p => p.GameId == playerID.GameId && p.PlayerId == null && p.PlayerGameID == playerID.PlayerGameID).FirstOrDefault();

            if (unclaimedID != null)
            {
                unclaimedID.PlayerId = playerID.PlayerId;
                _context.PlayerIDs.Update(unclaimedID);
                _context.SaveChanges();
            }
            else if (count > 0)
            {
                return;
            }
            else
            {
                _context.PlayerIDs.Add(playerID);
                _context.SaveChanges();
            }
        }

        public void DeletePlayerID(int? playerIDID)
        {
            PlayerID deletedPlayerID = _context.PlayerIDs.First(d => d.PlayerIDID == playerIDID);
            deletedPlayerID.PlayerId = null;
            deletedPlayerID.Player = null;
            _context.PlayerIDs.Update(deletedPlayerID);
            _context.SaveChanges();
        }

        public void EditPlayerID(PlayerID playerID)
        {
            _context.PlayerIDs.Update(playerID);
            _context.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }

        public IEnumerable<PlayerID> GetAllPlayerIDs()
        {
            return _context.PlayerIDs
                .Include(f => f.Player)
                .Include(f => f.Game)
                .ToList(); 
        }

        public IEnumerable<PlayerID> GetAllPlayerIDsByPlayer(string userID)
        {
            return _context.PlayerIDs
                .Include(p => p.Game)
                .Where(f => f.Player.Id == userID).ToList();
        }

        public IEnumerable<ApplicationUser> GetAllPlayers()
        {
            return _context.Users.ToList();
        }

        public PlayerID GetPlayerIDByID(int? playerIDID)
        {
            return _context.PlayerIDs.Include(p => p.Game).First(f => f.PlayerIDID == playerIDID);
        }
    }
}
