using System;
using System.Collections.Generic;
using PageObject.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData.OpenXml
{
    public class ContentManager
    {
        public static ICollection<Customer> GetCustomerListFromXls()
        {
            ICollection<Customer> customersCollection;
            try
            {
                var excelPath = "excelpath";
                var excelCustomerDt = OpenXmlConnection.ReadExcelSheet(excelPath, "Customer");
                customersCollection = OpenXmlConnection.ExcelMappingToCustomer(excelCustomerDt);
            }
            catch (Exception)
            {
                customersCollection = null;
            }
            return customersCollection;
        }

        public static ICollection<User> GetUserListFromXls()
        {
            ICollection<User> usersCollection;
            try
            {
                var excelPath = "excelpath";
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
