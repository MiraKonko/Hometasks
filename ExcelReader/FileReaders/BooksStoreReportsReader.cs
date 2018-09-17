using ExcelReader.CachedDataStorage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ExcelReader
{
    public class BooksStoreReportsReader
    {
        public void PrintReportOnConsoleByReportTypeCode(string reportTypeCode)
        {
            var consolePrinter = new ConsolePrinter();
            switch (reportTypeCode)
            {
                case "1":
                    Console.WriteLine("Enter genre...");
                    var genre = Console.ReadLine();
                    List<BookDto> listOfBooksFilteredByGenre = GetListOfBooksByGenre(genre);
                    for (int i = 1; i <= listOfBooksFilteredByGenre.Count; i++)
                    {
                        consolePrinter.PrintReportStringToConsole(listOfBooksFilteredByGenre[i].ToString());
                    }
                    break;
                case "2":
                    List<string> availalbeAutors = GetListOfAvailableAuthors();
                    for (int i = 1; i <= availalbeAutors.Count; i++)
                    {
                        consolePrinter.PrintReportStringToConsole(availalbeAutors[i]);
                    }
                    break;
                case "3":
                    string theMostProfitableAuthor = GetTheMostProfitableAuthor();
                    consolePrinter.PrintReportStringToConsole(theMostProfitableAuthor);
                    break;
                case "4":
                    var listOfBooks = Context.Current.Get<List<BookDto>>(ContextKeys.STORED_BOOK_LIST);
                    for (int i = 1; i <= listOfBooks.Count; i++)
                    {
                        consolePrinter.PrintReportStringToConsole(listOfBooks[i].ToString());
                    }
                    break;
                default:
                    throw new Exception("Unknown operation code! Please, enter from the list of available ones!");
            }
        }

        public List<BookDto> GetListOfBooksByGenre(string genre)
        {
            var filteredListOfBooks = Context.Current.Get<List<BookDto>>(ContextKeys.STORED_BOOK_LIST).Where(book => book.Genre == genre).ToList();
            if (filteredListOfBooks.Count == 0)
            {
                throw new Exception($"There is no book with genre '{genre}'!");
            }
            return filteredListOfBooks;
        }

        public List<string> GetListOfAvailableAuthors()
        {
            var listAvailableAuthors = Context.Current.Get<List<BookDto>>(ContextKeys.STORED_BOOK_LIST).Where(book => book.IsAvailalbe).Select(book => book.Author).Distinct().ToList();
            if (listAvailableAuthors.Count == 0)
            {
                throw new Exception("There is no available author!");
            }
            return listAvailableAuthors;
        }

        public string GetTheMostProfitableAuthor()
        {
            var author = Context.Current.Get<List<BookDto>>(ContextKeys.STORED_BOOK_LIST).GroupBy(book => book.Author)
                .Select(book => new { Author = book.Key, TotalProfit = book.Sum(b => b.TotalSoldPrice) }).OrderByDescending(book => book.TotalProfit).FirstOrDefault().Author;
            return author;
        }
    }
}