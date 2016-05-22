using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;

namespace MD.API.MVCUTFramework
{
    internal class UTHttpFakeRequest : IHttpFakeRequest
    {
        

        public string this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
