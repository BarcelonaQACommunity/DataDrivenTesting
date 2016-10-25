﻿using PageObject.Factory.Contracts.Base.Contracts;

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
        void LoginUser(string userId, string password);
    }
}
