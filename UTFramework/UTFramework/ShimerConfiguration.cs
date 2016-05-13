using System;
using System.Collections.Generic;

namespace MD.API.MVCUTFramework
{
    public class ShimerConfiguration
    {
        public ShimerConfiguration(string name, IEnumerable<IUTShimer> shimers)
        {
            Name = name;
            this.shimers = shimers;
        }

        public string Name { get; private set; }
        public IEnumerable<IUTShimer> shimers { get; private set; }
    }
}
