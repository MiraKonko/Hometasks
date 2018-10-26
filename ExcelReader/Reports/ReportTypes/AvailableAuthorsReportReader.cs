using ExcelReader.CachedDataStorage;
using ExcelReaderModels.DTOs;
using System;
using System.Linq;

namespace ExcelReader.Reports
{
    public class AvailableAuthorsReportReader : IReportReader
    {
        public ReportDto ReadReport()
        {
            ReportDto report = GetListOfAvailableAuthors();
            return report;
        }

        private ReportDto GetListOfAvailableAuthors()
        {
            var report = new ReportDto
            {
                Name = "BooksFilteredByAvailableAuthors",
                ReportContent = BookStorage.Instance
                .Where(book => book.IsAvailable)
                .Select(book => book.Author.ToString())
                .Distinct()
                .ToList()
            };

            if (report.ReportContent.Count == 0)
            {
                throw new Exception("There is no available author!");
            }

            return report;
        }
    }
}
