﻿using FHM.Data;
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

        public Game GetGameByID(int? gameID)
        {
            return _appDbContext.Games.FirstOrDefault(g => g.GameID == gameID);
        }

        public void AddGame(Game game)
        {
            _appDbContext.Games.Add(game);
            _appDbContext.SaveChanges();
        }

        public void DeleteGame (int gameID)
        {
            var deletedTournaments = _appDbContext.Tournaments.Where(f => f.TournamentGame.GameID == gameID).ToList();

            foreach (var t in deletedTournaments)
            _appDbContext.Tournaments.Remove(t);
            _appDbContext.SaveChanges();

            var deletedFormats = _appDbContext.Formats.Where(f => f.GameID == gameID).ToList();

            foreach (var format in deletedFormats)
            _appDbContext.Formats.Remove(format);
            _appDbContext.SaveChanges();

            var deletedGame = _appDbContext.Games.First(d => d.GameID == gameID);
            _appDbContext.Games.Remove(deletedGame);
            _appDbContext.SaveChanges();
        }

        public void EditGame(Game game)
        {
            _appDbContext.Games.Update(game);
            _appDbContext.SaveChanges();
        }
    }
}
