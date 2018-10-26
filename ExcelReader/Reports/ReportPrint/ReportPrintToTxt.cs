using ExcelReader.FileExport;
using ExcelReaderModels.DTOs;

namespace ExcelReader.ReportExport
{
    public class ReportPrintToTxt : ReportPrintToFileTemplate
    {
        public override string AddExtention(string path)
        {
            return path + ".txt";
        }

        public override void Save(ReportDto report, string path)
        {
            string[] booksArrayToSave = new string[report.ReportContent.Count];
            for (int i = 0; i < report.ReportContent.Count; i++)
            {
                booksArrayToSave[i] = report.ReportContent[i];
            }

            System.IO.File.WriteAllLines(path, booksArrayToSave);
        }
    }
}
