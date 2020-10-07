using StrategyGameClient.DTOs.CreateGame;
using StrategyGameClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Models
{
    public class Tile
    {
        public Tile(CreateTileDTO dto)
        {
            this.Id = new Guid(dto.Id);
            this.RenderNumber = dto.RenderNumber;
            switch (dto.Type.ToLower())
            {
                case "plain":
                    this.TerrainType = TerrainType.Plain;
                    break;

                case "water":
                    this.TerrainType = TerrainType.Water;
                    break;

                case "magma":
                    this.TerrainType = TerrainType.Magma;
                    break;

                case "stone":
                    this.TerrainType = TerrainType.Stone;
                    break;

                case "snow":
                    this.TerrainType = TerrainType.Snow;
                    break;

                case "plainJungle":
                    this.TerrainType = TerrainType.PlainJungle;
                    break;

                case "snowwoods":
                    this.TerrainType = TerrainType.SnowWoods;
                    break;

                case "magmarocks":
                    this.TerrainType = TerrainType.MagmaRocks;
                    break;

                case "ice":
                    this.TerrainType = TerrainType.Ice;
                    break;
                default: throw new Exception("Invalid or not supported map shape");
            }
        }

        public Guid Id { get; set; }

        public TerrainType TerrainType { get; set; }

        public List<Tile> Neighbours { get; set; } = new List<Tile>();

        public Game Game { get; set; }

        #region RENDERING

        public int RenderNumber { get; set; }

        public double xPosition
        {
            get
            {
                if ((yPosition / Game.TileHeigth) % 2 == 0)
                {
                    return ((RenderNumber % (Game.MapWidth)) * Game.TileWidth);
                }
                else
                {
                    return (((RenderNumber % (Game.MapWidth)) * Game.TileWidth + Game.TileWidth / 2));
                }
            }
        }

        public double yPosition
        {
            get
            {
                return (RenderNumber / Game.MapWidth) * Game.TileHeigth;
            }
        }

        #endregion
    }
}
