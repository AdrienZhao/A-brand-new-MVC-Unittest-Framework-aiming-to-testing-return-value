using MD.API.MVCUTFramework;

namespace UTFrameworkUnitTest
{
    public class BaseUnitTest
    {
        public BaseUnitTest()
        {
            APIUTContext = new UTContext();
        }

        public IUTContext APIUTContext { get; set; }

    }
}