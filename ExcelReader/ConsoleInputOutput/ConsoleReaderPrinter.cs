using ExcelReader.Properties;

using System;
using System.Collections.Generic;

namespace ExcelReader.ConsoleInputOutput
{
    public class ConsoleReaderPrinter : IConsoleReader, IConsolePrinter
    {
        public string GetUserInput()
        {
            var userInput = Console.ReadLine();
            return userInput;
        }

        public string GetUserInput(string userPrompt)
        {
            PrintToConsole(userPrompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        public void PrintToConsole(string output)
        {
            Console.WriteLine(output);
        }

        public void PrintToConsole(List<string> output)
        {
            for (int i = 0; i < output.Count; i++)
            {
                PrintToConsole(output[i]);
            }
        }

        public void ShowAvailableReportOptions()
        {
            PrintToConsole(Resources.AvailableReportsFilterInfo);
        }

        public void ShowMultipleFilesForReportOptions()
        {
            PrintToConsole(Resources.ShowMultipleFilesForReportOption);
        }
    }
}
