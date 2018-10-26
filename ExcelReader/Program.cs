using ExcelReader.ConsoleInputOutput;
using ExcelReader.EntityMappers;
using ExcelReader.FileReaders;
using ExcelReader.Reports;
using ExcelReader.Reports.ReportSaving;
using ExcelReaderModels.DTOs;
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
                    var fileReader = new FileReader();
                    var consoleReaderPrinter = new ConsoleReaderPrinter(fileReader);
                    var entityMapper = new EntityMapper();

                    new BookStoreReader(consoleReaderPrinter, entityMapper).ReadAndStoreListOfBooksFromFiles();
                    var reportFactory = new BooksStoreReportFactory(consoleReaderPrinter);
                    var reportCreator = new ReportCreator(reportFactory);

                    ReportDto report = reportCreator.GetReport();
                    var printOption = consoleReaderPrinter.GetPrintToOption();

                    new ReportPrintStrategy().PrintReport(printOption, report);
                    if (printOption == "c")
                    {
                        var isReportSavingRequired = consoleReaderPrinter.IsReportSavingRequired();

                        if (isReportSavingRequired)
                        {
                            var exportOption = consoleReaderPrinter.GetExportToFileOption();
                            new ReportPrintStrategy().PrintReport(exportOption, report);
                        }
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
