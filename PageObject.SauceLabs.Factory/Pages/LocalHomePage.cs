using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;
using PageObject.Local.Factory.Base;

namespace PageObject.Local.Factory.Pages
{
    using System;
    using System.Threading;

    /// <summary>
    /// The Home Page.
    /// http://demo.guru99.com/V4/index.php
    /// </summary>
    /// <seealso cref="LocalPageObjectBase" />
    /// <seealso cref="PageObject.Factory.Contracts.Pages.Contracts.IHomePage" />
    public class LocalHomePage : LocalPageObjectBase, IHomePage
    {
        // The URL.
        private const string WebDirection = "http://demo.guru99.com/V4/index.php";

        #region .: Selenium WebDriver Elements :.

        // UserId TextBox.
        [FindsBy(How = How.Name, Using = "uid")]
        private IWebElement _userIdTextBox;

        // UserPassword TextBox.
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement _userPasswordTextBox;

        // Login Button.
        [FindsBy(How = How.Name, Using = "btnLogin")]
        private IWebElement _loginButton;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SLHomePage"/> class.
        /// </summary>
        public LocalHomePage(string currentScenario)
        {
            this.SetUpWebDriverBase(currentScenario);
            PageFactory.InitElements(this.WebDriver, this);
        }

        /// <summary>
        /// Goes to home page.
        /// </summary>
        public void GoToHomePage()
        {
            this.WebDriver.Navigate().GoToUrl(WebDirection);
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        public void LoginUser(string userId, string password)
        {
            var user = new User { UserId = userId, Password = password };

            // Write the UserId.
            _userIdTextBox.SendKeys(user.UserId);

            // Write the UserPassword.
            _userPasswordTextBox.SendKeys(user.Password);

            // Click login.
            _loginButton.Click();
        }

        /// <summary>
        /// Switches to incorrect user login alert.
        /// </summary>
        public void SwitchToIncorrectUserLoginAlert()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var alert = this.WebDriver.SwitchTo().Alert();
            alert.Accept();
        }

        /// <summary>
        /// Takes the screenshot.
        /// </summary>
        public void TakeScreenshot(string scenario)
        {
            SetUpWebDriver.SetUpWebDriver.MakeScreenshot(scenario);
        }

        /// <summary>
        /// Closes the web driver.
        /// </summary>
        public void CloseWebDriver()
        {
            SetUpWebDriver.SetUpWebDriver.CloseWebDriver();
        }
    }
}
