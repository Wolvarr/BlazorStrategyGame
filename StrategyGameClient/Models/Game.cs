using StrategyGameClient.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models
{
    public class Game
    {
        public MapShape  MapShape { get; set; }

        public int MapWidth { get; set; }

        public List<Tile> Map { get; set; } = new List<Tile>();

        public List<GameObject> GameObjects { get; set; } = new List<GameObject>();
    }
}
