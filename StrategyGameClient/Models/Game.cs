using StrategyGameClient.DTOs.CreateGame;
using StrategyGameClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Xml;

namespace StrategyGameClient.Models
{
    public class Game
    {

        public Game(CreateGameDTO dto)
        {
            this.GameId = new Guid(dto.GameId);
            this.MapName = dto.MapName;

            switch (dto.MapShape.ToLower())
            {
                case "square":
                    this.MapShape = MapShape.Square;
                    break;

                case "hexa":
                    this.MapShape = MapShape.Square;
                    break;

                default: throw new Exception("Invalid or not supported map shape");
            }

            this.MapWidth = dto.MapWidth;
            dto.Tiles.ForEach(x =>
            {
                this.Tiles.Add(new Tile(x));
            });


            dto.Players.ForEach(x =>
            {
                this.Players.Add(new Player(x));
            });

            this.CurrentPlayer = this.Players.First();

            dto.GameObjects.ForEach(x =>
                        {
                            this.GameObjects.Add(new GameObject(x));
                        });

            //setting neighbours
            for (int i = 0; i < dto.Tiles.Count; i++)
            {
                this.Tiles[i].Game = this;
                dto.Tiles[i].Neighbours.ForEach(x =>
                {
                    this.Tiles[i].Neighbours.Add(this.Tiles.SingleOrDefault(y => y.Id == new Guid(x)));
                });
            }

            //setting position for gameobjects
            dto.Players.ForEach(x =>
            {
                x.Entities.ForEach(y =>
                {
                    this.Players.ForEach(z =>
                    {
                        z.Game = this;
                        z.GameObjects.ForEach(go =>
                        {
                            go.Player = z;
                            go.Game = this;
                        });
                        var obj = z.GameObjects.SingleOrDefault(obj => obj.Id == new Guid(y.Id));
                        if (obj != default)
                        {
                            obj.Position = this.Tiles.SingleOrDefault(t => t.Id == new Guid(y.Position));
                        }
                    });
                });
            });
            dto.GameObjects.ForEach(x =>
            {
                this.GameObjects.ForEach(y =>
                {
                    y.Game = this;
                    if (y.Id == new Guid(x.Id))
                    {
                        y.Position = this.Tiles.SingleOrDefault(t => t.Id == new Guid(x.Position));
                    }
                });
            });
        }
        public Guid GameId { get; set; }

        public string MapName { get; set; }

        public MapShape MapShape { get; set; }

        public int MapWidth { get; set; }

        public List<Tile> Tiles { get; set; } = new List<Tile>();

        public Player CurrentPlayer { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public List<GameObject> GameObjects { get; set; } = new List<GameObject>();

        #region RENDERING

        public static int TileWidth = 75;

        public static int TileHeigth = 67;

        public double ScreenPositionX { get; set; }
        public double ScreenPositionY { get; set; }

        #endregion
    }
}
