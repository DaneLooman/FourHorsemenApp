using FHM.Models.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FHM.Models.PlayerIDModel
{
    public class PlayerID
    {
        //Identity for Player ID
        [Key]
        public int PlayerIDID { get; set; }
        //Id for Game such as DCI number
        public string PlayerGameID { get; set; }
        //game info
        public int GameId { get; set; }
        public Game Game { get; set; }
        //user info
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
