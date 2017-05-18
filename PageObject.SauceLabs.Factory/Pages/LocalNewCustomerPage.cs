using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;
using PageObject.Local.Factory.Base;

namespace PageObject.Local.Factory.Pages
{
    /// <summary>
    /// The NewCustomer page.
    /// </summary>
    /// <seealso cref="LocalPageObjectBase" />
    /// <seealso cref="PageObject.Factory.Contracts.Pages.Contracts.INewCustomerPage" />
    public class LocalNewCustomerPage : LocalPageObjectBase, INewCustomerPage
    {
        private const string Male = "Male";
        private const string Female = "Female";

        #region .: Selenium WebDriver Elements :.

        // Name text box.
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement _nameTextBox;

        // Date text box.
        [FindsBy(How = How.Name, Using = "dob")]
        private IWebElement _dateTextBox;

        // Address text box.
        [FindsBy(How = How.Name, Using = "addr")]
        private IWebElement _addressTextBox;

        // City text box.
        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement _cityTextBox;

        // State text box.
        [FindsBy(How = How.Name, Using = "state")]
        private IWebElement _stateTextBox;

        // Pin text box.
        [FindsBy(How = How.Name, Using = "pinno")]
        private IWebElement _pinTextBox;

        // Telephone text box.
        [FindsBy(How = How.Name, Using = "telephoneno")]
        private IWebElement _telephoneTextBox;

        // Email text box.
        [FindsBy(How = How.Name, Using = "emailid")]
        private IWebElement _emailTextBox;

        // Password text box.
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement _passwordTextBox;

        // Submit button.
        [FindsBy(How = How.Name, Using = "sub")]
        private IWebElement _submitButton;

        // Reset button.
        [FindsBy(How = How.Name, Using = "res")]
        private IWebElement _resetButton;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalNewCustomerPage"/> class.
        /// </summary>
        public LocalNewCustomerPage()
        {
            PageFactory.InitElements(this.WebDriver, this);
        }

        /// <summary>
        /// Adds the new customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <exception cref="System.Exception">Customer gender only can be set to Male or Female</exception>
        public void AddNewCustomer(Customer customer)
        {
            _nameTextBox.SendKeys(customer.Name);
            _dateTextBox.SendKeys(customer.Date);

            switch (customer.Gender)
            {
                case Male:
                    this.WebDriver.FindElements(By.Name("rad1")).First().Click();
                    break;

                case Female:
                    this.WebDriver.FindElements(By.Name("rad1")).Last().Click();
                    break;

                default:
                    throw new Exception("Customer gender only can be set to Male or Female");
            }

            this._addressTextBox.SendKeys(customer.Address);
            this._cityTextBox.SendKeys(customer.City);
            this._stateTextBox.SendKeys(customer.State);
            this._pinTextBox.SendKeys(customer.Pin);
            this._telephoneTextBox.SendKeys(customer.Telephone);
            this._emailTextBox.SendKeys(customer.Email);
            this._passwordTextBox.SendKeys(customer.Password);
        }

        /// <summary>
        /// Clicks the submit button.
        /// </summary>
        public void ClickSubmitButton()
        {
            this._submitButton.Click();
        }

        /// <summary>
        /// Clicks the reset button.
        /// </summary>
        public void ClickResetButton()
        {
            this._resetButton.Click();
        }
    }
}
