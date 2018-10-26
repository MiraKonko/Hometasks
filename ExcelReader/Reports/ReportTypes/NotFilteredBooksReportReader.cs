using ExcelReader.CachedDataStorage;
using ExcelReaderModels.DTOs;
using System.Linq;

namespace ExcelReader.Reports
{
    public class NotFilteredBooksReportReader : IReportReader
    {
        public ReportDto ReadReport()
        {
            var report = new ReportDto
            {
                Name = "NotFilteredBooksReport",
                ReportContent = BookStorage.Instance
                .Select(book => book.ToString())
                .ToList()
            };

            return report;
        }
    }
}
