using FHM.Models.FormatModels;
using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.FormatModels
{
    public interface IFormatRepository
    {
        IEnumerable<Format> GetAllFormats();
        Format GetFormatByID(int? gameID);
        void AddFormat(Format format);
        IEnumerable<Game> GetAllGames();
        void DeleteFormat(int format);
        void EditFormat(Format format);
    }
}
