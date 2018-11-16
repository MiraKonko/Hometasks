using ExcelReader.Abstractions;
using ExcelReader.ConsoleInputOutput;
using ExcelReader.Reports;
using System;

namespace ExcelReader
{
    public class BooksStoreReportFactory : IReportReaderFactory
    {
        private UserInputInterpretator _consoleReaderPrinter;

        public BooksStoreReportFactory(UserInputInterpretator consoleReaderPrinter)
        {
            _consoleReaderPrinter = consoleReaderPrinter;
        }

        public IReportReader CreateReportReader()
        {
            int reportTypeCode = _consoleReaderPrinter.GetReportCode();

            switch (reportTypeCode)
            {
                case (int)BookStoreReportTypes.ByGenre:
                    return (new BooksByGenreReportReader(_consoleReaderPrinter));
                case (int)BookStoreReportTypes.TheMostProfitableAuthor:
                    return new MostProfitableAuthorsReportReader();
                case (int)BookStoreReportTypes.AvailableAuthors:
                    return new AvailableAuthorsReportReader();
                case (int)BookStoreReportTypes.AllBooks:
                    return new NotFilteredBooksReportReader();
                default:
                    throw new Exception("Unknown operation code! Please, enter from the list of available ones!");
            }
        }
    }
}