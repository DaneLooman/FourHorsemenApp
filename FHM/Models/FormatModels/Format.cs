using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Models.FormatModels
{
    public class Format
    {
        public int FormatID { get; set; }
        public string FormatName { get; set; }
        public string FormatDesc { get; set; }
        public string FormatLink { get; set; }
        //Foreign key for Game
        [ForeignKey("GameID")]
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}
