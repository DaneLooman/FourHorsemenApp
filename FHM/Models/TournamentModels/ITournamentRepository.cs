using FHM.Models.GameModel;
using FHM.Models.LinkTables;
using FHM.Models.PlayerIDModel;
using FHM.Models.TournamentViewModels;
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
        IEnumerable<Tournament> GetAllCancelledTournaments();
 

        void AddTournament(Tournament tournament);
        void EditTournament(Tournament tournament);
        void RegisterID(Player_Event registration);

        IEnumerable<Game> GetAllGames();
        IEnumerable<ApplicationUser> GetPlayers();
    }
}
