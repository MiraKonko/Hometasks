using ExcelReaderModels.DTOs;

namespace ExcelReader.Abstractions
{
    public interface IReportPrinter
    {
        void PrintReport(ReportDto report);
    }
}
