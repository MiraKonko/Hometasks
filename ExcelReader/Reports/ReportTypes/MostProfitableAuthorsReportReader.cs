using ExcelReader.CachedDataStorage;
using ExcelReaderModels.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.Reports
{
    public class MostProfitableAuthorsReportReader : IReportReader
    {
        public ReportDto ReadReport()
        {
            var report = GetTheMostProfitableAuthor();
            return report;
        }

        public ReportDto GetTheMostProfitableAuthor()
        {
            AuthorDto theMostProfitableAuthor = BookStorage.Instance.GroupBy(book => book.Author)
                .Select(book => new { Author = book.Key, TotalProfit = book.Sum(b => b.TotalSoldPrice) })
                .OrderByDescending(book => book.TotalProfit)
                .FirstOrDefault()
                .Author;

            var report = new ReportDto
            {
                Name = "TheMostProfitableAuthorReport",
                ReportContent = new List<string> { theMostProfitableAuthor.ToString() }
            };
            return report;
        }
    }
}
