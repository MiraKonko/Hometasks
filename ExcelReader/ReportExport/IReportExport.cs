using System.Collections.Generic;
namespace ExcelReader.FileExport
{
    interface IReportExport
    {
        void SaveBookReportToFile(List<BookDto> listOfBooksToSave);
    }
}
