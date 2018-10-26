using ExcelReader.Abstractions;
using ExcelReaderModels.DTOs;
using System;

namespace ExcelReader.Reports
{
    public class ConsoleReportPrinter : IReportPrinter
    {
        public void PrintReport(ReportDto report)
        {
            var reportContent = report.ReportContent;
            for (int i = 0; i < reportContent.Count; i++)
            {
                Console.WriteLine(reportContent[i]);
            }
        }
    }
}
