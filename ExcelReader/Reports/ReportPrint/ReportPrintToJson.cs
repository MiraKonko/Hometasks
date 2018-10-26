using ExcelReader.FileExport;
using ExcelReaderModels.DTOs;
using Newtonsoft.Json;

namespace ExcelReader.ReportExport
{
    public class ReportPrintToJson : ReportPrintToFileTemplate
    {
        public override string AddExtention(string path)
        {
            return path + ".json";
        }

        public override void Save(ReportDto report, string path)
        {
            var jsonExport = JsonConvert.SerializeObject(report.ReportContent);
            System.IO.File.WriteAllText(path, jsonExport);
        }
    }
}
