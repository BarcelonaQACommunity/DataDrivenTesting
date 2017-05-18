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
        private const string _xlsFilename = "POModelsTemplate.xlsx";

        public ICollection<Customer> GetCustomerListFromXls()
        {
            ICollection<Customer> customersCollection;
            try
            {
                string excelPath = Path.Combine(Environment.CurrentDirectory, @"Data In\", _xlsFilename);
                var excelCustomerDt = OpenXmlConnection.ReadExcelSheet(excelPath, "Customer");
                customersCollection = OpenXmlConnection.ExcelMappingToCustomer(excelCustomerDt);
            }
            catch (Exception)
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
                string excelPath = Path.Combine(Environment.CurrentDirectory, @"Data In\", _xlsFilename);
                var excelUserDt = OpenXmlConnection.ReadExcelSheet(excelPath, "User");
                usersCollection = OpenXmlConnection.ExcelMappingToUser(excelUserDt);
            }
            catch (Exception)
            {
                usersCollection = null;
            }
            return usersCollection;
        }
    }
}
