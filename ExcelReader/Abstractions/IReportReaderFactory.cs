using ExcelReader.Reports;

namespace ExcelReader.Abstractions
{
    public interface IReportReaderFactory
    {
        IReportReader CreateReportReader();
    }
}
