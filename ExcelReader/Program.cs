﻿using ExcelReader.FileReaders;
using System;
using System.Collections.Generic;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to report loader!");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                try
                {
                    new BookStoreReader().ReadAndStoreListOfBooksFromExcel();
                    List<string> report = new BooksStoreReports().GetReportByReportTypeCode();

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
