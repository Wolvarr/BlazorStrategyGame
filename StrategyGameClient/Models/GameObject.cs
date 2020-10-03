using Microsoft.AspNetCore.Components;
using StrategyGameClient.DTOs.CreateGame;
using StrategyGameClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StrategyGameClient.Models
{
    public class GameObject
    {
        public GameObject(CreateGameObjectDTO dto)
        {
            this.Id = new Guid(dto.Id);
            switch (dto.Type.ToLower())
            {
                case "orcwarrior":
                    this.Type = GameObjectType.OrcWarrior;
                    break;

                default: throw new Exception("Invalid or not supported map shape");
            }
        }

        public Guid Id { get; set; }

        public Player Player { get; set; }

        public Game Game { get; set; }

        public GameObjectType Type { get; set; }

        public Tile Position { get; set; }

        #region RENDERING
        public ElementReference ElementReference { get; set; }

        public double xPosition
        {
            get
            {
                return this.Position.xPosition;
            }
        }

        public double yPosition
        {
            get
            {
                return this.Position.yPosition;
            }
        }
        #endregion

    }
}
