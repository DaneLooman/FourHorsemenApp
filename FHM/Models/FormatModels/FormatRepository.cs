using FHM.Data;
using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace FHM.Models.FormatModels
{
    public class FormatRepository : IFormatRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public FormatRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public void AddFormat(Format format)
        {
            _appDbContext.Formats.Add(format);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Format> GetAllFormats()
        {
            return _appDbContext.Formats.Include(f => f.Game);
        }

        public Format GetFormatByID(int formatID)
        {
            return _appDbContext.Formats.Include(f => f.Game).FirstOrDefault(f => f.FormatID == formatID) ;
        }
    }
}
