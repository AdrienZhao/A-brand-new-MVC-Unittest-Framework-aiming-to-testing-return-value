using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    public class UTContext : IUTContext
    {
        public UTContext()
        {
            FakeContext = new UTFakeContext(@"shimers");
            valueProvider = new ValueProvider();
            EntityInitializer = new UTEntityInitializer(valueProvider);
            EntityVerifier = new UTEntityVerifier(valueProvider);
        }

        private IValueProvider valueProvider { get; set; }

        public IUTFakeContext FakeContext { get; private set; }

        public IHttpFakeRequest Request { get; private set; }

        public IEntityInitializer EntityInitializer { get; private set; }

        public IEntityVerifier EntityVerifier { get; private set; }

        IValueProvider IUTContext.valueProvider
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            if (FakeContext != null)
            {
                FakeContext.Dispose();
            }
        }

        public void Initialize()
        {
            FakeContext.Initialize();
        }
    }
}
