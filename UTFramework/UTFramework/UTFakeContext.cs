using Microsoft.QualityTools.Testing.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    public class UTFakeContext : IUTFakeContext
    {
        private IDisposable shimContext { get; set; }
        public string ConfigName { get; set; }

        public UTFakeContext(string configName, IEnumerable<Action> fake)
        {
            this.ConfigName = configName;
        }

        public void Dispose()
        {
            if (shimContext != null)
            {
                shimContext.Dispose();
            }
        }

        public void FakeContext()
        {
            shimContext = ShimsContext.Create();
            ShimerEngine engine = new ShimerEngine();
            engine.Initialize();
            engine.Shim(ConfigName);
        }
    }
}
