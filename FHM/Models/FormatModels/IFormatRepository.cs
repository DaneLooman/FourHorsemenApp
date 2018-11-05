using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.FormatModels
{
    interface IFormatRepository
    {
        IEnumerable<Format> GetAllFormats();
        Format GetFormatByID(int FormatID);
    }
}
