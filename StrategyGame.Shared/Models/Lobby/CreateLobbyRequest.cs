using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Shared.Models.Lobby
{
    public class CreateLobbyRequest
    {
        [Required]
        public string LobbyName { get; set; }

        [Required]
        public int MapId { get; set; }
    }
}
