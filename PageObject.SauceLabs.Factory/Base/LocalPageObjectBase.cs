using System;
using OpenQA.Selenium;
using PageObject.Factory.Contracts.Base.Contracts;

namespace PageObject.Local.Factory.Base
{
    /// <summary>
    /// The Page Object base.
    /// </summary>
    /// <seealso cref="PageObject.Factory.Contracts.Base.Contracts.IPageObjectBase" />
    public class LocalPageObjectBase : IPageObjectBase
    {
        /// <summary>
        /// The web driver
        /// </summary>
        protected IWebDriver WebDriver;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalPageObjectBase"/> class.
        /// </summary>
        public LocalPageObjectBase()
        {
            this.WebDriver = SetUpWebDriver.SetUpWebDriver.WebDriver;
        }

        /// <summary>
        /// Sets up web driver base.
        /// </summary>
        protected void SetUpWebDriverBase()
        {
            SetUpWebDriver.SetUpWebDriver.SetUpChromeWebDriver();
            this.WebDriver = SetUpWebDriver.SetUpWebDriver.WebDriver;
            this.WebDriver.Manage().Cookies.DeleteAllCookies();
            this.WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Sets up web driver base.
        /// </summary>
        protected void SetUpWebDriverBase(string currentScenario)
        {
            SetUpWebDriver.SetUpWebDriver.SetUpChromeWebDriver();
            this.WebDriver = SetUpWebDriver.SetUpWebDriver.WebDriver;
            this.WebDriver.Manage().Cookies.DeleteAllCookies();
            this.WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
    }
}
