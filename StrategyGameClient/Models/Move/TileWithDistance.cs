using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models.Move
{
    public class TileWithDistance
    {
        public TileWithDistance()
        {

        }
        public TileWithDistance(Tile tile)
        {
            this.Tile = tile;
            this.HasNeighboursChecked = false;
        }

        public Tile Tile { get; set; }

        public int DistanceFrom { get; set; }

        public TileWithDistance ShortestReachFrom { get; set; }

        public bool HasNeighboursChecked { get; set; }
    }
}
