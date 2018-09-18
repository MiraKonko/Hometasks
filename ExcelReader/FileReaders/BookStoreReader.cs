using ExcelReader.CachedDataStorage;
using ExcelReader.EntityMappers;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.FileReaders
{
    public class BookStoreReader
    {
        public void ReadListOfBooksFromExcelAndStoreInContext(string fileName, int sheetNumber)
        {
            List<BookDto> listOfBooks = GetListOfBooksFromExcel(fileName, sheetNumber);
            Context.Current.Set(ContextKeys.STORED_BOOK_LIST, listOfBooks);
        }

        public void ReadListOfBooksFromExcelAndStoreInContext(string[] fileNames, int sheetNumber)
        {
            List<BookDto> listOfBooks = GetListOfBooksFromExcel(fileNames, sheetNumber);
            Context.Current.Set(ContextKeys.STORED_BOOK_LIST, listOfBooks);
        }

        public List<BookDto> GetListOfBooksFromExcel(string[] fileNames, int sheetNumber)
        {
            List<BookDto> listOfBooks = new List<BookDto>();
            for (int i = 1; i <= fileNames.Count(); i++)
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
                var rowsCount = worksheet.Cells.Select(cell => cell.Start.Row).OrderBy(x => x).Skip(1).Count();
                for (int i = 2; i <= rowsCount; i++)
                {
                    var book = new EntityMapper().MapExcelDataToBookDto(worksheet, i);
                    ListOfBooks.Add(book);
                }
                return ListOfBooks;
            }
        }
    }
}
