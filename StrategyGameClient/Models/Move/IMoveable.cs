﻿using StrategyGame.Shared.Communication;
using StrategyGameClient.Communication;
using StrategyGameClient.Models.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models
{
    public interface IMoveable
    {
        public List<TileWithDistance> GetReachableTiles();

        public List<CustomCommand> CheckMove(Tile tile, List<TileWithDistance> list);

        public void Move(Tile tile, List<TileWithDistance> list);

        public bool IsMoving { get; set; }

        public List<TileToStep> Steps { get; set; } 
    }
}
