using ExcelReader.EntityMappers;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ExcelReader
{
    public class BooksStoreReportsReader
    {
        public List<BookDto> ListOfBooks;

        public BooksStoreReportsReader(string fileName, int sheetNumber)
        {
            ListOfBooks = GetListOfBooksFromExcel(fileName, sheetNumber);
            if (ListOfBooks.Count == 0)
            {
                throw new Exception($"There is no books in file '{fileName}'");
            }
        }

        public void PrintReportOnConsoleByReportTypeCode(string reportTypeCode)
        {
            var consolePrinter = new ConsolePrinter();
            switch (reportTypeCode)
            {
                case "1":
                    Console.WriteLine("Enter genre...");
                    var genre = Console.ReadLine();
                    List<BookDto> listOfBooksFilteredByGenre = GetListOfBooksByGenre(genre);
                    List<string> convertedBooks = new List<string>();
                    listOfBooksFilteredByGenre.ForEach(book => convertedBooks.Add(book.ToString()));
                    consolePrinter.PrintListToConsole(convertedBooks);
                    break;
                case "2":
                    List<string> availalbeAutors = GetListOfAvailableAuthors();
                    consolePrinter.PrintListToConsole(availalbeAutors);
                    break;
                case "3":
                    string theMostProfitableAuthor = GetTheMostProfitableAuthor();
                    consolePrinter.PrintReportStringToConsole(theMostProfitableAuthor);
                    break;
                case "4":
                    List<string> booksToString = new List<string>();
                    ListOfBooks.ForEach(book => booksToString.Add(book.ToString()));
                    consolePrinter.PrintListToConsole(booksToString);
                    break;
                default:
                    throw new Exception("Unknown operation code! Please, enter from the list of available ones!");
            }
        }

        public List<BookDto> GetListOfBooksByGenre(string genre)
        {
            var filteredListOfBooks = ListOfBooks.Where(book => book.Genre == genre).ToList();
            if (filteredListOfBooks.Count == 0)
            {
                throw new Exception($"There is no book with genre '{genre}'!");
            }
            return filteredListOfBooks;
        }

        public List<string> GetListOfAvailableAuthors()
        {
            var listAvailableAuthors = ListOfBooks.Where(book => book.IsAvailalbe).Select(book => book.Author).Distinct().ToList();
            if (listAvailableAuthors.Count == 0)
            {
                throw new Exception("There is no available author!");
            }
            return listAvailableAuthors;
        }

        public string GetTheMostProfitableAuthor()
        {
            var author = ListOfBooks.GroupBy(book => book.Author)
                                   .Select(book => new { Author = book.Key, TotalProfit = book.Sum(b => b.TotalSoldPrice) })
                                   .OrderByDescending(book => book.TotalProfit)
                                    .FirstOrDefault()
                                   .Author;
            return author;
        }

        private List<BookDto> GetListOfBooksFromExcel(string fileName, int sheetNumber)
        {
            using (ExcelPackage package = new ExcelReader().GetExcelPackage(fileName))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetNumber];
                var rowsCount = worksheet.Cells.Select(cell => cell.Start.Row).OrderBy(x => x).Skip(1).Count();
                for (int i = 2; i <= rowsCount; i++)
                {
                    var book = new EntityMapper().MapExcelDataToBookDto(worksheet, i);
                    ListOfBooks.Add(book);
                }
                return ListOfBooks;
            }
        }
    }
}