using System;

namespace MD.API.MVCUTFramework
{
    public interface IShimerProvider
    {
        IUTShimer this[string name] { get; }
        IUTShimer this[Type type] { get; }
    }
}