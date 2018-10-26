using ExcelReaderModels.DTOs;

namespace ExcelReader.Reports
{
    public interface IReportReader
    {
        ReportDto ReadReport();
    }
}
