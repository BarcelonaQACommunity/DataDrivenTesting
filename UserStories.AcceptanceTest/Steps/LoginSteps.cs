using Autofac;
using CrossLayer.Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;
using TechTalk.SpecFlow;
using TestData.OpenXml.Contracts;
using UserStories.AcceptanceTest.Steps.Base;

namespace UserStories.AcceptanceTest.Steps
{
    /// <summary>
    /// Login Steps.
    /// </summary>
    /// <seealso cref="UserStories.AcceptanceTest.Steps.Base.BaseStep" />
    [Binding]
    public class LoginSteps : BaseStep
    {
        // Home Page.
        private readonly IHomePage _homePage;

        // Manager Page.
        private readonly IManagerPage _managerPage;

        // Xml Repository.
        private readonly IContentManager _contentManager;

        private User _validUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSteps"/> class.
        /// </summary>
        public LoginSteps()
        {
            this._homePage = AutofacContainer.AContainer.Resolve<IHomePage>(new NamedParameter("currentScenario", ScenarioContext.Current.ScenarioInfo.Title));
            this._managerPage = AutofacContainer.AContainer.Resolve<IManagerPage>();
            this._contentManager = AutofacContainer.AContainer.Resolve <IContentManager>();
        }

        /// <summary>
        /// Givens the user enters to the home page.
        /// </summary>
        [Given(@"The user enters to the home page")]
        public void GivenTheUserEntersToTheHomePage()
        {
            this._homePage.GoToHomePage();
        }

        /// <summary>
        /// Whens the user logs with a valid user.
        /// </summary>
        [When(@"The user logs with a valid user")]
        public void WhenTheUserLogsWithAValidUser()
        {
            _validUser = this._contentManager.GetFirstValidUser();
            Assert.IsNotNull(_validUser, "Valid user was not found.");

            this._homePage.LoginUser(_validUser);
        }

        /// <summary>
        /// Whens the user logs with an invalid user.
        /// </summary>
        [When(@"The user logs with an invalid user")]
        public void WhenTheUserLogsWithAnInvalidUser()
        {
            var invalidUser = this._contentManager.GetUserById("invalid");
            Assert.IsNotNull(invalidUser, "UserId not found.");

            this._homePage.LoginUser(invalidUser);
        }

        /// <summary>
        /// Thens the user has logged correctly.
        /// </summary>
        [Then(@"The user has logged correctly")]
        public void ThenTheUserHasLoggedCorrectly()
        {
            Assert.AreEqual(string.Concat("Manger Id : ", _validUser.UserId), this._managerPage.GetWelcomeUserManager());
        }

        /// <summary>
        /// Thens the web throws a pop up.
        /// </summary>
        [Then(@"The web throws a pop up")]
        public void ThenTheWebThrowsAPopUp()
        {
            this._homePage.SwitchToIncorrectUserLoginAlert();
        }

        /// <summary>
        /// Afters the scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                this._homePage.TakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
            }

            this._homePage.CloseWebDriver();
        }
    }
}
