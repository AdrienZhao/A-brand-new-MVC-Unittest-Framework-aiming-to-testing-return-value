using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using WebApplication1;

namespace UTFrameworkUnitTest
{
    [TestClass]
    public class HomeControllerTester : BaseUnitTest
    {
        [TestMethod]
        public void TestAboutMethodFalseOnHomeController()
        {
            using (APIUTContext)
            {
                APIUTContext.Initialize();

                WebApplication1.Fakes.ShimAboutUsBusinessLogic.GetShortModelInfo =
                    () => APIUTContext.EntityInitializer.Initialize<WebApplication1.ShortAboutModel>();

                HomeController homeController = new HomeController();
                var result = homeController.About(false);

                APIUTContext.EntityVerifier.Verify(result.Data);
            }
        }

        [TestMethod]
        public void TestAboutMethodTrueOnHomeController()
        {
            using (APIUTContext)
            {
                APIUTContext.Initialize();

                WebApplication1.Fakes.ShimAboutUsBusinessLogic.GetFullModelInfo =
                    () => APIUTContext.EntityInitializer.Initialize<WebApplication1.FullAboutModel>(typeof(MemberModel));

                HomeController homeController = new HomeController();
                var result = homeController.About(true);

                APIUTContext.EntityVerifier.Verify(result.Data, typeof(MemberModel));
            }
        }

        [TestMethod]
        public void TestAboutMethodReturnNullOnHomeController()
        {
            using (APIUTContext)
            {
                APIUTContext.Initialize();

                WebApplication1.Fakes.ShimAboutUsBusinessLogic.GetFullModelInfo =
                    () => null;

                HomeController homeController = new HomeController();
                var result = homeController.About(true);

                Assert.AreEqual(result.success, true);
            }
        }
    }
}
