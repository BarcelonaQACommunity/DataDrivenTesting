using System;
using System.Drawing.Imaging;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;

namespace PageObject.SetUpWebDriver
{
    /// <summary>
    /// Selenium Web Driver set up Class
    /// </summary>
    public static class SetUpWebDriver
    {
        private const string WebDriverPath = @"..\PageObject.SetUpWebDriver\binaries\";

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        /// <value>
        /// The web driver.
        /// </value>
        public static IWebDriver WebDriver { get; private set; }

        /// <summary>
        /// Sets up fire fox web driver.
        /// </summary>
        /// <returns><see cref="IWebDriver"/></returns>
        public static void SetUpChromeWebDriver()
        {
            WebDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(WebDriverPath), new ChromeOptions(), TimeSpan.FromSeconds(10));
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
            WebDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// The set up firefox web driver.
        /// </summary>
        public static void SetUpFirefoxWebDriver()
        {
            WebDriver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(WebDriverPath), new FirefoxOptions(), TimeSpan.FromSeconds(10));
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
            WebDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// The set up internet explorer web driver.
        /// </summary>
        public static void SetUpInternetExplorerWebDriver()
        {
            WebDriver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(WebDriverPath), new InternetExplorerOptions(), TimeSpan.FromSeconds(10));
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
            WebDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Sets up sauce labs web driver.
        /// </summary>
        public static void SetUpSauceLabsWebDriver(string currentScenario)
        {
            var caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, "chrome");
            caps.SetCapability(CapabilityType.Version, "45");
            caps.SetCapability(CapabilityType.Platform, "Windows 10");
            caps.SetCapability("deviceName", string.Empty);
            caps.SetCapability("deviceOrientation", string.Empty);
            caps.SetCapability("username", "developmentday");
            caps.SetCapability("accessKey", "aa2470b9-3b6c-4392-8dee-0e1a0822df53");
            caps.SetCapability("name", currentScenario);

            WebDriver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(600));
        }

        /// <summary>
        /// Makes the screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        public static void MakeScreenshot(string scenario)
        {
            var screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            var asdf = $"{DateTime.Now.ToString("d-M-yyyy HH-mm-ss", CultureInfo.InvariantCulture)}_{scenario}.jpeg";
            screenshot.SaveAsFile(asdf, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Closes the chrome web driver.
        /// </summary>
        public static void CloseWebDriver()
        {
            WebDriver?.Dispose();
        }
    }
}
