using FHM.Data;
using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.GameModel
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public GameRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _appDbContext.Games;
        }

        public Game GetGameByID(int gameID)
        {
            return _appDbContext.Games.FirstOrDefault(g => g.GameID == gameID);
        }

        public void AddGame(Game game)
        {
            _appDbContext.Games.Add(game);
            _appDbContext.SaveChanges();
        }
    }
}
