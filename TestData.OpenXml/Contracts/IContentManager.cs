using PageObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData.OpenXml.Contracts
{
    public interface IContentManager
    {
        User GetFirstValidUser();

        User GetUserById(string userId);

        Customer GetCustomerByEmail(string customerEmail);

        Customer GetFirstCustomer();

        IEnumerable<Customer> GetCustomersByEmail(string customerEmail);
    }
}
