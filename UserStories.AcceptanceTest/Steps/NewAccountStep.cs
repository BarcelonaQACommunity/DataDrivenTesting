using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using CrossLayer.Autofac;
using PageObject.Factory.Contracts.Pages.Contracts;
using TechTalk.SpecFlow;
using UserStories.AcceptanceTest.Steps.Base;

namespace UserStories.AcceptanceTest.Steps
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The new account step.
    /// </summary>
    /// <seealso cref="UserStories.AcceptanceTest.Steps.Base.BaseStep" />
    [Binding]
    public class NewAccountStep : BaseStep
    {
        // Manager page.
        private readonly IManagerPage _managerPage;

        // New Account page.
        private readonly INewAccountPage _newAccountPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewAccountStep"/> class.
        /// </summary>
        public NewAccountStep()
        {
            this._managerPage = AutofacContainer.AContainer.Resolve<IManagerPage>();
            this._newAccountPage = AutofacContainer.AContainer.Resolve<INewAccountPage>();
        }

        /// <summary>
        /// The when the user goes to the new account page.
        /// </summary>
        [When(@"The user goes to the new account page")]
        public void WhenTheUserGoesToTheNewAccountPage()
        {
            this._managerPage.GoToNewAccountPage();
        }

        /// <summary>
        /// The when the user creates a new account with parameters.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="accountType">
        /// The account type.
        /// </param>
        /// <param name="initialDeposit">
        /// The initial deposit.
        /// </param>
        [When(@"The user creates a new account with parameters '(.*)', '(.*)', '(.*)'")]
        public void WhenTheUserCreatesANewAccountWithParameters(string id, string accountType, int initialDeposit)
        {
            if (accountType.Equals("Current"))
            {
                this._newAccountPage.CreateCurrentAccount(id, initialDeposit);
            }
            else if (accountType.Equals("Savings"))
            {
                this._newAccountPage.CreateSavingAccount(id, initialDeposit);
            }
            else
            {
                Assert.Fail("Account type must be Current or Savings");
            }

            this._newAccountPage.ClickSubmitButton();
        }

        /// <summary>
        /// The then the new account has been created.
        /// </summary>
        [Then(@"The new account has been created")]
        public void ThenTheNewAccountHasBeenCreated()
        {
            Assert.IsTrue(this._newAccountPage.GetUrl().Contains("AccCreateMsg")); 
        }
    }
}
