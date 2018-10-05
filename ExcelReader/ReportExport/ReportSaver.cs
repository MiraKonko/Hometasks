using ExcelReader.ConsoleInputOutput;
using ExcelReader.FileExport;
using System.Collections.Generic;

namespace ExcelReader.ReportExport
{
    public class ReportSaver
    {
        private UserInputGetter _userInputGetter = new UserInputGetter();
        private IReportExporter<string> _reportExporter;

        public ReportSaver(IReportExporter<string> reportExporter)
        {
            _reportExporter = reportExporter;
        }

        public void SaveReportToFile(List<string> report)
        {
            if (IsSavingRequsted())
            {
                _reportExporter.SaveBookReportToFile(report);
            }
        }

        private bool IsSavingRequsted()
        {
            bool isSavingRequested = false;
            var userInput = _userInputGetter.AskForReportSaving();
            if (userInput.ToLower() == "s")
            {
                isSavingRequested = true;
            }
            return isSavingRequested;
        }

    }
}
