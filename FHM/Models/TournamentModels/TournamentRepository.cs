using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Data;
using FHM.Models.GameModel;
using FHM.Models.LinkTables;
using FHM.Models.PlayerIDModel;
using FHM.Models.TournamentViewModels;
using Microsoft.EntityFrameworkCore;

namespace FHM.Models.TournamentModels
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public TournamentRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddTournament(Tournament tournament)
        {

            tournament.TournamentFormat = _appDbContext.Formats.FirstOrDefault(d => d.FormatID == tournament.FormatID);

            _appDbContext.Tournaments.Add(tournament);
            _appDbContext.SaveChanges();
        }


        public void EditTournamentViewMOdel(TournamentViewModel viewModel)

        {
            Tournament tournament = viewModel.Tournament;

            tournament.TournamentName = viewModel.TournamentName;
            tournament.TournamentDescription = viewModel.TournamentDescription;
            tournament.TournamentGame = viewModel.TournamentGame;
            tournament.TournamentFormat = viewModel.TournamentFormat;
            tournament.TournamentFee = viewModel.TournamentFee;
            tournament.IsMajorTournament = viewModel.IsMajorTournament;
            tournament.TournamentStartTime = viewModel.TournamentStartTime;

            EditTournament(tournament);
        }

        public void EditTournament(Tournament tournament)
        {
            _appDbContext.Tournaments.Update(tournament);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _appDbContext.Games.ToList();
        }

        public IEnumerable<Tournament> GetAllTournaments()
        {
            return _appDbContext.Tournaments
           .Include(f => f.Registartions)
           .ThenInclude(Registartions => Registartions.Player)
           .ThenInclude(Player => Player.PlayerIDs)
           .Include(f => f.TournamentGame)
           .Include(f => f.TournamentFormat).ToList().Where(t => t.IsCancelled == false);
        }

        public Tournament GetTournamentByID(int? tournamentID)
        {
            return _appDbContext.Tournaments
            .Include(f => f.Registartions)
            .ThenInclude(Registartions => Registartions.Player)
            .ThenInclude(Player => Player.PlayerIDs)
            .Include(f => f.TournamentGame)
            .Include(f => f.TournamentFormat)
            .FirstOrDefault(f => f.TournamentID == tournamentID);
        }

        public IEnumerable<Tournament> GetAllTournaments(string id)
        {
            return _appDbContext.Tournaments
            .Include(f => f.Registartions)
            .ThenInclude(Registartions => Registartions.Player)
            .ThenInclude(Player => Player.PlayerIDs)
            .Include(f => f.TournamentGame)
            .Include(f => f.TournamentFormat)
            .ToList()
            .Where(f => f.Registartions.Any(Reg => Reg.Player.Id == id && f.IsCancelled == false));
        }

        public IEnumerable<Tournament> GetAllCancelledTournaments()
        {
            {
                return _appDbContext.Tournaments
               .Include(f => f.Registartions)
               .ThenInclude(Registartions => Registartions.Player)
               .ThenInclude(Player => Player.PlayerIDs)
               .Include(f => f.TournamentGame)
               .Include(f => f.TournamentFormat).ToList().Where(t => t.IsCancelled == true);
            }
        }

        public IEnumerable<ApplicationUser> GetPlayers()
        {
                 return _appDbContext.Players
                .Include(p => p.PlayerIDs)
                .ThenInclude(PlayerIDs => PlayerIDs.Game)              
                .ToList();
        }

        public void RegisterID(Player_Event reg)
        {
            _appDbContext.Registrations.Add(reg);
            _appDbContext.SaveChanges();
        }
    }
}
