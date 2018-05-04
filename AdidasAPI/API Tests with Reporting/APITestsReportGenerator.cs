using System;
using System.Net.Http;
using System.Diagnostics;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace AdidasAPI
{
    [TestFixture]
    public class APITestsReportGenerator
    {
        ExtentReports extent;
        ExtentHtmlReporter htmlReporter;
        ExtentTest testReport;
        Client client;
        public const string apiPublicAddress = @"api/pages/landing?path=/";

        [OneTimeSetUp]
        public void ReportGenerator()
        {
            htmlReporter = new ExtentHtmlReporter(@"C:\Adidas\Adidas\Report\APITestsReport.html");

            htmlReporter.Configuration().Theme = Theme.Dark;

            htmlReporter.Configuration().DocumentTitle = "Adidas API Tests Report";

            htmlReporter.Configuration().ReportName = "Adidas API Tests Report";

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void TestSetup()
        {
            client = new Client();
        }

        /// <summary>
        /// Checks for reponse time test.
        /// SLAs/requirements: Response time should be bellow 1s
        /// </summary>
        [Test]
        public void API_ReponseTimeTest_WithReporting()
        {
            try
            {
                testReport = extent.CreateTest(TestContext.CurrentContext.Test.Name);

                //string apiAddress = apiAddress = @"api/pages/landing?path=/";

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = client.GetAsync(apiPublicAddress);
                stopwatch.Stop();

                var elapsedTime = new TimeSpan(stopwatch.ElapsedTicks);
                var isLessThanSec = elapsedTime < TimeSpan.FromSeconds(1);
                System.Diagnostics.Debug.WriteLine(isLessThanSec);
                try
                {
                    //"Assertion Passed!"
                    Assert.IsTrue(isLessThanSec);
                    testReport.Pass("API request response is bellow 1 second!");

                }
                catch (AssertionException)
                {
                    //"Assertion Failed!"
                    testReport.Fail("Expected API request response to be bellow 1 second!");
                    throw;
                }
            }
            catch (NotImplementedException ex)
            {
                testReport.Fail(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Checks for empty images test.
        /// SLAs/requirements: Images should be accessible (no 404/401s)
        /// </summary>
        [Test]
        public void API_EmptyImagesTest_WithReporting()
        {
            try
            {
                testReport = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                //string apiAddress = apiAddress = @"api/pages/landing?path=/";

                client = new Client();
                var response = client.GetAsync(apiPublicAddress);
                var result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var data = QuickType.Welcome.FromJson(result);

                foreach (var componentPresentation in data.ComponentPresentations)
                {
                    if (
                        componentPresentation.Component?.ContentFields != null
                        && componentPresentation.Component.ContentFields?.Items != null
                    )
                    {
                        foreach (var item in componentPresentation.Component.ContentFields.Items)
                        {
                            var images = item.BackgroundMedia;

                            if (images.DesktopImage != null)
                            {
                                if (!string.IsNullOrEmpty(images.DesktopImage.Url))
                                {
                                    try
                                    {
                                        Assert.IsTrue(IsValidResponse(images.DesktopImage.Url));
                                        testReport.Pass("Desktop Images are accessible");
                                    }
                                    catch (AssertionException)
                                    {
                                        testReport.Fail("Expected Desktop Images to be accessible (no 404/401s)");
                                        throw;
                                    }

                                }
                            }

                            if (images.MobileImage != null)
                            {
                                if (!string.IsNullOrEmpty(images.MobileImage.Url))
                                {
                                    try
                                    {
                                        Assert.IsTrue(IsValidResponse(images.MobileImage.Url));
                                        testReport.Pass("Mobile Images are accessible");
                                    }
                                    catch (AssertionException)
                                    {
                                        testReport.Fail("Expected Mobile Images to be accessible (no 404/401s)");
                                        throw;
                                    }
                                }
                            }

                            if (images.TabletImage != null)
                            {
                                if (!string.IsNullOrEmpty(images.TabletImage.Url))
                                {
                                    try
                                    {
                                        Assert.IsTrue(IsValidResponse(images.TabletImage.Url));
                                        testReport.Pass("Responce Images are accessible");
                                    }
                                    catch (AssertionException)
                                    {
                                        testReport.Fail("Expected Responce Images to be accessible (no 404/401s)");
                                        throw;
                                    }

                                }
                            }
                            
                            
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                testReport.Fail(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Checks for analytics data.
        /// SLAs/requirements: Every component has at least analytics data “analytics_name” in it 
        /// </summary>
        [Test]
        public void API_AnalyticsData_WithReporting()
        {
            try
            {
                testReport = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                //string apiAddress = apiAddress = @"api/pages/landing?path=/";

                client = new Client();
                var response = client.GetAsync(apiPublicAddress);
                var result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var data = QuickType.Welcome.FromJson(result);

                foreach (var componentPresentation in data.ComponentPresentations)
                {
                    if (
                        componentPresentation.Component?.ContentFields != null
                        && componentPresentation.Component.ContentFields?.Items != null
                    )
                    {
                        foreach (var item in componentPresentation.Component.ContentFields.Items)
                        {
                            var suportingFields = item.SupportingFields;
                            if (suportingFields != null)
                            {
                                if (suportingFields.SupportingFields != null)
                                {
                                    if (suportingFields.SupportingFields.StandardMetadata != null)
                                    {
                                        if (suportingFields.SupportingFields.StandardMetadata.AnalyticsName != null)
                                        {
                                            bool hasAnaliticsName = (!string.IsNullOrEmpty(suportingFields.SupportingFields.StandardMetadata.AnalyticsName));
                                            Assert.IsTrue(hasAnaliticsName,
                                                "Expected component to have “analytics_name” in it, but it haven't!");
                                            System.Diagnostics.Debug.WriteLine(hasAnaliticsName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                testReport.Fail(ex.StackTrace);
                throw;
            }
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            extent.Flush();
        }
        [TearDown]
        public void TestCleanUp()
        {

        }

        /// <summary>
        /// Checks for valid response, different from 401 and 404
        /// </summary>
        /// <param name="address"> Image address </param>
        /// <returns></returns>
        #region Helpers
        private bool IsValidResponse(string address)
        {
            HttpResponseMessage message = new Client(address).GetAsync("").GetAwaiter().GetResult();

            int errorMessageUnautorized = 401;
            int errorMessageNotFound = 404;

            bool isSuccessfulResponse = (int)message.StatusCode != errorMessageUnautorized 
                                     && (int)message.StatusCode != errorMessageNotFound;

            System.Diagnostics.Debug.WriteLine(isSuccessfulResponse);
            System.Diagnostics.Debug.WriteLine((int)message.StatusCode);

            return isSuccessfulResponse;
        }

        #endregion Helpers
    }
}
