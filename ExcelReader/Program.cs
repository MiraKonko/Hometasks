using ExcelReader.ConsoleInputOutput;
using ExcelReader.EntityMappers;
using ExcelReader.FileReaders;
using ExcelReader.Reports;
using ExcelReader.Reports.ReportSaving;
using ExcelReaderModels.DTOs;
using Ninject;
using System;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to report loader! Press any key to start...");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                try
                {
                    IKernel kernel = new StandardKernel();
                    var fileReader = kernel.Get<FileReader>();
                    var consoleReaderPrinter = kernel.Get<ConsoleReaderPrinter>();
                    var userInputInterpretator = kernel.Get<UserInputInterpretator>();
                    var entityMapper = kernel.Get<EntityMapper>();
                    var bookStoreReader = kernel.Get<BookStoreReader>();
                    var reportFactory = kernel.Get<BooksStoreReportFactory>();
                    var reportCreator = kernel.Get<ReportCreator>();
                    var reportPrintingStrategy = kernel.Get<ReportPrintStrategy>();

                    bookStoreReader.ReadAndStoreListOfBooksFromFiles();
                    ReportDto report = reportCreator.GetReport();
                    var printOption = userInputInterpretator.GetPrintToOption();

                    reportPrintingStrategy.PrintReport(printOption, report);
                    SaveReportIfRequired(userInputInterpretator, report, printOption);

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

        private static void SaveReportIfRequired(UserInputInterpretator userInputInterpretator, ReportDto report, string printOption)
        {
            if (printOption == "c")
            {
                var isReportSavingRequired = userInputInterpretator.IsReportSavingRequired();

                if (isReportSavingRequired)
                {
                    var exportOption = userInputInterpretator.GetExportToFileOption();
                    new ReportPrintStrategy().PrintReport(exportOption, report);
                }
            }
        }
    }
}
