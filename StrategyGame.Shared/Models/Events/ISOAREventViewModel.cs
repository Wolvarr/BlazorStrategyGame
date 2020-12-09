using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Shared.Models.Events
{

    public interface ISOAREventViewModel
    {

    }

    public class StatusUpdateEventViewModell : ISOAREventViewModel
    {
        public string Subject { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }

    }

    public class EntityCreationEventViewModell : ISOAREventViewModel
    {
        public string PlayerID { get; set; }
        public string EntityTypeName { get; set; }
        public string NewEntityID { get; set; }

        public string PositionID { get; set; }

    }

    public class EntityDestroyEventViewModell : ISOAREventViewModel
    {
        public string Subject { get; set; }
    
    }

    public class TurnChangedEventViewModell : ISOAREventViewModel
    {
        public string Subject { get; set; }

        public string Type { get; set; }

    }

    public class InfoForClientViewModell : ISOAREventViewModel
    {
        public string Action { get; set; }
        public string Parameter1 { get; set; }

    }

    public class GenerativeEventViewModel : ISOAREventViewModel
    {
        public string Action { get; set; }

        public string Parameter1 { get; set; }

        public string Parameter2 { get; set; }

        public string Subject { get; set; }

        public string Type { get; set; }

        public string EntityTypeName { get; set; }

        public string NewEntityID { get; set; }

        public string PositionID { get; set; }

        public string PropertyName { get; set; }
        public string Value { get; set; }

    }
}