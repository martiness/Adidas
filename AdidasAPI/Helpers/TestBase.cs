using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;

namespace AdidasAPI
{
    [TestFixture]
    public class TestBase
    {
        private ExtentReports extent;
        private ExtentHtmlReporter htmlReporter;
        public ExtentTest testReport;
        public Client client;
        private System.Threading.Tasks.Task<HttpResponseMessage> response;
        private string result;
        public QuickType.Welcome data;

        [OneTimeSetUp]
        public void ReportGenerator()
        {
            #region Get Current Project Path
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + Constants.apiTestReportPathName;
            #endregion

            #region Set Report Settings
            htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = Constants.apiTestReportTitle;
            htmlReporter.Configuration().ReportName = Constants.apiTestReportName;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            #endregion
        }

        [SetUp]
        public void TestSetup()
        {
            client = new Client();
            response = client.GetAsync(Constants.apiPublicAddress);
            result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            data = QuickType.Welcome.FromJson(result);
            testReport = extent.CreateTest(TestContext.CurrentContext.Test.Name);
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
    }
}
