using LinqToExcel;
using System;
using System.Collections.Generic;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleKeyInfo keyInfo;
            //string file name = "TestData.xlsx"
            Console.WriteLine("Welcome to report loader! Continue - press any key, for exit - press ESC. ");

            do
            {
                //keyInfo = Console.ReadKey(true);
                while (!Console.KeyAvailable)
                {
                    bool isFileNumberRead = false;
                    int reportNumber = 0;
                    while (!isFileNumberRead)
                    {
                        Console.WriteLine("Please, enter number of reports you'd like to load (from 1 to 3 can       )...");
                        var result = int.TryParse(Console.ReadLine(), out reportNumber);
                        if (result)
                        {
                            if (reportNumber > 3 && reportNumber < 1)
                            {
                                Console.WriteLine("Please, enter number from 1 to 3!");
                            }
                            else
                            {
                                isFileNumberRead = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please, enter number from 1 to 3!");
                        }
                    }
                    List<string> filesToExport = new List<string>();

                    for (int i = 0; i < reportNumber; i++)
                    {
                        Console.WriteLine($"Please, enter file name to print (with .xlsx)...");
                        var isRetryRequired = true;
                        while (isRetryRequired)
                        {

                            string userInput = Console.ReadLine();
                            var isFileWithNamePresent = FileReaderHelper.IsFileWithNamePresentInTheDirectory(userInput);
                            if (!isFileWithNamePresent)
                            {
                                Console.WriteLine($"There is no file with name '{userInput}'!");
                                Console.WriteLine("If you'd like to retry - press 1, continue anyway - press any key!");
                                var userAction = int.Parse(Console.ReadLine());
                                if (userAction == 1)
                                {
                                    Console.WriteLine("Please, re-enter file name...");
                                }
                                else
                                {
                                    isRetryRequired = false;
                                }
                            }
                            else
                            {
                                isRetryRequired = false;
                                filesToExport.Add(userInput);
                            }
                        }

                    }

                    foreach (var file in filesToExport)
                    {
                        string pathToFile = FileReaderHelper.BuildPathToFile(file);
                        string sheetName = "Sheet1";
                        PrintExcelReportToConsole(pathToFile, sheetName);

                    }
                    Console.ReadLine();
                }

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.ReadLine();
        }

        public static void PrintExcelReportToConsole(string pathToFile, string sheetName)
        {
            var doc = new ExcelQueryFactory(pathToFile);
            var sheet = doc.Worksheet<Row>();
            foreach (var row in sheet)
            {
                foreach (var column in doc.GetColumnNames(sheetName))
                {
                    Console.Write($"| {row[column]} ");
                }
                Console.WriteLine();
            }
        }
    }


}
