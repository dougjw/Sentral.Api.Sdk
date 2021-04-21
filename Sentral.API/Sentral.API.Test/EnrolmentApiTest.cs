using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Client;
namespace Sentral.API.Test
{
    [TestClass]
    public class EnrolmentApiTest
    {
        TestSettings settings;
        public EnrolmentApiTest()
        {
            settings = TestSettings.LoadSettings();
        }


        [TestMethod]
        public void TestMethod1()
        {
            SentralAPI sapi = new SentralAPI(
                settings.BaseUrl,
                settings.ApiKey,
                settings.ApiTenant);
        
            var x = sapi.Enrolments.GetPerson();
        }
    }
}
