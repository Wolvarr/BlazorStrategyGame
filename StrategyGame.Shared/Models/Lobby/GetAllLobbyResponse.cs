using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Shared.Models.Lobby
{
    public class LobbyDTO
    {
        public long Id { get; set; }

        public string LobbyName { get; set; }

        public int Capacity { get; set; }

        public int CurrentPlayers { get; set; }

        public string CurrentPlayerId { get; set; }
    }
}
