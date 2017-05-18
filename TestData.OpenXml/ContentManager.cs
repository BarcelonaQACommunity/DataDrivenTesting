using System;
using System.Collections.Generic;
using PageObject.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestData.OpenXml.Contracts;
using System.IO;

namespace TestData.OpenXml
{
    public class ContentManager : IContentManager
    {
        private const string _xlsPath = @"..\TestData.OpenXml\Data In\POModelsTemplate.xlsx";

        public ICollection<Customer> GetCustomerListFromXls()
        {
            ICollection<Customer> customersCollection;
            try
            {
                var excelCustomerDt = OpenXmlConnection.ReadExcelSheet(_xlsPath, "Customer");
                customersCollection = OpenXmlConnection.ExcelMappingToCustomer(excelCustomerDt);
            }
            catch (Exception ex)
            {
                customersCollection = null;
            }
            return customersCollection;
        }

        public ICollection<User> GetUserListFromXls()
        {
            ICollection<User> usersCollection;
            try
            {
                var excelUserDt = OpenXmlConnection.ReadExcelSheet(_xlsPath, "User");
                usersCollection = OpenXmlConnection.ExcelMappingToUser(excelUserDt);
            }
            catch (Exception ex)
            {
                usersCollection = null;
            }
            return usersCollection;
        }

        public User GetUserById(string userId)
        {
            User user;
            try
            {
                var excelUserDt = OpenXmlConnection.ReadExcelSheet(_xlsPath, "User");
                user = OpenXmlConnection.ExcelMappingToUser(excelUserDt).Single(x=> x.UserId.Equals(userId));
            }
            catch (Exception ex)
            {
                user = null;
            }
            return user;
        }
    }
}
