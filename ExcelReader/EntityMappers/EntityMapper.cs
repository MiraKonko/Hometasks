using OfficeOpenXml;
using System;
using System.Collections.Generic;

namespace ExcelReader.EntityMappers
{
    public class EntityMapper
    {
        public BookDto MapExcelDataToBookDto(ExcelWorksheet worksheet, int rowIndex)
        {
            Dictionary<string, int> ColumnIndexNames = new Dictionary<string, int>();

            for (int i = 1; i <= worksheet.Dimension.End.Column; i++)
            {
                ColumnIndexNames.Add(worksheet.Cells[1, i].Value.ToString(), i);
            }

            return new BookDto
            {
                Id = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames["ID"]].Text),
                Author = new AuthorDto
                {
                    FirstName = worksheet.Cells[rowIndex, ColumnIndexNames["Author"]].Text.Split(' ')[0],
                    LastName = worksheet.Cells[rowIndex, ColumnIndexNames["Author"]].Text.Split(' ')[1]
                },
                Title = worksheet.Cells[rowIndex, ColumnIndexNames["Title"]].Text,
                Price = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames["Price"]].Text),
                Genre = worksheet.Cells[rowIndex, ColumnIndexNames["Genre"]].Text,
                IsAvailable = Convert.ToBoolean(worksheet.Cells[rowIndex, ColumnIndexNames["Available"]].Text.ToLower()),
                AvailableBooksCount = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames["Available Books Count"]].Text),
                SoldBooksCount = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames["Sold Books Count"]].Text)
            };
        }
    }
}
