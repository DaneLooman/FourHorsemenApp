using FHM.Data;
using FHM.Models.FormatModels;
using FHM.Models.FormatViewModels;
using FHM.Models.GameModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.FormatModels
{
    public class FormatRepository : IFormatRepository
    {

        private readonly ApplicationDbContext _appDbContext;

        public FormatRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Format> GetAllFormats()
        {
            return _appDbContext.Formats.Include(f => f.Game);
        }

        public Format GetFormatByID(int? formatID)
        {
            return _appDbContext.Formats.Include(f => f.Game)
            .FirstOrDefault(f => f.FormatID == formatID);
        }

        public void AddFormatView(FormatFormViewModel viewModel)
        {
            Format format = new Format();

            format.FormatName = viewModel.FormatName;
            format.FormatLink = viewModel.FormatLink;
            format.FormatDescription = viewModel.FormatDescription;
            format.GameID = format.GameID;

            AddFormat(format);
        }

        public void AddFormat(Format format)
        {

            _appDbContext.Formats.Add(format);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _appDbContext.Games.ToList();
        }
        public void DeleteFormat(int formatID)
        {
            var deletedTournaments = _appDbContext.Tournaments.Where(f => f.TournamentFormat.FormatID == formatID).ToList();

            foreach (var t in deletedTournaments)
            _appDbContext.Tournaments.Remove(t);
            _appDbContext.SaveChanges();



            var deletedformat = _appDbContext.Formats.First(d => d.FormatID == formatID);
            _appDbContext.Formats.Remove(deletedformat);
            _appDbContext.SaveChanges();
        }

        public void EditFormatView(FormatFormViewModel viewModel)
        {
            Format format = new Format();

            format.FormatName = viewModel.FormatName;
            format.FormatLink = viewModel.FormatLink;
            format.FormatDescription = viewModel.FormatDescription;
            format.GameID = format.GameID;

            EditFormat(format);
        }

        public void EditFormat(Format format)
        {

            _appDbContext.Formats.Update(format);
            _appDbContext.SaveChanges();
        }

    }
}

