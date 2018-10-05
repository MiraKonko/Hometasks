using ExcelReader.FileExport;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExcelReader.ReportExport
{
    public class ReportToJsonExport : IReportExport
    {
        public void SaveBookReportToFile(List<BookDto> listOfBooksToSave)
        {
            var jsonExport = JsonConvert.SerializeObject(listOfBooksToSave);
            System.IO.File.WriteAllText("", jsonExport);

        }
    }
}
