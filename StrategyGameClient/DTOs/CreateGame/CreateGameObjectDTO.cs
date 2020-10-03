using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace StrategyGameClient.DTOs.CreateGame
{
    public class CreateGameObjectDTO
    {
        public string Id { get; set; }

        public string Type { get; set; }

        //tile id
        public string Position { get; set; }
    }
}
