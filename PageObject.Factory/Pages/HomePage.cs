﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.Factory.Base;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;

#pragma warning disable 649
#pragma warning disable 169

namespace PageObject.Factory.Pages
{
    /// <summary>
    /// The Home Page.
    /// http://demo.guru99.com/V4/index.php
    /// </summary>
    /// <seealso cref="PageObject.Factory.Contracts.Pages.Contracts.IHomePage" />
    public class HomePage : PageObjectBase, IHomePage
    {
        // The URL.
        private static string _webDirection = "http://demo.guru99.com/V4/index.php";

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
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        public HomePage()
        {
            PageFactory.InitElements(this.WebDriver, this);
        }

        /// <summary>
        /// Goes to home page.
        /// </summary>
        public void GoToHomePage()
        {
            this.WebDriver.Navigate().GoToUrl(_webDirection);
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        public void LoginUser(string userId, string password)
        {
            var user = new User {UserId = userId, Password = password};

            // Write the UserId.
            _userIdTextBox.SendKeys(user.UserId);

            // Write the UserPassword.
            _userPasswordTextBox.SendKeys(user.Password);

            // Click login.
            _loginButton.Click();
        }
    }
}
