using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AdidasAPI.API_Client;

namespace AdidasAPI.API_Tests
{
    public partial class APITests
    {
        /// <summary>
        /// Checks for reponse time test.
        /// SLAs/requirements: Response time should be bellow 1s
        /// </summary>
        [Test]
        public static void API_CheckForReponseTimeTest()
        {
            Client client = new Client();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Keywords.apiPublicAddress);
            stopwatch.Stop();

            bool isLessThanSec = Validation.IsLessThanASecond(stopwatch.ElapsedMilliseconds);
            Assert.IsTrue(isLessThanSec, "Expected API request response to be bellow 1 second, but it isn't");
        }
    }
}
