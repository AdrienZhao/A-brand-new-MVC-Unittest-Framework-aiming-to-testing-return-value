using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace MD.API.MVCUTFramework
{
    internal class ShimerEngine : IShimerProvider
    {
        private IDictionary<string, IUTShimer> ShimersWithNames { get; set; }
        private IDictionary<Type, string> ShimersTypesNames { get; set; }
        private IShimerConfiguration ShimerConfiguration { get; set; }

        public ShimerEngine(string configName)
        {
            Initialize(configName);
        }

        public IUTShimer this[string name]
        {
            get
            {
                if (ShimersWithNames.ContainsKey(name))
                {
                    return ShimersWithNames[name];
                }
                return null;
            }
        }

        public IUTShimer this[Type type]
        {
            get
            {
                if (ShimersTypesNames.ContainsKey(type))
                {
                    return this[ShimersTypesNames[type]];
                }
                return null;
            }
        }

        public void Initialize(string configName)
        {
            //TODO: Make assembly configurable.
            var shimers = ScanAssembly<IUTShimer>(typeof(ShimerEngine).Assembly);
            InitShimerCollection(shimers);
            ShimerConfiguration.Initialize();
            InitShimers(configName);
        }

        private void InitShimers(string configName)
        {
            var config = ShimerConfiguration[configName];
            if (config != null & config.shimers != null & config.shimers.Count() > 0)
            {
                foreach (var shimer in config.shimers)
                {
                    shimer.Shim();
                }
            }
        }

        private void InitShimerCollection(IEnumerable<Type> shimerTypes)
        {
            foreach (var shimerType in shimerTypes)
            {
                var shimer = (IUTShimer)Activator.CreateInstance(shimerType);
                ShimersWithNames.Add(shimer.Name, shimer);
                ShimersTypesNames.Add(shimer.GetType(), shimer.Name);
            }
        }

        private IEnumerable<Type> ScanAssembly<T>(Assembly assembly)
        {
            var types = assembly.GetTypes();
            IEnumerable<Type> shimers = from type in types
                                        where typeof(T).IsAssignableFrom(type)
                                        select type;
            return shimers;
        }

        private void Init()
        {
            ShimersWithNames = new Dictionary<string, IUTShimer>(StringComparer.OrdinalIgnoreCase);
            ShimersTypesNames = new Dictionary<Type, string>();
            ShimerConfiguration = new ShimerConfigurationManager(this);
        }
    }
}
