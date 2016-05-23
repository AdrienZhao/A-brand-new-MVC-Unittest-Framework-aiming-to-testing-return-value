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
        private ShimerEngine engine;

        public UTFakeContext(string configName)
        {
            this.ConfigName = configName;
            engine = new ShimerEngine();
            engine.Initialize(configName);
        }

        private IDisposable shimContext { get; set; }
        public string ConfigName { get; set; }

        public void Dispose()
        {
            if (shimContext != null)
            {
                shimContext.Dispose();
            }
            if (engine != null)
            {
                engine.Dispose();
            }
        }

        public void Initialize()
        {
            shimContext = ShimsContext.Create();
        }
    }
}
