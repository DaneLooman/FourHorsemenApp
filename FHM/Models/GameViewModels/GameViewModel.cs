using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHM.Models.GameModel;

namespace FHM.Models.GameViewModels
{
    public class GameViewModel
    {
        public string Title { get; set; }
        public List<Game> Games { get; set; }
    }
}
