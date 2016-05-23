using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    public interface IEntityInitializer
    {
        /// <summary>
        /// 初始化基本属性
        /// </summary>
        /// <param name="objsToInitialize"></param>
        T Initialize<T>( params Type[] propertieTypes);
    }
}
