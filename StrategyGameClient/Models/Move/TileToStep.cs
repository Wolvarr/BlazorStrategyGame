using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models.Move
{
    public class TileToStep
    {
        public Tile Tile { get; set; }

        public int Progress { get; set; }

        public TileToStep(Tile t)
        {
            this.Tile = t;
            this.Progress = 1;
        }
    }
}
