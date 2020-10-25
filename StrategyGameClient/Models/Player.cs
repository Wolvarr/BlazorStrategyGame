using StrategyGameClient.DTOs.CreateGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models
{
    public class Player
    {
        public Player(CreatePlayerDTO dto)
        {
            this.Id = new Guid(dto.Id);
            this.Name = dto.Name;
            this.Gold = dto.Gold;
            this.Ap = dto.Ap;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Gold { get; set; }

        public int Ap { get; set; }

        public Game Game { get; set; }
    }
}
