using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.ConsoleInputOutput
{
    public class UserInputGetter : IConsoleReader, IConsolePrinter
    {
        public string GetReportNumber()
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
            ShowAvailableFilesForReport();

            var fileNames = GetUserInput();
            List<string> fileNamesForReport = GetListOfFileNamesFromInput(fileNames);

            return fileNamesForReport;
        }

        private void ShowAvailableFilesForReport()
        {
            var fileReader = new FileReader();
            var allAvailableFileNames = fileReader.GetAllExcelFileNamesFromFolder();

            for (int i = 0; i < allAvailableFileNames.Count; i++)
            {
                PrintToConsole(allAvailableFileNames[i]);
            }
        }

        private void ShowMultipleFilesForReportOptions()
        {
            PrintToConsole("For getting report from several files - enter file names separated by comma" + Environment.NewLine +
                        "For getting report from all available files enter '.' character." + Environment.NewLine +
                        $"Here are availalbe files:");
        }

        private List<string> GetListOfFileNamesFromInput(string userInput)
        {
            List<string> fileNames = new List<string>();
            var fileReader = new FileReader();
            if (userInput == ".")
            {
                fileNames = fileReader.GetAllExcelFileNamesFromFolder();
            }
            else if (userInput.Contains(","))
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
    }
}
