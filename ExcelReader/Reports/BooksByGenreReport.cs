using ExcelReader.CachedDataStorage;
using ExcelReader.ConsoleInputOutput;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.Reports
{
    public class BooksByGenreReport : IReportStrategy
    {
        private UserInputGetter _userInputGetter = new UserInputGetter();

        public List<string> GetReport()
        {
            string genre = _userInputGetter.GetBookGenre();
            List<string> report = GetListOfBooksByGenre(genre);
            return report;
        }

        private List<string> GetListOfBooksByGenre(string genre)
        {
            var filteredListOfBooks = BookStorage.StoredBooks.Where(book => book.Genre.ToLower() == genre.ToLower()).Select(book => book.ToString()).ToList();
            if (filteredListOfBooks.Count == 0)
            {
                throw new Exception($"There is no book with genre '{genre}'!");
            }
            return filteredListOfBooks;
        }
    }
}
