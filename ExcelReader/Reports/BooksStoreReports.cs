using ExcelReader.CachedDataStorage;
using ExcelReader.ConsoleInputOutput;
using ExcelReader.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ExcelReader
{
    public class BooksStoreReports
    {
        private UserInputGetter _userInputGetter = new UserInputGetter();
        private IReportStrategy _reportStrategy;

        public List<string> GetReportByReportTypeCode()
        {
            int reportTypeCode = _userInputGetter.GetReportCode();

            switch (reportTypeCode)
            {
                case (int)BookStoreReportTypes.ByGenre:
                    SetReportStategy(new BooksByGenreReport());
                    break;
                case (int)BookStoreReportTypes.TheMostProfitableAuthor:
                    SetReportStategy(new AvailableAuthorsReport());
                    break;
                case (int)BookStoreReportTypes.AvailableAuthors:
                    report = GetListOfAvailableAuthors();
                    break;
                case (int)BookStoreReportTypes.AllBooks:
                    report = BookStorage.StoredBooks.Select(book => book.ToString()).ToList();
                    break;
                default:
                    throw new Exception("Unknown operation code! Please, enter from the list of available ones!");
            }
            List<string> report = _reportStrategy.GetReport();
            return report;
        }

        public void SetReportStategy(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;
        }

        public List<string> GetTheMostProfitableAuthor()
        {
            List<string> report = new List<string>();
            var author = BookStorage.StoredBooks.GroupBy(book => book.Author)
                .Select(book => new { Author = book.Key, TotalProfit = book.Sum(b => b.TotalSoldPrice) })
                .OrderByDescending(book => book.TotalProfit)
                .FirstOrDefault()
                .Author;

            report.Add(author.ToString());

            return report;
        }
    }
}