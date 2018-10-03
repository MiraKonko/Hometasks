using ExcelReader.FileReaders;
using System;
using System.Collections.Generic;
using ExcelReader.ConsoleInputOutput;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var defaultSheetNumber = 1;
            Console.WriteLine("Welcome to report loader!");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                try
                {
                    var inputGetter = new UserInputGetter();
                    string reportTypeCode = inputGetter.GetReportCode();
                    List<string> fileNamesForReport = inputGetter.GetFileNamesForReport();

                    new BookStoreReader().ReadAndStoreListOfBooksFromExcel(fileNamesForReport, defaultSheetNumber);
                    List<string> report = new BooksStoreReports().GetReportByReportTypeCode(reportTypeCode);

                    var consolePrinter = new ConsolePrinter();
                    for (int i = 0; i < report.Count; i++)
                    {
                        consolePrinter.PrintToConsole(report[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong! {ex.Message}, additional info: {ex.InnerException?.Message}.");
                }
                finally
                {
                    Console.WriteLine("Please, press any key to try again!");
                }

            };
            Environment.Exit(0);
        }
    }
}
