using FHM.Models.GameModel;
using FHM.Models.PlayerIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.TournamentModels
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> GetAllTournaments();
        Tournament GetTournamentByID(int? tournamentID);
        IEnumerable<Tournament> GetAllTournaments(string id);

        void AddTournament(Tournament tournament);
        void DeleteTournament(int tournamentID);
        void EditTournament(Tournament tournament);

        IEnumerable<Game> GetAllGames();
        IEnumerable<PlayerID> GetAllPlayerIDs();
    }
}
