using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Shared.Communication
{
    public class GroupCommand : BaseCommand
    {
        public List<CustomCommand> CommandList { get; set; }
    }
}
