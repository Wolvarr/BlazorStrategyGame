using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Communication
{
    public class CustomCommand : BaseCommand
    {
        public string ActionType { get; set; }

        public string Params { get; set; }
    }
}
