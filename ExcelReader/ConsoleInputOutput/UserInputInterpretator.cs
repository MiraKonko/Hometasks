using ExcelReader.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.ConsoleInputOutput
{
    public class UserInputInterpretator
    {
        private FileReader _fileReader;
        private ConsoleReaderPrinter _consoleReader;

        public UserInputInterpretator(FileReader fileReader, ConsoleReaderPrinter consoleReader)
        {
            _fileReader = fileReader;
            _consoleReader = consoleReader;
        }
        public string GetBookGenre()
        {
            string genre = _consoleReader.GetUserInput(Resources.AskForGenre);
            return genre;
        }

        public int GetReportCode()
        {
            _consoleReader.ShowAvailableReportOptions();
            int reportTypeCode;
            int.TryParse(_consoleReader.GetUserInput(Resources.AskForReportNumber), out reportTypeCode);
            return reportTypeCode;
        }

        public List<string> GetFileNamesForReport()
        {
            _consoleReader.PrintToConsole(Resources.AskForFileNames + Environment.NewLine);
            _consoleReader.ShowMultipleFilesForReportOptions();
            List<string> allAvailableFileNames = _fileReader.GetAllFileNamesFromFolder();
            _consoleReader.PrintToConsole(allAvailableFileNames);

            string fileNames = _consoleReader.GetUserInput();
            List<string> fileNamesForReport = GetListOfFileNamesFromInput(fileNames);

            return fileNamesForReport;
        }

        private List<string> GetListOfFileNamesFromInput(string userInput)
        {
            var isAllFilesRequested = userInput == ".";

            List<string> fileNames = new List<string>();

            if (isAllFilesRequested)
            {
                fileNames = _fileReader.GetAllFileNamesFromFolder();
            }
            else
            {
                fileNames = GetListOfValuesFromUserInput(userInput);
            }

            return fileNames;
        }

        public bool IsReportSavingRequired()
        {
            var userInput = _consoleReader.GetUserInput(Resources.AskIfSavingIsRequired);
            bool isSavingRequired = false;

            if (userInput.ToLower() == "s")
            {
                isSavingRequired = true;
            }

            return isSavingRequired;
        }

        public string GetPrintToOption()
        {
            var printOption = _consoleReader.GetUserInput(Resources.AskForPrintingOption);
            return printOption;
        }

        public string GetExportToFileOption()
        {
            var exportOption = _consoleReader.GetUserInput(Resources.AskForSavingFormat);
            return exportOption;
        }

        public List<string> GetColumnsForReport()
        {
            var enteredColumns = _consoleReader.GetUserInput(Resources.AskForSpecificColumns);
            List<string> columnsForReport = GetListOfValuesFromUserInput(enteredColumns);
            return columnsForReport;
        }

        private List<string> GetListOfValuesFromUserInput(string input)
        {
            List<string> values = new List<string>();
            if (input != "")
            {
                var isMultipleValuesEntered = input.Contains(",");
                if (isMultipleValuesEntered)
                {
                    values = input.Split(',').ToList();
                }
                else
                {
                    values.Add(input);
                }
            }
            return values;
        }

        public Dictionary<string, string> GetSortingOption()
        {
            var userInput = _consoleReader.GetUserInput(Resources.AskForSortingOption);
            var column = userInput.Split(',')[0];
            var sorting = userInput.Split(',')[1];
            Dictionary<string, string> sortingOptions = new Dictionary<string, string>();
            sortingOptions.Add(column, sorting);

            return sortingOptions;
        }
    }
}
