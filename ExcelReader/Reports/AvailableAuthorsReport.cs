using ExcelReader.CachedDataStorage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.Reports
{
    public class AvailableAuthorsReport : IReportStrategy
    {
        public List<string> GetReport()
        {
            List<string> report = GetListOfAvailableAuthors();
            return report;
        }

        private List<string> GetListOfAvailableAuthors()
        {
            var listAvailableAuthors = BookStorage.ListOfBooks.Where(book => book.IsAvailable)
                .Select(book => book.Author.ToString())
                .Distinct()
                .ToList();

            if (listAvailableAuthors.Count == 0)
            {
                throw new Exception("There is no available author!");
            }

            return listAvailableAuthors;
        }
    }
}
