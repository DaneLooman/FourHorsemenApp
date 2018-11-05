using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.Game
{
    interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameByID(int gameID);
        void AddGame(Game game);
    }
}
