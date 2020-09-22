using StrategyGameClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models
{
    public class Tile
    {
        public Guid Id { get; set; }

        public TerrainType TerrainType { get; set; }

        public List<Tile> Neighbours { get; set; } = new List<Tile>();

        #region RENDERING

        public int RenderNumber { get; set; }

        #endregion
    }
}
