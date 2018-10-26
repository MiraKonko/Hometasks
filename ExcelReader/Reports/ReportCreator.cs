using ExcelReader.Abstractions;
using ExcelReaderModels.DTOs;

namespace ExcelReader.Reports
{
    public class ReportCreator
    {
        private IReportReaderFactory _reportFactory;
        public ReportCreator(IReportReaderFactory reportFactory)
        {
            _reportFactory = reportFactory;
        }

        public ReportDto GetReport()
        {
            var reportReader = _reportFactory.CreateReportReader();
            ReportDto report = reportReader.ReadReport();
            return report;
        }
    }
}
