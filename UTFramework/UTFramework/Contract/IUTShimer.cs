using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    public interface IUTShimer
    {
        string Name { get; }

        Action Shim { get; }
    }
}