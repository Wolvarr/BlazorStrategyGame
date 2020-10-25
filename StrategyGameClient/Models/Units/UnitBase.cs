using StrategyGameClient.DTOs.CreateGame;
using StrategyGameClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models.Units
{
    public class UnitBase : GameObject
    {

        public UnitBase()
        {

        }

        public UnitBase(CreateGameObjectDTO dto)
            :base(dto)
        {

        }

        public bool IsMoveable { get; set; }
        public Dictionary<TerrainType, int> MoveCost { get; set; }

        public int Energy { get; set; }
        public int EnergyDef { get; set; }
        public int EnergyMin { get; set; }
        public int EnergyMax { get; set; }

        public int HP { get; set; }
        public int HPDef { get; set; }
        public int HPMin { get; set; }
        public int HPMax { get; set; }
    }
}
