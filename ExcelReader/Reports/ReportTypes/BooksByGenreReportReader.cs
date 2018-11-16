using ExcelReader.CachedDataStorage;
using ExcelReader.ConsoleInputOutput;
using ExcelReaderModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.Reports
{
    public class BooksByGenreReportReader : IReportReader
    {
        private UserInputInterpretator _userInputInterpretator;
        public BooksByGenreReportReader(UserInputInterpretator userInputInterpretator)
        {
            _userInputInterpretator = userInputInterpretator;
        }

        public ReportDto ReadReport()
        {
            string genre = _userInputInterpretator.GetBookGenre();
            List<string> reportColumns = _userInputInterpretator.GetColumnsForReport();
            ReportDto report = GetListOfBooksByGenre(genre);
            return report;
        }

        private ReportDto GetListOfBooksByGenre(string genre)
        {
            var reportContent = BookStorage.Instance
                .Where(book => book.Genre.ToLower() == genre.ToLower())
                .Select(book => book.ToString())
                .ToList();

            var report = new ReportDto
            {
                Name = "BooksReportFilteredBy" + genre.ToUpper(),
                ReportContent = reportContent
            };

            if (report.ReportContent.Count() == 0)
            {
                throw new Exception($"There is no book with genre '{genre}'!");
            }
            return report;
        }

        private List<BookDto> FilterReportByColumns(List<BookDto> reportContent, List<string> columns)
        {
            List<BookDto> filteredReport = new List<BookDto>();
            foreach (var book in reportContent)
            {

            }
            return filteredReport;
        }
    }
}
