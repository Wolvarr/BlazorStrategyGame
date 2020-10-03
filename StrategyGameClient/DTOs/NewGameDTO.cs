using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.DTOs
{
    public class NewGameDTO
    {
        public NewGameDTO(string[] playerIds, string mapId)
        {
            this.PLayerIds.AddRange(playerIds);
            this.MapId = mapId;
        }

        public List<string> PLayerIds { get; set; } = new List<string>();

        public string MapId { get; set; }
    }
}
