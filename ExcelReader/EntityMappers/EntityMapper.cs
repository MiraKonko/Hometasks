using OfficeOpenXml;
using System.Collections.Generic;
using System;
using System.Linq;

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
                IsAvailalbe = Convert.ToBoolean(worksheet.Cells[rowIndex, ColumnIndexNames["Available"]].Text.ToLower()),
                AvailableBooksCount = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames["Available Books Count"]].Text),
                SoldBooksCount = int.Parse(worksheet.Cells[rowIndex, ColumnIndexNames["Sold Books Count"]].Text)
            };
        }

        public ExcelWorksheet MapBookDtoToExcelWoksheet(ExcelWorksheet excelWorksheet, List<BookDto> bookDtos)
        {
            excelWorksheet.Cells[1, 1].Value = "ID";
            excelWorksheet.Cells[1, 2].Value = "Author";
            excelWorksheet.Cells[1, 3].Value = "Title";
            excelWorksheet.Cells[1, 4].Value = "Price";
            excelWorksheet.Cells[1, 5].Value = "Genre";
            excelWorksheet.Cells[1, 6].Value = "Availalbe";
            excelWorksheet.Cells[1, 7].Value = "Available Books Count";
            excelWorksheet.Cells[1, 8].Value = "Sold Books Count";

            for (int i = 0; i <= bookDtos.Count; i++)
            {
                var rowIndex = i + 2;
                excelWorksheet.Cells[rowIndex, 1].Value = bookDtos.ElementAt(i).Id;
                excelWorksheet.Cells[rowIndex, 2].Value = bookDtos.ElementAt(i).Author;
                excelWorksheet.Cells[rowIndex, 8].Value = bookDtos.ElementAt(i).Title;
                excelWorksheet.Cells[rowIndex, 3].Value = bookDtos.ElementAt(i).Price;
                excelWorksheet.Cells[rowIndex, 4].Value = bookDtos.ElementAt(i).Genre;
                excelWorksheet.Cells[rowIndex, 5].Value = bookDtos.ElementAt(i).IsAvailalbe;
                excelWorksheet.Cells[rowIndex, 6].Value = bookDtos.ElementAt(i).AvailableBooksCount;
                excelWorksheet.Cells[rowIndex, 7].Value = bookDtos.ElementAt(i).SoldBooksCount;
            }
            return excelWorksheet;
        }
    }
}
