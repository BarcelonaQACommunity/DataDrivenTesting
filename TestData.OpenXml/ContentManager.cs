using System;
using System.Collections.Generic;
using PageObject.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestData.OpenXml.Contracts;
using System.IO;
using System.Data;

namespace TestData.OpenXml
{
    public class ContentManager : IContentManager
    {
        private const string _xlsPath = @"..\TestData.OpenXml\Data In\POModelsTemplate.xlsx";

        public User GetUserById(string userId)
        {
            return GetUserListFromXls().SingleOrDefault(x=> x.UserId.Equals(userId));
        }

        public User GetFirstValidUser()
        {   
            return GetUserListFromXls().FirstOrDefault(x => !x.UserId.Equals("invalid"));          
        }

        public Customer GetCustomerByEmail(string customerEmail)
        {
            return GetCustomerListFromXls().SingleOrDefault(x => x.Email.Equals(customerEmail));
        }

        public Customer GetFirstCustomer()
        {
            return GetCustomerListFromXls().FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomersByEmail(string customerEmail)
        {
            return GetCustomerListFromXls().Where(x => x.Email.Equals(customerEmail));
        }

        private ICollection<User> GetUserListFromXls()
        {
            return OpenXmlConnection.ExcelMappingToUser(GetExcelDatableBySheetName("User"));
        }

        private ICollection<Customer> GetCustomerListFromXls()
        {
            return OpenXmlConnection.ExcelMappingToCustomer(GetExcelDatableBySheetName("Customer"));
        }

        private DataTable GetExcelDatableBySheetName(string sheetName)
        {
            return OpenXmlConnection.ReadExcelSheet(_xlsPath, sheetName);
        }
    }
}
