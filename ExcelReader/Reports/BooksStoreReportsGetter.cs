using ExcelReader.ConsoleInputOutput;
using ExcelReader.Reports;
using System;
using System.Collections.Generic;

namespace ExcelReader
{
    public class BooksStoreReportGetter
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
                    SetReportStategy(new MostProfitableAuthorsReport());
                    break;
                case (int)BookStoreReportTypes.AvailableAuthors:
                    SetReportStategy(new AvailableAuthorsReport());
                    break;
                case (int)BookStoreReportTypes.AllBooks:
                    SetReportStategy(new NotFilteredBooksReport());
                    break;
                default:
                    throw new Exception("Unknown operation code! Please, enter from the list of available ones!");
            }

            List<string> report = _reportStrategy.GetReport();
            return report;
        }

        private void SetReportStategy(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;
        }
    }
}