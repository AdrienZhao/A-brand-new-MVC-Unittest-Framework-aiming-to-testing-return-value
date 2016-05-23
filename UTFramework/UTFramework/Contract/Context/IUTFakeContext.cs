using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    /// <summary>
    /// 用于Shim或者Stub数据的上下文
    /// </summary>
    public interface IUTFakeContext : IDisposable
    {
        void Initialize();
    }
}
