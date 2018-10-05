using ExcelReader.CachedDataStorage;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.Reports
{
    public class MostProfitableAuthorsReport : IReportStrategy
    {
        public List<string> GetReport()
        {
            var report = GetTheMostProfitableAuthor();
            return report;
        }

        public List<string> GetTheMostProfitableAuthor()
        {
            List<string> report = new List<string>();
            var author = BookStorage.ListOfBooks.GroupBy(book => book.Author)
                .Select(book => new { Author = book.Key, TotalProfit = book.Sum(b => b.TotalSoldPrice) })
                .OrderByDescending(book => book.TotalProfit)
                .FirstOrDefault()
                .Author;

            report.Add(author.ToString());

            return report;
        }
    }
}
