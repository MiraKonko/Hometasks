using ExcelReader.Abstractions;
using ExcelReaderModels.DTOs;
using System;

namespace ExcelReader.FileExport
{
    public abstract class ReportPrintToFileTemplate : IReportPrinter
    {
        public void PrintReport(ReportDto report)
        {
            var fileName = report.Id;
            string saveToFolder = "/ExportedReports/";
            var saveToPath = new FileReader().BuildFullPathToFile(fileName, saveToFolder);
            var fullPath = AddExtention(saveToPath);
            Save(report, fullPath);

            Console.WriteLine($"File saved as '{fileName}' in '{saveToFolder}' folder! Click any key to continue...");
        }
        public abstract string AddExtention(string path);
        public abstract void Save(ReportDto report, string path);
    }
}
