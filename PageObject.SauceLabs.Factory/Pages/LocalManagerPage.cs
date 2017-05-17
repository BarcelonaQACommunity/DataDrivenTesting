using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Local.Factory.Base;

namespace PageObject.Local.Factory.Pages
{
    /// <summary>
    /// The sl manager page.
    /// </summary>
    /// <seealso cref="LocalPageObjectBase" />
    public class LocalManagerPage : LocalPageObjectBase, IManagerPage
    {
        #region .: Selenium WebDriver Elements :.

        // The user welcome Text Box.
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Manger Id :')]")]
        private IWebElement _userWelcomeTextBox;

        /// <summary>
        /// The new customer button.
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'New Customer')]")]
        private IWebElement _newCustomerButton;

        /// <summary>
        /// The edit customer button.
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Edit Customer')]")]
        private IWebElement _editCustomerButton;

        /// <summary>
        /// The new account button.
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'New Account')]")]
        private IWebElement _newAccountButton;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SLManagerPage"/> class.
        /// </summary>
        public LocalManagerPage()
        {
            PageFactory.InitElements(this.WebDriver, this);
        }

        /// <summary>
        /// Gets the user manager welcome.
        /// </summary>
        /// <returns></returns>
        public string GetWelcomeUserManager()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return this._userWelcomeTextBox.Text;
        }

        /// <summary>
        /// Goes to add new customer page.
        /// </summary>
        public void GoToAddNewCustomerPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            this._newCustomerButton.Click();
        }

        /// <summary>
        /// Goes to edit new customer page.
        /// </summary>
        public void GoToEditCustomerPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            this._editCustomerButton.Click();
        }

        /// <summary>
        /// Goes to new account page.
        /// </summary>
        public void GoToNewAccountPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            this._newAccountButton.Click();
        }
    }
}
