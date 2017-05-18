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
        ICollection<Customer> GetCustomerListFromXls();

        ICollection<User> GetUserListFromXls();
    }
}
