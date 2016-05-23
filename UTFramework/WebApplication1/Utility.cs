using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public static class Utility
    {
        public static string GetVirtualPathByRelativePath(string relativePath)
        {
            return VirtualPathUtility.ToAbsolute(relativePath);
        }
    }
}