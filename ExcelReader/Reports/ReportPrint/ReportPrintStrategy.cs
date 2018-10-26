using ExcelReader.Abstractions;
using ExcelReader.ReportExport;
using ExcelReaderModels.DTOs;
using System;

namespace ExcelReader.Reports.ReportSaving
{
    public class ReportPrintStrategy
    {
        private IReportPrinter _reportPrinter;

        private void SetStrategy(IReportPrinter reportPrinter)
        {
            _reportPrinter = reportPrinter;
        }

        public void PrintReport(string reportType, ReportDto report)
        {
            if (reportType.ToLower() == "j")
            {
                SetStrategy(new ReportPrintToJson());
            }
            else if (reportType.ToLower() == "t")
            {
                SetStrategy(new ReportPrintToTxt());
            }
            else if (reportType.ToLower() == "c")
            {
                SetStrategy(new ConsoleReportPrinter());
            }
            else
            {
                throw new Exception("There is no such export option!");
            }
            _reportPrinter.PrintReport(report);
        }
    }
}
