using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    internal class UTVirtualPathShimer : UTShimer
    {
        protected override Action GetShimer()
        {
           return () => System.Web.Fakes.ShimVirtualPathUtility.ToAbsoluteString = null;
        }
    }
}
