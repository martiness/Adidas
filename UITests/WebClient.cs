using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace UITests
{
    public class WebClient
    {

        /// <summary>
        /// Creates New Driver.
        /// </summary>
        /// <param name="browser">The browser.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">No such browser type!</exception>
        public static IWebDriver CreateDriver(string browser)
        {
            IWebDriver result = null;
            switch (browser)
            {
                case BrowserTypes.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--disable-extensions");
                    chromeOptions.AddArgument("--silent");
                    chromeOptions.AddArgument("--start-maximized");
                    try
                    {
                        result = new ChromeDriver(chromeOptions);
                        //result.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    }
                    catch (WebDriverException ex)
                    {
                        throw;
                    }
                    break;
                case BrowserTypes.Firefox:
                    FirefoxProfile profile = new FirefoxProfile();
                    profile.SetPreference("plugins.hide_infobar_for_missing_plugin", true);
                    profile.SetPreference("plugin.default.state", 0);
                    profile.Port = 4321;

                    FirefoxOptions optionsff = new FirefoxOptions();
                    optionsff.Profile = profile;

                    try
                    {
                        result = new FirefoxDriver(optionsff);
                    }
                    catch (WebDriverException ex)
                    {
                        throw;
                    }
                    break;
                default:
                    throw new ArgumentException("No such browser type!");
            }
            result.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return result;
        }

    }
}
