using ExcelReader.CachedDataStorage;
using ExcelReader.EntityMappers;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.FileReaders
{
    public class BookStoreReader
    {
        public void ReadAndStoreListOfBooksFromExcel(List<string> fileNames, int sheetNumber)
        {
            List<BookDto> listOfBooks = GetListOfBooksFromMultipleExcels(fileNames, sheetNumber);
            new BookStorage().StoredBooks = listOfBooks;
        }

        public List<BookDto> GetListOfBooksFromMultipleExcels(List<string> fileNames, int sheetNumber)
        {
            List<BookDto> listOfBooks = new List<BookDto>();
            for (int i = 0; i < fileNames.Count(); i++)
            {
                listOfBooks.AddRange(GetListOfBooksFromExcel(fileNames[i], sheetNumber));
            }
            return listOfBooks;
        }

        public List<BookDto> GetListOfBooksFromExcel(string fileName, int sheetNumber)
        {
            using (ExcelPackage package = new ExcelReader().GetExcelPackage(fileName))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetNumber];
                List<BookDto> ListOfBooks = new List<BookDto>();
                var lastRow = worksheet.Dimension.End.Row;

                for (int i = 2; i <= lastRow; i++)
                {
                    var book = new EntityMapper().MapExcelDataToBookDto(worksheet, i);
                    ListOfBooks.Add(book);
                }

                return ListOfBooks;
            }
        }
    }
}
