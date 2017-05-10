using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PageObject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestData.OpenXml
{
    public class OpenXmlConnection
    {
        internal static readonly List<string> Headers = new List<string>();

        internal static DataTable ReadExcelSheet(string fname, string sheetName)
        {
            var dt = new DataTable();
            using (var doc = SpreadsheetDocument.Open(fname, false))
            {
                //Read the first Sheets 
                var sheet = doc.WorkbookPart.Workbook.Descendants<Sheet>().Single(x => x.Name == sheetName);
                var worksheetPart = doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;
                if (worksheetPart == null) return dt;
                var worksheet = worksheetPart.Worksheet;
                var rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                foreach (var row in rows)
                {
                    //Read the first row as header
                    if (row.RowIndex.Value == 1)
                    {
                        foreach (var cell in row.Descendants<Cell>())
                        {
                            var colunmName = GetCellValue(doc, cell);
                            Headers.Add(colunmName);
                            dt.Columns.Add(colunmName);
                        }
                    }
                    else
                    {
                        dt.Rows.Add();
                        var i = 0;
                        foreach (var cell in row.Descendants<Cell>())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = GetCellValue(doc, cell);
                            i++;
                        }
                    }
                }
            }
            return dt;
        }

        private static string GetCellValue(SpreadsheetDocument doc, CellType cell)
        {
            string value;
            if (cell.DataType == null)
            {
                value = cell.CellValue != null ? DateTime.FromOADate(int.Parse(cell.CellValue.InnerText)).ToShortDateString() : string.Empty;
            }
            else
            {
                value = cell.CellValue.InnerText;
            }
            if (cell.DataType == null || cell.DataType.Value != CellValues.SharedString) return value;

            return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
        }


        internal static string ParseStringCell(DataRow rw, string property)
        {
            return rw[property] is DBNull || rw[property].Equals("x") ? string.Empty : Convert.ToString(rw[property]);
        }
        internal static bool ParseBoolCell(DataRow rw, string property)
        {
            return !(rw[property] is DBNull) && Convert.ToBoolean(rw[property].ToString() == "1" ? "true" : "false");
        }

        internal static DateTime ParseDateCell(DataRow rw, string property)
        {
            return rw[property] is DBNull || rw[property].Equals("x") ? DateTime.MinValue : Convert.ToDateTime(rw[property]);
        }

        internal static List<Customer> ExcelMappingToCustomer(DataTable dt)
        {
            var customerList = new List<Customer>();
            foreach (var rw in dt.AsEnumerable())
            {
                var customer = new Customer()
                {
                    Name = ParseStringCell(rw, "NewsContainerUrl"),
                    Date = ParseStringCell(rw, "Lead"),
                    Gender = ParseStringCell(rw, "Teaser"),
                    Address = ParseStringCell(rw, "TeaserImage"),
                    City = ParseStringCell(rw, "DateOfNews"),
                    State = ParseStringCell(rw, "EndDateOfNews"),
                    Pin = ParseStringCell(rw, "Function"),
                    Telephone = ParseStringCell(rw, "Location"),
                    Email = ParseStringCell(rw, "AllOrganisations"),
                    Password = ParseStringCell(rw, "Organisation"),

                };
                customerList.Add(customer);
            }
            return customerList;
        }

        internal static List<User> ExcelMappingToUser(DataTable dt)
        {
            var userList = new List<User>();
            foreach (var rw in dt.AsEnumerable())
            {
                var user = new User()
                {
                    UserId = ParseStringCell(rw, "NewsContainerUrl"),
                    Password = ParseStringCell(rw, "Lead")
                };
                userList.Add(user);
            }
            return userList;
        }


    }
}
