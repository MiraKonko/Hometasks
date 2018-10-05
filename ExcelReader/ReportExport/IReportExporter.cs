using System.Collections.Generic;
namespace ExcelReader.FileExport
{
    public interface IReportExporter<T>
    {
        void SaveBookReportToFile(List<T> listOfBooksToSave);
    }
}
