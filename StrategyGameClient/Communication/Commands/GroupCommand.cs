using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Communication
{
    public class GroupCommand : BaseCommand
    {
        public List<CustomCommand> CommandList { get; set; }
    }
}
