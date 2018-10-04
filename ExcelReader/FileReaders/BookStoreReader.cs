using ExcelReader.CachedDataStorage;
using ExcelReader.ConsoleInputOutput;
using ExcelReader.EntityMappers;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.FileReaders
{
    public class BookStoreReader
    {
        private const int defaultSheetNumber = 1;
        private UserInputGetter _userInputGetter = new UserInputGetter();

        public void ReadAndStoreListOfBooksFromExcel()
        {
            List<BookDto> listOfBooks = GetListOfBooksFromMultipleExcels();
            BookStorage.StoredBooks = listOfBooks;
        }

        private List<BookDto> GetListOfBooksFromMultipleExcels()
        {
            List<string> fileNames = _userInputGetter.GetFileNamesForReport();

            List<BookDto> listOfBooks = new List<BookDto>();
            for (int i = 0; i < fileNames.Count(); i++)
            {
                listOfBooks.AddRange(GetListOfBooksFromExcel(fileNames[i]));
            }

            return listOfBooks;
        }

        private List<BookDto> GetListOfBooksFromExcel(string fileName)
        {
            using (ExcelPackage package = new ExcelReader().GetExcelPackage(fileName))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[defaultSheetNumber];
                List<BookDto> listOfBooks = new List<BookDto>();

                int rowToStartIndex = 2;
                int lastRowIndex = worksheet.Dimension.End.Row;
                var entityMapper = new EntityMapper();

                for (int i = rowToStartIndex; i <= lastRowIndex; i++)
                {
                    var book = entityMapper.MapExcelDataToBookDto(worksheet, i);
                    listOfBooks.Add(book);
                }

                return listOfBooks;
            }
        }
    }
}
