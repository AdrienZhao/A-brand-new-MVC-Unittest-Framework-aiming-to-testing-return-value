using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    internal static class FileUtility
    {
        public static string GetPathFromTypeLocation(string relativePath, Type type)
        {
            var assemblyPath = Path.GetDirectoryName(type.Assembly.Location);
            return Path.Combine(assemblyPath, relativePath);
        }
    }
}
