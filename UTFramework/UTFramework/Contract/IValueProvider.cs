using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    public interface IValueProvider : IEnumerable<KeyValuePair<Type, object>>
    {
        object this[Type type] { get; set; }
    }
}
