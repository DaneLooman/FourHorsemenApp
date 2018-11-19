
using FHM.Models.GameModel;
using FHM.Models.PlayerIdViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.PlayerIDModel
{
    public interface IPlayerIDRepository
    {
        IEnumerable<PlayerID> GetAllPlayerIDs();
        PlayerID GetPlayerIDByID(int? playerIDID);
        void AddPlayerIdView(PlayerIdViewModel playerID);
        void AddPlayerID(PlayerID playerID);
        void DeletePlayerID(int? playerIDID);
        void EditPlayerID(PlayerID playerID);
        IEnumerable<PlayerID> GetAllPlayerIDsByPlayer(string UserID);
        IEnumerable<Game> GetAllGames();
        IEnumerable<ApplicationUser> GetAllPlayers();
    }
}
