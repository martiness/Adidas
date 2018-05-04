using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace UITests
{
    public class UITests
    {
        /// <summary>
        /// Checks for main page navigation in Chrome browser
        /// </summary>
        [Test]
        public void CheckForMainPageNavigationInChrome()
        {
            #region StartWebBrowser
            IWebDriver driver;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--silent");
            chromeOptions.AddArgument("--start-maximized");
            driver = new ChromeDriver(chromeOptions);
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
            Assert.AreEqual(webSiteAddress, currentPageAddress, "Expect to be on the Main page, but it isn't!");
            #endregion

            #region STEP #2: Men's Page loading validation
            IWebElement mensPageElement;
            string mensPageAddress = "https://www.adidas.fi/men";
            mensPageElement = driver.FindElement(By.CssSelector(".label[href=\"/men\"]"));
            Assert.IsTrue(mensPageElement.Displayed, "Expected 'Men' lable to be visble, but it isn't");
            mensPageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(mensPageAddress, currentPageAddress, "Expect to be on Men's page, but it isn't!");
            driver.Navigate().Back();
            Thread.Sleep(5);
            #endregion

            #region STEP #3: Women's Page loading validation
            IWebElement womensPageElement;
            string womensPageAddress = "https://www.adidas.fi/women";
            womensPageElement = driver.FindElement(By.CssSelector(".label[href=\"/women\"]"));
            Assert.IsTrue(womensPageElement.Displayed, "Expected 'Women' lable to be visble, but it isn't");
            womensPageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(womensPageAddress, currentPageAddress, "Expect to be on Women's page, but it isn't!");
            driver.Navigate().Back();
            Thread.Sleep(2);
            #endregion

            #region STEP #4: Kids's Page loading validation
            IWebElement kidsPageElement;
            string kidsPageAddress = "https://www.adidas.fi/kids";
            kidsPageElement = driver.FindElement(By.CssSelector(".label[href=\"/kids\"]"));
            Assert.IsTrue(kidsPageElement.Displayed, "Expected 'Kids' lable to be visble, but it isn't");
            kidsPageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(kidsPageAddress, currentPageAddress, "Expect to be on Kids's page, but it isn't!");
            driver.Navigate().Back();
            Thread.Sleep(2);
            #endregion

            #region STEP #5: Customise's Page loading validation
            IWebElement customisePageElement;
            string customisePageAddress = "https://www.adidas.fi/customise";
            customisePageElement = driver.FindElement(By.CssSelector(".label[href=\"/customise\"]"));
            Assert.IsTrue(customisePageElement.Displayed, "Expected 'Customises' lable to be visble, but it isn't");
            customisePageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(customisePageAddress, currentPageAddress, "Expect to be on Customise's page, but it isn't!");
            #endregion

            #region CloseWebBrowser
            driver.Quit();
            #endregion
        }

        /// <summary>
        /// Checks for main page navigation in Firefox browser
        /// </summary>
        [Test]
        public void CheckForMainPageNavigationInFirefox()
        {
            #region StartWebBrowser
            IWebDriver driver;
            driver = new FirefoxDriver();
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
            Assert.AreEqual(webSiteAddress, currentPageAddress, "Expect to be on the Main page, but it isn't!");
            #endregion

            #region STEP #2: Men's Page loading validation
            IWebElement mensPageElement;
            string mensPageAddress = "https://www.adidas.fi/men";
            mensPageElement = driver.FindElement(By.CssSelector(".label[href=\"/men\"]"));
            Assert.IsTrue(mensPageElement.Displayed, "Expected 'Men' lable to be visble, but it isn't");
            mensPageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(mensPageAddress, currentPageAddress, "Expect to be on Men's page, but it isn't!");
            #endregion

            #region STEP #3: Women's Page loading validation
            IWebElement womensPageElement;
            string womensPageAddress = "https://www.adidas.fi/women";
            womensPageElement = driver.FindElement(By.CssSelector(".label[href=\"/women\"]"));
            Assert.IsTrue(womensPageElement.Displayed, "Expected 'Women' lable to be visble, but it isn't");
            womensPageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(womensPageAddress, currentPageAddress, "Expect to be on Women's page, but it isn't!");
            #endregion

            #region STEP #4: Kids's Page loading validation
            IWebElement kidsPageElement;
            string kidsPageAddress = "https://www.adidas.fi/kids";
            kidsPageElement = driver.FindElement(By.CssSelector(".label[href=\"/kids\"]"));
            Assert.IsTrue(kidsPageElement.Displayed, "Expected 'Kids' lable to be visble, but it isn't");
            kidsPageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(kidsPageAddress, currentPageAddress, "Expect to be on Kids's page, but it isn't!");
            #endregion

            #region STEP #5: Customise's Page loading validation
            IWebElement customisePageElement;
            string customisePageAddress = "https://www.adidas.fi/customise";
            customisePageElement = driver.FindElement(By.CssSelector(".label[href=\"/customise\"]"));
            Assert.IsTrue(customisePageElement.Displayed, "Expected 'Customises' lable to be visble, but it isn't");
            customisePageElement.Click();

            currentPageAddress = driver.Url;
            System.Diagnostics.Debug.WriteLine($"Current page address: {currentPageAddress}");
            Assert.AreEqual(customisePageAddress, currentPageAddress, "Expect to be on Customise's page, but it isn't!");
            #endregion

            #region CloseWebBrowser
            driver.Quit();
            #endregion
        }

        /// <summary>
        /// Checks for search functionality with valid value.
        /// </summary>
        [Test]
        public void CheckForSearchFunctionalityWithValidValue()
        {
            #region StartWebBrowser
            IWebDriver driver;
            driver = new FirefoxDriver();
            #endregion

            #region Initilization 
            string webSiteAddress = "https://www.adidas.fi/";
            string currentPageAddress = string.Empty;
            #endregion

            #region STEP #1: Main's page loading validation
            driver.Url = webSiteAddress;
            currentPageAddress = driver.Url;
            Assert.AreEqual(webSiteAddress, currentPageAddress, "Expect to be on the Main page, but it isn't!");
            #endregion

            #region STEP #2: Alocate 'Search' Box 
            IWebElement searchBox;
            searchBox = driver.FindElement(By.ClassName(@"searchinput___2BN-T"));
            Assert.IsTrue(searchBox.Displayed, "Expected 'Search' box to be visble, but it isn't");
            searchBox.Click();
            #endregion

            #region STEP #3: Check correct Search page address
            string searchForSquash = "squash";
            searchBox.SendKeys(searchForSquash);
            searchBox.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(7000);
            Assert.AreEqual("https://www.adidas.fi/search?q=squash", driver.Url, "Expected to be at Search Page, but it isn't");
            #endregion

            #region STEP #4: Check that page show correct Search result
            IWebElement searchResultFound;
            System.Threading.Thread.Sleep(2000);
            searchResultFound = driver.FindElement(By.ClassName(@"search_text___3b43T"));
            Assert.AreEqual("YOUR SEARCH RESULTS FOR", searchResultFound.Text, "Expected to have completed Search operation and result items, but it isn't");
            #endregion

            #region CloseWebBrowser
            driver.Quit();
            #endregion

        }

        /// <summary>
        /// Checks the search functionality with not valid value.
        /// </summary>
        [Test]
        public void CheckSearchFunctionalityWithNotValidValue()
        {
            #region StartWebBrowser
            IWebDriver driver;
            driver = new FirefoxDriver();
            #endregion

            #region Initilization 
            string webSiteAddress = "https://www.adidas.fi/";
            string currentPageAddress = string.Empty;
            #endregion

            #region STEP #1: Main's page loading validation
            driver.Url = webSiteAddress;
            currentPageAddress = driver.Url;
            Assert.AreEqual(webSiteAddress, currentPageAddress, "Expect to be on the Main page, but it isn't!");
            #endregion

            #region STEP #2: Close cookie banner
            IWebElement cookieDismissBtn;
            System.Threading.Thread.Sleep(5000);
            cookieDismissBtn = driver.FindElement(By.Id("truste-consent-buttons"));
            cookieDismissBtn.Click();
            #endregion

            #region STEP #3: Alocate 'Search' Box 
            IWebElement searchBox;
            searchBox = driver.FindElement(By.ClassName(@"searchinput___2BN-T"));
            Assert.IsTrue(searchBox.Displayed, "Expected 'Search' box to be visble, but it isn't");
            searchBox.Click();
            #endregion

            #region STEP #4: Check for dismiss Search Box functionality
            string searchForAdidas = "adidas";
            searchBox.SendKeys(searchForAdidas);
            IWebElement dismissSearchActivity;
            dismissSearchActivity = driver.FindElement(By.ClassName(@"btn-clear-search___c4uR5"));
            Assert.IsTrue(searchBox.Displayed, "Expected 'Dismiss Search' box element to be visble, but it isn't");
            dismissSearchActivity.Click();
            #endregion

            #region STEP #5: Check correct Search page address for NOT Found result 
            string searchFroAlabala = "alabala";
            searchBox = driver.FindElement(By.ClassName(@"searchinput___2BN-T"));
            searchBox.Clear();
            searchBox.SendKeys(searchFroAlabala);
            searchBox.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(7000);
            Assert.AreEqual("https://www.adidas.fi/search?q=alabala", driver.Url, "Expected to be at Search Page, but it isn't");
            #endregion

            #region STEP #6: Check for No result found
            IWebElement searchResultNotFound;
            System.Threading.Thread.Sleep(2000);
            searchResultNotFound = driver.FindElement(By.ClassName(@"btn-clear-search___c4uR5"));
            Assert.IsTrue(searchResultNotFound.Displayed, "Expected to have Nothing found result and No items, but it isn't");
            #endregion

            #region CloseWebBrowser
            driver.Quit();
            #endregion

        }
    }
}
