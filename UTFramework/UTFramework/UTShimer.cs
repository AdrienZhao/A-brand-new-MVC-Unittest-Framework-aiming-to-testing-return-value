using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    internal abstract class UTShimer
    {
        public UTShimer()
        {
            shim = GetShimer();
        }

        protected abstract Action GetShimer();

        public Action shim { get; private set; }
    }
}