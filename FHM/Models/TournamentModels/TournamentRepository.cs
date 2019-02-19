using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Data;
using FHM.Models.GameModel;
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

        public void DeleteTournament(int tournamentID)
        {
            var deletedTournament = _appDbContext.Tournaments.First(d => d.TournamentID == tournamentID);
            _appDbContext.Tournaments.Remove(deletedTournament);
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

        public IEnumerable<PlayerID> GetAllPlayerIDs()
        {
            return _appDbContext.PlayerIDs
                .Include(p => p.Player)
                .ToList();
        }

        public IEnumerable<Tournament> GetAllTournaments()
        {
            return _appDbContext.Tournaments
           .Include(f => f.PlayerIDIDs)
           .ThenInclude(PlayerIDIDs => PlayerIDIDs.Player)
           .ThenInclude(Player=> Player.Player)
           .Include(f => f.TournamentGame)
           .Include(f => f.TournamentFormat).ToList();
        }

        public IEnumerable<Tournament> GetAllTournaments(string id)
        {
            return _appDbContext.Tournaments
           .Include(f => f.PlayerIDIDs)
           .ThenInclude(PlayerIDIDs => PlayerIDIDs.Player)
           .ThenInclude(Player => Player.Player)
           .Include(f => f.TournamentGame)
           .Include(f => f.TournamentFormat)
           .ToList()
           .Where(f => f.PlayerIDIDs.Any(pid => pid.Player.Player.Id == id));
        }
        public Tournament GetTournamentByID(int? tournamentID)
        {
           return _appDbContext.Tournaments
           .Include(f => f.PlayerIDIDs)
           .ThenInclude(PlayerIDIDs => PlayerIDIDs.Player)
           .ThenInclude(Player => Player.Player)
           .Include(f => f.TournamentGame)
           .Include(f => f.TournamentFormat)
           .FirstOrDefault(f => f.TournamentID == tournamentID);
        }
    }
}
