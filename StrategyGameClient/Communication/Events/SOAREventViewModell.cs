using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Communication.Events
{
    public interface ISOAREventViewModell
    {

    }

    public class StatusUpdateEventViewModell : ISOAREventViewModell
    {
        public string Subject { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }

        public StatusUpdateEventViewModell(StatusUpdateEvent soarEvent)
        {
            this.Subject = soarEvent.Subject.ToString();
            this.PropertyName = soarEvent.PropertyName;
            this.Value = soarEvent.Value.ToString();
        }
    }

    public class EntityCreationEventViewModell : ISOAREventViewModell
    {
        public string PlayerID { get; set; }
        public string EntityTypeName { get; set; }
        public string NewEntityID { get; set; }

        public string PositionID { get; set; }

        public EntityCreationEventViewModell(EntityCreationEvent soarEvent)
        {
            this.PlayerID = soarEvent.PlayerID.ToString();
            this.EntityTypeName = soarEvent.EntityTypeName;
            this.NewEntityID = soarEvent.NewEntityID.ToString();
            this.PositionID = soarEvent.Position.Id.ToString();
        }
    }

    public class EntityDestroyEventViewModell : ISOAREventViewModell
    {
        public string Subject { get; set; }

        public EntityDestroyEventViewModell(EntityDestroyEvent soarEvent)
        {
            this.Subject = soarEvent.Subject.ToString();
        }
    }

    public class TurnChangedEventViewModell : ISOAREventViewModell
    {
        public string Subject { get; set; }

        public string Type { get; set; }

        public TurnChangedEventViewModell(TurnChangedEvent soarEvent)
        {
            this.Subject = soarEvent.Subject.ToString();
            this.Type = soarEvent.Type;
        }
    }
}