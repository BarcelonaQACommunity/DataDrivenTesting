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

        /// <summary>
        /// Initializes a new instance of the <see cref="NewCustomerStep"/> class.
        /// </summary>
        public NewCustomerStep()
        {
            this._managerPage = AutofacContainer.AContainer.Resolve<IManagerPage>();
            this._newCustomerPage = AutofacContainer.AContainer.Resolve<INewCustomerPage>();
            this._customerRegisteredPage = AutofacContainer.AContainer.Resolve<ICustomerRegisteredPage>();
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
        /// Whens the user creates a new customer with parameters.
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
        [When(@"The user edit a customer with parameters '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        [When(@"The user creates a new customer with parameters '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void WhenTheUserCreatesANewCustomerWithParameters(string name, string date, string gender, string address, string city, string state, string pin, string telephone, string password)
        {
            //Use email for seek into db, if not this customer already is in use
            var random = new Random();

            var customer = new Customer
            {
                Name = name.Replace("empty", string.Empty),
                Date = date.Replace("empty", string.Empty),
                Gender = gender.Replace("empty", string.Empty),
                Address = address.Replace("empty", string.Empty),
                City = city.Replace("empty", string.Empty),
                State = state.Replace("empty", string.Empty),
                Pin = pin.Replace("empty", string.Empty),
                Telephone = telephone.Replace("empty", string.Empty),
                Email = string.Concat(random.Next(), "@", random.Next(), ".com"),
                Password = password.Replace("empty", string.Empty)
            };

            this._newCustomerPage.AddNewCustomer(customer);
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
        /// Thens the customer with parameters has been created.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="date">The date.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="telephone">The telephone.</param>
        [Then(@"The customer with parameters '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' has been created")]
        public void ThenTheCustomerWithParametersHasBeenCreated(string name, string date, string gender, string address, string city, string state, string pin, string telephone)
        {
            var customer = new Customer
            {
                Name = name,
                Date = date,
                Gender = gender,
                Address = address,
                City = city,
                State = state,
                Pin = pin,
                Telephone = telephone,
            };

            Assert.IsTrue(this._customerRegisteredPage.IsCustomerRegistered(customer));
        }

        /// <summary>
        /// Thens the customer cannot be created.
        /// </summary>
        [Then(@"The customer cannot be created")]
        [Then(@"The customer cannot be edited")]
        public void ThenTheCustomerCannotBeCreated()
        {
            this._customerRegisteredPage.SwichToAlert();
        }
    }
}
