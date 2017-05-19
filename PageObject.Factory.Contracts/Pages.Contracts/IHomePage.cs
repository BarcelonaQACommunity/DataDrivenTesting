using PageObject.Factory.Contracts.Base.Contracts;
using PageObject.Models;

namespace PageObject.Factory.Contracts.Pages.Contracts
{
    /// <summary>
    /// The home page interface.
    /// </summary>
    /// <seealso cref="PageObject.Factory.Contracts.Base.Contracts.IPageObjectBase" />
    public interface IHomePage : IPageObjectBase
    {
        /// <summary>
        /// Goes to home page.
        /// </summary>
        void GoToHomePage();

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        void LoginUser(User user);

        /// <summary>
        /// Switches to incorrect user login alert.
        /// </summary>
        void SwitchToIncorrectUserLoginAlert();

        /// <summary>
        /// Takes the screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        void TakeScreenshot(string scenario);

        /// <summary>
        /// Closes the web driver.
        /// </summary>
        void CloseWebDriver();
    }
}
