using System;
using System.Collections.Generic;
using ExcelReader.EntityMappers;
using OfficeOpenXml;
namespace ExcelReader.FileExport
{
    public class BookReportExport
    {
        public void SaveBookReportToExcel(List<BookDto> listOfBooksToSave)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add("BookStoreReport");
                //new EntityMapper().MapBookDtoToExcelWoksheet(excelWorksheet);
            }
        }

        public void SaveStringToFile(string stringToSave)
        {

        }
    }
}
