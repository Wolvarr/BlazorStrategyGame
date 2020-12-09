using StrategyGame.Shared.Communication;
using StrategyGameClient.Communication;
using StrategyGameClient.DTOs.CreateGame;
using StrategyGameClient.Enums;
using StrategyGameClient.Models.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace StrategyGameClient.Models.Units
{
    public class KnightWarrior : UnitBase, IMoveable
    {
        public KnightWarrior(CreateGameObjectDTO dto)
            : base(dto)
        {
            this.Type = GameObjectType.KnightWarrior;
            this.HPMax = 250;
            this.HPMin = 0;
            this.HPDef = 250;
            this.HP = 250;
            this.EnergyMax = 250;
            this.EnergyMin = 0;
            this.EnergyDef = 250;
            this.Energy = 250;
            this.IsMoveable = true;
            this.MoveCost = new Dictionary<TerrainType, int>()
            {
                {TerrainType.Plain, 35 },
                {TerrainType.Stone, 55 },
                {TerrainType.Snow, 60 },
            };
        }

        public KnightWarrior(Player player, Guid Id, Tile position)
        {
            this.Player = player;
            this.Id = Id;
            this.Position = position;

            this.Type = GameObjectType.KnightWarrior;
            this.HPMax = 250;
            this.HPMin = 0;
            this.HPDef = 250;
            this.HP = 200;
            this.EnergyMax = 250;
            this.EnergyMin = 0;
            this.EnergyDef = 250;
            this.Energy = 250;
            this.IsMoveable = true;
            this.MoveCost = new Dictionary<TerrainType, int>()
            {
                {TerrainType.Plain, 35 },
                {TerrainType.Stone, 55 },
                {TerrainType.Snow, 60 },
            };
        }

        public bool IsMoving { get; set; }
        public List<TileToStep> Steps { get; set; } = new List<TileToStep>();

        public List<TileWithDistance> GetReachableTiles()
        {
            var tileList = new List<TileWithDistance>();
            this.Position.Neighbours.ForEach(x =>
            {
                this.MoveCost.TryGetValue(x.TerrainType, out int distance);
                if (this.MoveCost.ContainsKey(x.TerrainType) && distance <= this.Energy)
                {
                    tileList.Add(new TileWithDistance(x)
                    {
                        ShortestReachFrom = new TileWithDistance
                        {
                            Tile = this.Position,
                            DistanceFrom = 0,
                            ShortestReachFrom = null,
                            HasNeighboursChecked = true,
                        },
                        DistanceFrom = distance
                    });
                }
            });

            while (tileList.Any(x => x.HasNeighboursChecked == false))
            {
                tileList.Where(x => !x.HasNeighboursChecked).ToList().ForEach(x =>
                {
                    x.Tile.Neighbours.ForEach(y =>
                    {
                        this.MoveCost.TryGetValue(y.TerrainType, out int distance);
                        if (this.MoveCost.ContainsKey(y.TerrainType) && (x.DistanceFrom + distance) <= this.Energy)
                        {
                            if (tileList.Any(c => c.Tile == y))
                            {
                                var tile = tileList.Single(t => t.Tile == y);
                                if (tile.DistanceFrom > (x.DistanceFrom + distance))
                                {
                                    tile.ShortestReachFrom = x;
                                    tile.DistanceFrom = x.DistanceFrom + distance;
                                }
                            }
                            else
                            {
                                tileList.Add(new TileWithDistance(y)
                                {
                                    ShortestReachFrom = x,
                                    DistanceFrom = x.DistanceFrom + distance
                                });
                            }
                        }

                    });
                    x.HasNeighboursChecked = true;
                });
            }

            return tileList;
        }

        public List<CustomCommand> CheckMove(Tile tile, List<TileWithDistance> path)
        {
            var commands = new List<CustomCommand>();
            for (int i = path.Count; i > 0; i--)
            {
                commands.Add(new CustomCommand
                {
                    ActionType = "KnightWarrior_MoveAction",
                    GameId = this.Game.GameId,
                    PlayerId = this.Player.Id,
                    Params = $"{{ 'host' : '{this.Id}', 'target' : '{path[i - 1].Tile.Id}' }}"
                });
            }

            return commands;
        }

        public void Move(Tile tile, List<TileWithDistance> path)
        {
            this.IsMoving = true;
            for (int i = path.Count; i > 0; i--)
            {
                this.MoveCost.TryGetValue(path[i - 1].Tile.TerrainType, out int moveCost);
                if (this.Energy >= moveCost)
                {
                    this.Energy -= moveCost;
                    this.Steps.Add(new TileToStep(path[i - 1].Tile));
                }
                else throw new Exception("Invalid move");              
            }
        }
    }
}
