using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StrategyGameClient.Models
{
    public class GameObject
    {
        public Guid Id { get; set; }

        public string TypeName { get; set; }

        public Tile Position { get; set; }

        #region RENDERING
        public string ImageName { get; set; }
        #endregion

    }
}
