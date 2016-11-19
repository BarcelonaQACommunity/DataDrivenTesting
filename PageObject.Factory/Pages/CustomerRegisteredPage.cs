﻿using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.Factory.Base;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.Models;

namespace PageObject.Factory.Pages
{
    /// <summary>
    /// The customer registered page.
    /// </summary>
    /// <seealso cref="PageObject.Factory.Base.PageObjectBase" />
    /// <seealso cref="PageObject.Factory.Contracts.Pages.Contracts.ICustomerRegisteredPage" />
    public class CustomerRegisteredPage : PageObjectBase, ICustomerRegisteredPage
    {
        private const string CustomerRegisteredHeader = "Customer Registered Successfully!!!";
        private const string CustomerRegisteredTitle = "Registered Customer details are as follows:";

        private const string CustomerUpdatedHeader = "Customer details updated Successfully!!!";
        private const string CustomerUpdatedTitle = "Updated Customer details are as follows:";

        private const string AlertError = "please fill all fields";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRegisteredPage"/> class.
        /// </summary>
        public CustomerRegisteredPage()
        {
            PageFactory.InitElements(this.WebDriver, this);
        }

        /// <summary>
        /// Determines whether [is customer registered] [the specified customer].
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public bool IsCustomerRegistered(Customer customer)
        {
            return this.WebDriver.FindElements(By.TagName("p")).Any(x => x.Text.Contains(CustomerRegisteredHeader)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(CustomerRegisteredTitle)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Name)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Gender.ToLower())) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Address)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.City)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.State)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Pin)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Telephone));
        }

        /// <summary>
        /// Determines whether [is customer updated] [the specified customer].
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public bool IsCustomerUpdated(Customer customer)
        {
            return this.WebDriver.FindElements(By.TagName("p")).Any(x => x.Text.Contains(CustomerUpdatedHeader)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(CustomerUpdatedTitle)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Name)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Gender.ToLower())) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Address)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.City)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.State)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Pin)) &&
                   this.WebDriver.FindElements(By.TagName("td")).Any(x => x.Text.Contains(customer.Telephone));
        }

        /// <summary>
        /// Swiches to alert.
        /// </summary>
        public void SwichToAlert()
        {
            var alert = this.WebDriver.SwitchTo().Alert();

            if (!AlertError.Equals(alert.Text))
            {
                throw new Exception(string.Format("Alert will be {0}", AlertError));
            }

            alert.Accept();
        }
    }
}
