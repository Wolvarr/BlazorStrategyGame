﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGameClient.Communication
{
    public class BaseCommand
    {
        public Guid GameId { get; set; }

        public Guid PlayerId { get; set; }

    }
}
