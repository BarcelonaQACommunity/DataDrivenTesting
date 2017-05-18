using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;
using PageObject.Local.Factory.Base;

namespace PageObject.Local.Factory.Pages
{
    /// <summary>
    /// The Edit customer page.
    /// </summary>
    /// <seealso cref="LocalPageObjectBase" />
    /// <seealso cref="PageObject.Factory.Contracts.Pages.Contracts.IEditCustomerPage" />
    public class LocalEditCustomerPage : LocalPageObjectBase, IEditCustomerPage
    {
        #region .: Selenium WebDriver Elements :.

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
        /// Initializes a new instance of the <see cref="LocalEditCustomerPage"/> class.
        /// </summary>
        public LocalEditCustomerPage()
        {
            PageFactory.InitElements(this.WebDriver, this);
        }

        /// <summary>
        /// Edits the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void EditCustomer(Customer customer)
        {
            this._addressTextBox.Clear();
            this._cityTextBox.Clear();
            this._stateTextBox.Clear();
            this._pinTextBox.Clear();
            this._telephoneTextBox.Clear();
            this._emailTextBox.Clear();

            this._addressTextBox.SendKeys(customer.Address);
            this._cityTextBox.SendKeys(customer.City);
            this._stateTextBox.SendKeys(customer.State);
            this._pinTextBox.SendKeys(customer.Pin);
            this._telephoneTextBox.SendKeys(customer.Telephone);
            this._emailTextBox.SendKeys(customer.Email);
        }
    }
}
