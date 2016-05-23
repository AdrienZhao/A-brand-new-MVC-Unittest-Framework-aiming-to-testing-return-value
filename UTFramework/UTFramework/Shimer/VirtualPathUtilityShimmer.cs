using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework.Shimer
{
    class VirtualPathUtilityShimmer : IUTShimer
    {
        public string Name
        {
            get
            {
                return "VirtualPathUtilityShimmer";
            }
        }

        public Action Shim
        {
            get
            {
                return () => 
                { System.Web.Fakes.ShimVirtualPathUtility.ToAbsoluteString = value => ("D:\test" + value); };
            }
        }
    }
}
