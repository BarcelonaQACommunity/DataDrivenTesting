using System;
using Autofac;
using CrossLayer.Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;
using TechTalk.SpecFlow;
using UserStories.AcceptanceTest.Steps.Base;

namespace UserStories.AcceptanceTest.Steps
{
    using System.Threading;
    using TestData.OpenXml.Contracts;

    /// <summary>
    /// The new customer step.
    /// </summary>
    /// <seealso cref="UserStories.AcceptanceTest.Steps.Base.BaseStep" />
    [Binding]
    public class NewCustomerStep : BaseStep
    {
        // Manager page.
        private readonly IManagerPage _managerPage;

        // New customer page.
        private readonly INewCustomerPage _newCustomerPage;

        // Customer registered page.
        private readonly ICustomerRegisteredPage _customerRegisteredPage;

        // Xml Repository.
        private readonly IContentManager _contentManager;

        private Customer _newCustomer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewCustomerStep"/> class.
        /// </summary>
        public NewCustomerStep()
        {
            this._managerPage = AutofacContainer.AContainer.Resolve<IManagerPage>();
            this._newCustomerPage = AutofacContainer.AContainer.Resolve<INewCustomerPage>();
            this._customerRegisteredPage = AutofacContainer.AContainer.Resolve<ICustomerRegisteredPage>();
            this._contentManager = AutofacContainer.AContainer.Resolve<IContentManager>();
        }

        /// <summary>
        /// Whens the user goes to the new customer page.
        /// </summary>
        [When(@"The user goes to the new customer page")]
        public void WhenTheUserGoesToTheNewCustomerPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            this._managerPage.GoToAddNewCustomerPage();
        }

        /// <summary>
        /// Whens The user creates a new customer with given email.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="date">The date.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="telephone">The telephone.</param>
        /// <param name="password">The password.</param>
        [When(@"The user creates a new customer with given email: '(.*)'")]
        public void WhenTheUserCreatesANewCustomerWithGivenEmail(string email)
        {
            //TODO: Diferent when, get 2 customers, same email -> Create first 1 and then the second with the same email -> FAIL
            _newCustomer = _contentManager.GetCustomerByEmail(email);

            this._newCustomerPage.AddNewCustomer(_newCustomer);
        }

        /// <summary>
        /// Whens the user clicks the submit button.
        /// </summary>
        [When(@"The user clicks the submit button")]
        public void WhenTheUserClicksTheSubmitButton()
        {
            this._newCustomerPage.ClickSubmitButton();
        }

        /// <summary>
        /// The new customer has been created.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="date">The date.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="telephone">The telephone.</param>
        [Then(@"The new customer has been created")]
        public void ThenTheCustomerHasBeenCreated()
        {
            Assert.IsTrue(this._customerRegisteredPage.IsCustomerRegistered(_newCustomer));
        }

        /// <summary>
        /// Thens the customer cannot be created.
        /// </summary>
        [Then(@"The new customer cannot be created")]
        [Then(@"The customer cannot be edited")]
        public void ThenTheCustomerCannotBeCreated()
        {
            this._customerRegisteredPage.SwichToAlert();
        }
    }
}
