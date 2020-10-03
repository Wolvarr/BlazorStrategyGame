using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.DTOs.CreateGame
{
   public class CreatePlayerDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Gold { get; set; }

        public int Ap { get; set; }

        public List<CreateGameObjectDTO> Entities { get; set; } = new List<CreateGameObjectDTO>();
    }
}
