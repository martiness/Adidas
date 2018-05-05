using System;
using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace AdidasAPI
{
    public partial class APITests : TestBase
    {
        /// <summary>
        /// Checks for reponse time test.
        /// SLAs/requirements: Response time should be bellow 1s
        /// </summary>
        [Test]
        public void API_CheckForReponseTimeTest()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Constants.apiPublicAddress);
                stopwatch.Stop();

                try
                {
                    bool isLessThanSec = Validation.IsLessThanASecond(stopwatch.ElapsedMilliseconds);
                    Assert.IsTrue(isLessThanSec);
                    testReport.Pass(ErrorMessages.apiResponseErrorPassedMessage);
                }
                catch (AssertionException)
                {
                    testReport.Fail(ErrorMessages.apiResponseErrorFailedMessage);
                    throw;
                }
            }
            catch (NotImplementedException ex)
            {
                testReport.Fail(ex.StackTrace);
                throw;
            }
        }
    }
}
