using ExcelReader.FileReaders;
using System;
using System.Collections.Generic;
using System.Linq;

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
                              "Enter report number:");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                //try
                //{
                var consolePrinter = new ConsolePrinter();
                var fileReader = new FileReader();
                var allAvailalbeFilesNames = fileReader.GetAllExcelFileNamesFromFolder();
                var reportTypeCode = Console.ReadLine();

                Console.WriteLine("Please, enter file name for report (with .xlsx or .xls part)." + Environment.NewLine +
                    "For getting report from several files - enter file names separated by comma" + Environment.NewLine +
                    "For getting report from all available files enter '.' character." + Environment.NewLine +
                    $"Here are availalbe files:");

                for (int i = 0; i < allAvailalbeFilesNames.Count; i++)
                {
                    consolePrinter.PrintStringToConsole(allAvailalbeFilesNames[i]);
                }

                var fileNames = Console.ReadLine();
                List<string> fileNamesForReport = fileReader.GetListOfFilesNamesFromUserInput(fileNames);
                new BookStoreReader().ReadAndStoreListOfBooksFromExcel(fileNamesForReport, defaultSheetNumber);
                List<string> report = new BooksStoreReports().GetReportByReportTypeCode(reportTypeCode);

                for (int i = 0; i < report.Count; i++)
                {
                    consolePrinter.PrintStringToConsole(report[i]);
                }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Something went wrong! {ex.Message}, additional info: {ex.InnerException?.Message}.");
                //}
                //finally
                //{
                //    Console.WriteLine("Please, press any key to try again!");
                //}

            };
            Environment.Exit(0);
        }
    }
}
