using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.DTOs.CreateGame
{
    public class CreateTileDTO
    {
        public string Id { get; set; }

        public int RenderNumber { get; set; }

        public string Type { get; set; }

        public List<string> Neighbours { get; set; }
    }
}
