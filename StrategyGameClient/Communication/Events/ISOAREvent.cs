using StrategyGameClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StrategyGameClient.Communication.Events
{
    public interface ISOAREvent
    {
        void Execute(Game game);
    }

    public class StatusUpdateEvent : ISOAREvent
    {
        public Guid Subject { get; set; }
        public string PropertyName { get; set; }
        public object Value { get; set; }

        public void Execute(Game game)
        {
            GameObject item = game.GameObjects.SingleOrDefault(x => x.Id == this.Subject);
            item.GetType().GetProperty(PropertyName).SetValue(item, Value);
        }
    }

    public class EntityCreationEvent : ISOAREvent
    {
        public Guid PlayerID { get; set; }
        public string EntityTypeName { get; set; }
        public Guid NewEntityID { get; set; }

        public Tile Position { get; set; }

        public void Execute(Game game)
        {
            game.AddGameObject(PlayerID, EntityTypeName, NewEntityID, Position);
        }

            }

    public class EntityDestroyEvent : ISOAREvent
    {
        public Guid Subject { get; set; }

        
        public void Execute(Game game)
        {
            var gameObject = game.GameObjects.SingleOrDefault(x => x.Id == Subject);
            game.GameObjects.Remove(gameObject);
        }
    }

    public sealed class TurnChangedType
    {
        public const string EndTurn = "EndTurn";
        public const string StartTurn = "StartTurn";

    }

    public class TurnChangedEvent : ISOAREvent
    {
        //Subject := player
        public Guid Subject { get; set; }

        public string Type { get; set; }

        public void Execute(Game game)
        {
            switch (Type)
            {
                case TurnChangedType.EndTurn:
                    {
                        game.EndTurn(Subject);
                        break;
                    }

                case TurnChangedType.StartTurn:
                    {
                        game.StartTurn(Subject);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }
    }
}
