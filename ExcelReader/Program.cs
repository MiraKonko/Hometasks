using System;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to report loader!");
            Console.WriteLine("For getting list of books by genre - enter 1." + Environment.NewLine +
                              "For getting the most profitable author - enter 2." + Environment.NewLine +
                              "For getting list of available authours - enter 3." + Environment.NewLine +
                              "For getting not filered list of books - enter 4." + Environment.NewLine +
                              "For start - press any key, for Exit - click ESC.");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                try
                {
                    Console.WriteLine("Enter report number!");
                    var reportTypeCode = Console.ReadLine();
                    Console.WriteLine("Please, enter file name for report (with .xlsx or .xls part)...");
                    var fileName = Console.ReadLine();
                    var defaultSheetNumber = 1;
                    var reportsReader = new BooksStoreReportsReader(fileName, defaultSheetNumber);

                    reportsReader.PrintReportOnConsoleByReportTypeCode(reportTypeCode);
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
