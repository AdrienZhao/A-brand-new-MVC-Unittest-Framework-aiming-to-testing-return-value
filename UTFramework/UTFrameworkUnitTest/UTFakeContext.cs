﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    public class UTFakeContext : IUTFakeContext
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Fake()
        {
            throw new NotImplementedException();
        }

        public void Fake(Action action)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Initialize(string testingMethodName)
        {
            throw new NotImplementedException();
        }
    }
}
