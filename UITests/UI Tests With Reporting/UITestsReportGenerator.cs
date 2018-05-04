using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.Threading;

namespace UITests
{
    [TestFixture]
    class UITestsReportGenerator
    {
        ExtentReports extent;
        ExtentHtmlReporter htmlReporter;
        ExtentTest testReport;
        IWebDriver driver;

        [OneTimeSetUp]
        public void ReportGenerator()
        {
            htmlReporter = new ExtentHtmlReporter(@"C:\Adidas\Adidas\Report\UITestsReport.html");

            htmlReporter.Configuration().Theme = Theme.Dark;

            htmlReporter.Configuration().DocumentTitle = "Adidas UI XBrowsers Tests Report";

            htmlReporter.Configuration().ReportName = "Adidas UI XBrowsers Tests Report";

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void TestSetup()
        {
            #region StartWebBrowser
            driver = new FirefoxDriver();
            #endregion
        }


        /// <summary>
        /// Checks for main page navigation in fire fox.
        /// </summary>
        [Test]
        public void NavigationUITestWithReportGenerator()
        {
            try

            {
                #region ReportGenerator
                testReport = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                #endregion

                #region Initilization 
                string webSiteAddress = "https://www.adidas.fi/";
                string webDriverTitle = string.Empty;
                string webDriverPageSource = string.Empty;
                string currentPageAddress = string.Empty;
                #endregion

                #region STEP #1: Main's page loading validation
                driver.Url = webSiteAddress;
                currentPageAddress = driver.Url;
                System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
                try
                {
                    //"Assertion Passed!"
                    Assert.AreEqual(webSiteAddress, currentPageAddress);
                    testReport.Pass("Main page has been loaded!"); 

                }
                catch (AssertionException)
                {
                    //"Assertion Failed!"
                    testReport.Fail("Expected Main page to be loaded!");  
                    throw;
                }
                driver.Navigate().Back();
                Thread.Sleep(5);
                #endregion

                #region STEP #2: Men's Page Element validation
                IWebElement mensPageElement;
                string mensPageAddress = "https://www.adidas.fi/men";
                mensPageElement = driver.FindElement(By.CssSelector(".label[href=\"/men\"]"));
                try
                {
                    Assert.IsTrue(mensPageElement.Displayed);
                    testReport.Pass("Men's lablel is visible!"); 

                }
                catch (AssertionException)
                {
                    testReport.Fail("Expected Men's lablel to be visible!"); 
                    throw;
                }
                mensPageElement.Click();
                #endregion

                #region STEP #3: Men's Page loading validation
                currentPageAddress = driver.Url;
                System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
                try
                {
                    Assert.AreEqual(mensPageAddress, currentPageAddress);
                    testReport.Pass("Men's lablel is visible!"); 

                }
                catch (AssertionException)
                {
                    testReport.Fail("Expect to be on Men's page, but it isn't!"); 
                    throw;
                }
                driver.Navigate().Back();
                Thread.Sleep(5);
                #endregion

                #region STEP #4: Women's Page Element validation
                IWebElement womensPageElement;
                string womensPageAddress = "https://www.adidas.fi/women";
                womensPageElement = driver.FindElement(By.CssSelector(".label[href=\"/women\"]"));
                try
                {
                    Assert.IsTrue(womensPageElement.Displayed);
                    testReport.Pass("Women's lable is visible!"); 

                }
                catch (AssertionException)
                {
                    testReport.Fail("Expected Women's label to be visble"); 
                    throw;
                }
                womensPageElement.Click();
                #endregion

                #region STEP #5: Women's Page loading validation
                currentPageAddress = driver.Url;
                System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
                
                try
                {
                    Assert.AreEqual(womensPageAddress, currentPageAddress);
                    testReport.Pass("Women's page has been loaded!"); 

                }
                catch (AssertionException)
                {
                    testReport.Fail("Expected Women's page to be loaded!"); 
                    throw;
                }
                driver.Navigate().Back();
                Thread.Sleep(5);
                #endregion
            }
            catch (NoSuchElementException ex)
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
            #region CloseWebBrowser
            driver.Quit();
            #endregion
        }
    }
}
