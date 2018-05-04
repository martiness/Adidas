using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;


namespace UITests
{
    [TestFixture]
    public class UITestsXBrowsers
    {
        /// <summary>
        /// Cross browsing test example
        /// </summary>
        /// <param name="browser">The browser.</param>
        [Test]
        [TestCase(BrowserTypes.Firefox)]
        [TestCase(BrowserTypes.Chrome)]
        public static void CrossBrowsing(string browser)
        {
            #region StartWebBrowser
            var webClient = WebClient.CreateDriver(browser);
            #endregion

            #region Initilization 
            string webSiteAddress = "https://www.adidas.fi/";
            string webDriverTitle = string.Empty;
            string webDriverPageSource = string.Empty;
            string currentPageAddress = string.Empty;
            #endregion

            #region STEP #1: Main's page loading validation
            webClient.Url = webSiteAddress;
            currentPageAddress = webClient.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(webSiteAddress, currentPageAddress, "Expect to be on the Main page, but it isn't!");
            #endregion

            #region STEP #2: Men's Page loading validation
            IWebElement mensPageElement;
            string mensPageAddress = "https://www.adidas.fi/men";
            mensPageElement = webClient.FindElement(By.CssSelector(".label[href=\"/men\"]"));
            Assert.IsTrue(mensPageElement.Displayed, "Expected 'Men' lable to be visble, but it isn't");
            mensPageElement.Click();

            currentPageAddress = webClient.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(mensPageAddress, currentPageAddress, "Expect to be on Men's page, but it isn't!");
            webClient.Navigate().Back();
            Thread.Sleep(5);
            #endregion

            #region STEP #3: Women's Page loading validation
            IWebElement womensPageElement;
            string womensPageAddress = "https://www.adidas.fi/women";
            womensPageElement = webClient.FindElement(By.CssSelector(".label[href=\"/women\"]"));
            Assert.IsTrue(womensPageElement.Displayed, "Expected 'Women' lable to be visble, but it isn't");
            womensPageElement.Click();

            currentPageAddress = webClient.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(womensPageAddress, currentPageAddress, "Expect to be on Women's page, but it isn't!");
            webClient.Navigate().Back();
            Thread.Sleep(2);
            #endregion

            #region STEP #4: Kids's Page loading validation
            IWebElement kidsPageElement;
            string kidsPageAddress = "https://www.adidas.fi/kids";
            kidsPageElement = webClient.FindElement(By.CssSelector(".label[href=\"/kids\"]"));
            Assert.IsTrue(kidsPageElement.Displayed, "Expected 'Kids' lable to be visble, but it isn't");
            kidsPageElement.Click();

            currentPageAddress = webClient.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(kidsPageAddress, currentPageAddress, "Expect to be on Kids's page, but it isn't!");
            webClient.Navigate().Back();
            Thread.Sleep(2);
            #endregion

            #region STEP #5: Customise's Page loading validation
            IWebElement customisePageElement;
            string customisePageAddress = "https://www.adidas.fi/customise";
            customisePageElement = webClient.FindElement(By.CssSelector(".label[href=\"/customise\"]"));
            Assert.IsTrue(customisePageElement.Displayed, "Expected 'Customises' lable to be visble, but it isn't");
            customisePageElement.Click();

            currentPageAddress = webClient.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(customisePageAddress, currentPageAddress, "Expect to be on Customise's page, but it isn't!");
            #endregion

            #region CloseWebBrowser
            webClient.Quit();
            #endregion
        }
    }
}
