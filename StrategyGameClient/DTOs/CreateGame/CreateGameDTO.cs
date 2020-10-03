using StrategyGameClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.DTOs.CreateGame
{
    public class CreateGameDTO
    {
        public string GameId { get; set; }

        public string MapName { get; set; }

        public string MapShape { get; set; }

        public int MapWidth { get; set; }

        public List<CreateTileDTO> Tiles { get; set; } = new List<CreateTileDTO>();

        public List<CreatePlayerDTO> Players { get; set; } = new List<CreatePlayerDTO>();

        public List<CreateGameObjectDTO> GameObjects { get; set; } = new List<CreateGameObjectDTO>();
    }
}
