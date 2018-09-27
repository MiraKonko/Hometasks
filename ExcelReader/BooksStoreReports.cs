using ExcelReader.CachedDataStorage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ExcelReader
{
    public class BooksStoreReports
    {
        public List<string> GetReportByReportTypeCode(string reportTypeCode)
        {
            List<string> report;
            switch (reportTypeCode)
            {
                case "1":
                    Console.WriteLine("Enter genre...");
                    var genre = Console.ReadLine();
                    report = GetListOfBooksByGenre(genre);
                    break;
                case "2":
                    report = GetTheMostProfitableAuthor();
                    break;
                case "3":
                    report = GetListOfAvailableAuthors();
                    break;
                case "4":
                    report = new BookStorage().StoredBooks.Select(book => book.ToString()).ToList();
                    break;
                default:
                    throw new Exception("Unknown operation code! Please, enter from the list of available ones!");
            }
            return report;
        }

        public List<string> GetListOfBooksByGenre(string genre)
        {
            var filteredListOfBooks = new BookStorage().StoredBooks.Where(book => book.Genre.ToLower() == genre.ToLower()).Select(book => book.ToString()).ToList();
            if (filteredListOfBooks.Count == 0)
            {
                throw new Exception($"There is no book with genre '{genre}'!");
            }
            return filteredListOfBooks;
        }

        public List<string> GetListOfAvailableAuthors()
        {
            var listAvailableAuthors = new BookStorage().StoredBooks.Where(book => book.IsAvailalbe).Select(book => book.Author.ToString()).Distinct().ToList();
            if (listAvailableAuthors.Count == 0)
            {
                throw new Exception("There is no available author!");
            }
            return listAvailableAuthors;
        }

        public List<string> GetTheMostProfitableAuthor()
        {
            List<string> report = new List<string>();
            var author = new BookStorage().StoredBooks.GroupBy(book => book.Author)
                .Select(book => new { Author = book.Key, TotalProfit = book.Sum(b => b.TotalSoldPrice) })
                .OrderByDescending(book => book.TotalProfit)
                .FirstOrDefault()
                .Author;

            report.Add(author.ToString());

            return report;
        }
    }
}