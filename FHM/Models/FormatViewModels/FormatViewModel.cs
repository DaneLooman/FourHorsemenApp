using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.FormatViewModels
{
    public class FormatViewModel
    {
        public string Title { get; set; }
        public List<FormatModels.Format> Formats { get; set; }
    }
}
