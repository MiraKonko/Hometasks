using ExcelReader.FileExport;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExcelReader.ReportExport
{
    public class BookstoreReportExpotToJson : IReportExporter<BookDto>
    {
        public void SaveBookReportToFile(List<BookDto> listOfBooksToSave)
        {
            var saveToPath = "";
            var jsonExport = JsonConvert.SerializeObject(listOfBooksToSave);
            System.IO.File.WriteAllText(saveToPath, jsonExport);

        }
    }
}
