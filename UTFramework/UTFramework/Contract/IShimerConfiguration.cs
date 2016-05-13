using System;
using System.Collections.Generic;

namespace MD.API.MVCUTFramework
{
    public interface IShimerConfiguration
    {
        void Initialize();
        ShimerConfiguration this[string testConfigName] { get; }
    }
}