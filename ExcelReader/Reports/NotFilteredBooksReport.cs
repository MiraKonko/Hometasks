using ExcelReader.CachedDataStorage;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.Reports
{
    public class NotFilteredBooksReport : IReportStrategy
    {
        public List<string> GetReport()
        {
            var report = BookStorage.ListOfBooks.Select(book => book.ToString()).ToList();
            return report;
        }
    }
}
