using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.ConsoleInputOutput
{
    public class UserInputGetter : IConsoleReader, IConsolePrinter
    {
        private FileReader _fileReader = new FileReader();

        public string GetUserInput()
        {
            var userInput = Console.ReadLine();
            return userInput;
        }

        public void PrintToConsole(string output)
        {
            Console.WriteLine(output);
        }

        public string GetBookGenre()
        {
            PrintToConsole("Enter genre...");
            string genre = GetUserInput();
            return genre;
        }

        public int GetReportCode()
        {
            ShowAvailableReportOptions();
            PrintToConsole("Enter report number:");
            int reportTypeCode;
            int.TryParse(GetUserInput(), out reportTypeCode);
            return reportTypeCode;
        }

        private void ShowAvailableReportOptions()
        {
            PrintToConsole($"For getting list of books by genre - enter {(int)BookStoreReportTypes.ByGenre}." + Environment.NewLine +
                                          $"For getting the most profitable author - enter {(int)BookStoreReportTypes.TheMostProfitableAuthor}." + Environment.NewLine +
                                          $"For getting list of available authors - enter {(int)BookStoreReportTypes.AvailableAuthors}." + Environment.NewLine +
                                          $"For getting not filtered list of books - enter {(int)BookStoreReportTypes.AllBooks}." + Environment.NewLine);
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
            List<string> allAvailableFileNames = _fileReader.GetAllExcelFileNamesFromFolder();

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

            if (isAllFilesRequested)
            {
                fileNames = _fileReader.GetAllExcelFileNamesFromFolder();
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

        public string AskForReportSaving()
        {
            PrintToConsole("If you like to save this report to txt file = click 's' button, if not click any other key...");
            var userInput = GetUserInput();
            return userInput;
        }
    }
}
