using System.Collections.Generic;

namespace ExcelReader.Reports
{
    public interface IReportStrategy
    {
        List<string> GetReport();
    }
}
