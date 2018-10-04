using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.ConsoleInputOutput
{
    public class UserInputGetter : IConsoleReader, IConsolePrinter
    {
        public string GetReportCode()
        {
            ShowAvailableReportOptions();
            PrintToConsole("Enter report number:");
            string reportTypeCode = GetUserInput();
            return reportTypeCode;
        }

        private void ShowAvailableReportOptions()
        {
            PrintToConsole("For getting list of books by genre - enter 1." + Environment.NewLine +
                                          "For getting the most profitable author - enter 2." + Environment.NewLine +
                                          "For getting list of available authors - enter 3." + Environment.NewLine +
                                          "For getting not filtered list of books - enter 4." + Environment.NewLine);
        }

        public List<string> GetFileNamesForReport()
        {
            PrintToConsole("Please, enter file name for report (with .xlsx or .xls part)." + Environment.NewLine);
            ShowMultipleFilesForReportOptions();
            ShowAllAvailableFilesForReport();

            string fileNames = GetUserInput();
            List<string> fileNamesForReport = GetListOfFileNamesFromInput(fileNames);

            return fileNamesForReport;
        }

        private void ShowAllAvailableFilesForReport()
        {
            var fileReader = new FileReader();
            List<string> allAvailableFileNames = fileReader.GetAllExcelFileNamesFromFolder();

            for (int i = 0; i < allAvailableFileNames.Count; i++)
            {
                PrintToConsole(allAvailableFileNames[i]);
            }
        }

        private void ShowMultipleFilesForReportOptions()
        {
            PrintToConsole("For getting report from several files - enter file names separated by comma" + Environment.NewLine +
                        "For getting report from all available files enter '.' character." + Environment.NewLine +
                        $"Here are available files:");
        }

        private List<string> GetListOfFileNamesFromInput(string userInput)
        {
            var isAllFilesRequested = userInput == ".";
            var isMultipleFilesRequested = userInput.Contains(",");

            List<string> fileNames = new List<string>();
            var fileReader = new FileReader();

            if (isAllFilesRequested)
            {
                fileNames = fileReader.GetAllExcelFileNamesFromFolder();
            }
            else if (isMultipleFilesRequested)
            {
                fileNames = userInput.Split(',').ToList();
            }
            else
            {
                fileNames.Add(userInput);
            }

            return fileNames;
        }

        public void PrintToConsole(string output)
        {
            Console.WriteLine(output);
        }

        public string GetUserInput()
        {
            var userInput = Console.ReadLine();
            return userInput;
        }

        public string GetBookGenre()
        {
            PrintToConsole("Enter genre...");
            string genre = GetUserInput();
            return genre;
        }
    }
}
