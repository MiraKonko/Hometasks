using ExcelReader.FileReaders;
using System;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var defaultSheetNumber = 1;
            Console.WriteLine("Welcome to report loader!");
            Console.WriteLine("For getting list of books by genre - enter 1." + Environment.NewLine +
                              "For getting the most profitable author - enter 2." + Environment.NewLine +
                              "For getting list of available authors - enter 3." + Environment.NewLine +
                              "For getting not filtered list of books - enter 4." + Environment.NewLine +
                              "For start - press any key, for Exit - click ESC.");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                try
                {
                    Console.WriteLine("Enter report number!");
                    var reportTypeCode = Console.ReadLine();
                    Console.WriteLine("Please, enter file name for report (with .xlsx or .xls part)." + Environment.NewLine +
                        "For getting report from several files - enter file names separated by comma" + Environment.NewLine +
                        "For getting report from all available files enter '.' character.");
                    var fileName = Console.ReadLine();
                    if (fileName == ".")
                    {

                    }
                    else if (true)
                    {

                    }
                    else
                    {
                        new BookStoreReader().ReadListOfBooksFromExcelAndStoreInContext(fileName, defaultSheetNumber);
                        var reportsReader = new BooksStoreReportsReader();
                        reportsReader.PrintReportOnConsoleByReportTypeCode(reportTypeCode);
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
