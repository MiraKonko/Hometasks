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
        private UserInputInterpretator _userInputInterpretator;
        private EntityMapper _entityMapper;

        public BookStoreReader(UserInputInterpretator userInputInterpretator, EntityMapper entityMapper)
        {
            _userInputInterpretator = userInputInterpretator;
            _entityMapper = entityMapper;
        }


        public void ReadAndStoreListOfBooksFromFiles()
        {
            List<string> fileNames = _userInputInterpretator.GetFileNamesForReport();

            for (int i = 0; i < fileNames.Count(); i++)
            {
                if (!IsFileContentPresentInStorage(fileNames[i]))
                {
                    List<BookDto> listOfBooks = GetListOfBooksFromExcel(fileNames[i]);
                    BookStorage.SavedBookStorages.Add(fileNames[i], listOfBooks);
                }
            }
        }

        private bool IsFileContentPresentInStorage(string fileName)
        {
            var isFileInStorage = BookStorage.SavedBookStorages.Keys.Contains(fileName);
            return isFileInStorage;
        }

        private List<BookDto> GetListOfBooksFromExcel(string fileName)
        {
            using (ExcelPackage package = new ExcelReader().GetExcelPackage(fileName))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[defaultSheetNumber];
                List<BookDto> listOfBooks = new List<BookDto>();

                int rowToStartIndex = 2;
                int lastRowIndex = worksheet.Dimension.End.Row;

                for (int i = rowToStartIndex; i <= lastRowIndex; i++)
                {
                    var book = _entityMapper.MapExcelDataToBookDto(worksheet, i);
                    listOfBooks.Add(book);
                }

                return listOfBooks;
            }
        }
    }
}
