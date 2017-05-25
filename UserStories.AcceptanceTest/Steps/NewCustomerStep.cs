using System;
using Autofac;
using CrossLayer.Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;
using TechTalk.SpecFlow;
using System.Linq;
using UserStories.AcceptanceTest.Steps.Base;

namespace UserStories.AcceptanceTest.Steps
{
    using System.Linq;
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
            Thread.Sleep(TimeSpan.FromSeconds(2));
            this._managerPage.GoToAddNewCustomerPage();
        }

        /// <summary>
        /// Whens The user tries to create all valid customers
        /// </summary>
        [When(@"The user tries to create all valid customers")]
        public void WhenTheUserCreatesCustomerAllValidCustomers()
        {
            var customerList = _contentManager.GetAllValidCustomers().ToList();
            var lastCustomerInList = customerList.Last();

            Assert.IsTrue(customerList.Count > 0, "Customer list is empty");

            foreach (var customer in customerList)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                When(string.Format(@"The user creates a customer with given email: '{0}'", customer.Email)); 
                When(@"The user clicks the submit button");
                Then(@"The new customer has been created");
                if(lastCustomerInList != customer) When(@"The user goes to the new customer page");
            }
        }

        /// <summary>
        /// Whens The user creates a new customer with given email.
        /// </summary>
        /// <param name="email">The name.</param>
        [When(@"The user creates a customer with given email: '(.*)'")]
        public void WhenTheUserCreatesANewValidCustomer(string customerEmail)
        {
            _newCustomer = _contentManager.GetCustomerByEmail(customerEmail);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            this._newCustomerPage.AddNewCustomer(_newCustomer);
        }  

        /// <summary>
        /// Whens the user clicks the submit button.
        /// </summary>
        [When(@"The user clicks the submit button")]
        public void WhenTheUserClicksTheSubmitButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            this._newCustomerPage.ClickSubmitButton();
        }

        /// <summary>
        /// The new customer has been created.
        /// </summary>
        /// <param name="name">The name.</param>
        [Then(@"The new customer has been created")]
        public void ThenTheCustomerHasBeenCreated()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Assert.IsTrue(this._customerRegisteredPage.IsCustomerRegistered(_newCustomer));
        }

        /// <summary>
        /// Thens the customer cannot be created.
        /// </summary>
        [Then(@"The 2nd customer cannot be created")]
        public void ThenTheCustomerCannotBeCreated()
        {
            this._customerRegisteredPage.SwichToAlert();
        }

        /// <summary>
        /// Thens the customer validation has finished.
        /// </summary>
        [Then(@"The customer validation has finished")]
        public void ThenTheCustomerValidationHasFinished()
        {
            // The Then was validated in the other step
        }
    }
}
