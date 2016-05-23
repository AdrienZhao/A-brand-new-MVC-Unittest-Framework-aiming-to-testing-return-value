using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;

namespace MD.API.MVCUTFramework
{
    public class ShimerConfigurationManager : IShimerConfiguration
    {
        private const string configName = "ShimerConfiguration";
        private IDictionary<string, ShimerConfiguration> Configs { get; set; }
        private IShimerProvider ShimerProvider { get; set; }

        public ShimerConfigurationManager(IShimerProvider shimerProvider)
        {
            Configs = new Dictionary<string, ShimerConfiguration>(StringComparer.OrdinalIgnoreCase);
            ShimerProvider = shimerProvider;
        }

        public ShimerConfiguration this[string testConfigName]
        {
            get
            {
                if (Configs.ContainsKey(testConfigName))
                {
                    return Configs[testConfigName];
                }
                return null;
            }
        }

        public void Initialize()
        {
            var configFileLocation = ConfigurationManager.AppSettings[configName];
            //var path = FileUtility.GetPathFromTypeLocation(configFileLocation, typeof(ShimerConfigurationManager));
            Init(configFileLocation);
        }

        private void Init(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlElement shimersElement in xDoc.SelectNodes("//Shimers"))
            {
                List<IUTShimer> shimers = new List<IUTShimer>();
                foreach (XmlElement xElement in shimersElement.ChildNodes)
                {
                    if (xElement.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }
                    var shimerName = xElement.GetAttribute("name");
                    IUTShimer shimer = GetShimerFromElement(path, xElement, shimerName);
                    shimers.Add(shimer);
                }
                ShimerConfiguration config = new ShimerConfiguration(shimersElement.Name, shimers);
                Configs.Add(config.Name, config);
            }
        }

        private IUTShimer GetShimerFromElement(string path, XmlElement xElement, string shimerName)
        {
            IUTShimer shimer;
            if (string.IsNullOrWhiteSpace(shimerName))
            {
                var shimerTypeName = xElement.GetAttribute("qualifiedTypeName");
                if (string.IsNullOrWhiteSpace(shimerTypeName))
                {
                    var format = string.Format("当一个Shimer节点既不包含name又不包含type时。这个节点是一个无效节点 文件路径：{0}", path);
                    throw new FormatException(format);
                }
                else
                {
                    var shimerType = (Type)Activator.CreateInstance(Type.GetType(shimerTypeName));
                    shimer = ShimerProvider[shimerType];
                }
            }
            else
            {
                shimer = ShimerProvider[shimerName];
            }
            return shimer;
        }
    }
}