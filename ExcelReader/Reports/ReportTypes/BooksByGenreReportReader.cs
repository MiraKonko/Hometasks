using ExcelReader.CachedDataStorage;
using ExcelReader.ConsoleInputOutput;
using ExcelReaderModels.DTOs;
using System;
using System.Linq;

namespace ExcelReader.Reports
{
    public class BooksByGenreReportReader : IReportReader
    {
        private ConsoleReaderPrinter _consoleReaderPrinter;
        public BooksByGenreReportReader(ConsoleReaderPrinter consoleReaderPrinter)
        {
            _consoleReaderPrinter = consoleReaderPrinter;
        }

        public ReportDto ReadReport()
        {
            string genre = _consoleReaderPrinter.GetBookGenre();
            ReportDto report = GetListOfBooksByGenre(genre);
            return report;
        }

        private ReportDto GetListOfBooksByGenre(string genre)
        {
            var report = new ReportDto
            {
                Name = "BooksReportFilteredBy" + genre.ToUpper(),
                ReportContent = BookStorage.Instance
                .Where(book => book.Genre.ToLower() == genre.ToLower())
                .Select(book => book.ToString())
                .ToList()
            };

            if (report.ReportContent.Count() == 0)
            {
                throw new Exception($"There is no book with genre '{genre}'!");
            }
            return report;
        }
    }
}
