using StrategyGameClient.DTOs.CreateGame;
using StrategyGameClient.Enums;
using StrategyGameClient.Models.Units;
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
                this.Players.Add(new Player(x)
                {
                    Game = this
                });
                x.Entities.ForEach(obj =>
                {
                    switch (obj.Type.ToLower())
                    {
                        case "orcwarrior":
                            {
                                this.GameObjects.Add(new OrcWarrior(obj)
                                {
                                    Player = this.Players.SingleOrDefault(p => p.Id == new Guid(x.Id))
                                });
                                break;
                            }

                        case "knightwarrior":
                            {
                                this.GameObjects.Add(new KnightWarrior(obj)
                                {
                                    Player = this.Players.SingleOrDefault(p => p.Id == new Guid(x.Id))
                                });
                                break;
                            }

                        default: throw new Exception("Invalid entity type");
                    }
                });
            });

            this.CurrentPlayer = this.Players.First();

            dto.GameObjects.ForEach(x =>
            {
                switch (x.Type.ToLower())
                {
                    case "orcwarrior":
                        {
                            this.GameObjects.Add(new OrcWarrior(x));
                            break;
                        }

                    case "knightwarrior":
                        {
                            this.GameObjects.Add(new KnightWarrior(x));
                            break;
                        }

                    default: throw new Exception("Invalid entity type");
                }
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

            dto.Players.ForEach(x =>
            {
                x.Entities.ForEach(e =>
                {
                    this.GameObjects.ForEach(g =>
                    {
                        g.Game = this;
                        if (g.Id == new Guid(e.Id))
                        {
                            g.Position = this.Tiles.SingleOrDefault(t => t.Id == new Guid(e.Position));
                        }
                    });
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

        public GameObject AddGameObject(Guid playerId, string entityType, Guid newEntityId, Tile position)
        {
            switch (entityType)
            {
                case "OrcWarrior":
                    {
                        var obj = new OrcWarrior(this.Players.Single(x => x.Id == playerId), newEntityId, position);
                        this.GameObjects.Add(obj);
                        return obj;
                    }

                case "KnightWarrior":
                    {
                        var obj = new KnightWarrior(this.Players.Single(x => x.Id == playerId), newEntityId, position);
                        this.GameObjects.Add(obj);
                        return obj;
                    }

                default:
                    {
                        throw new Exception("Invalid entity Type");
                    }
            }
        }

        public void EndTurn(Guid playerId)
        {
            throw new NotImplementedException("");
        }

        public void StartTurn(Guid playerId)
        {
            throw new NotImplementedException("");
        }
        #region RENDERING

        public static int TileWidth = 75;

        public static int TileHeigth = 67;

        public double ScreenPositionX { get; set; }
        public double ScreenPositionY { get; set; }

        #endregion
    }
}
