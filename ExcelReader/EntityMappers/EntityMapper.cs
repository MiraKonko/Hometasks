using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.EntityMappers
{
    public class EntityMapper
    {
        public BookDto MapExcelDataToBookDto(ExcelWorksheet worksheet, int rowIndex)
        {
            Dictionary<int, string> ColumnIndexNames = new Dictionary<int, string>();
            for (int i = 1; i <= worksheet.Dimension.End.Column; i++)
            {
                ColumnIndexNames.Add(i, worksheet.Cells[1, i].Value.ToString());
            }
            return new BookDto
            {
                Id = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "ID").Key].Text),
                Author = worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "Author").Key].Text,
                Title = worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "Title").Key].Text,
                Price = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "Price").Key].Text),
                Genre = worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "Genre").Key].Text,
                IsAvailalbe = bool.Parse(worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "Available").Key].Text),
                AvailableBooksCount = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "Sold Books Count").Key].Text),
                SoldBooksCount = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames.FirstOrDefault(item => item.Value == "Total Sold Price").Key].Text)
            };
        }
    }
}
