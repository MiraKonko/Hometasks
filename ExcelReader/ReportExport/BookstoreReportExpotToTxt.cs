using ExcelReader.FileExport;
using System;
using System.Collections.Generic;

namespace ExcelReader.ReportExport
{
    public class BookstoreReportExpotToTxt : IReportExporter<string>
    {
        public void SaveBookReportToFile(List<string> booksToSave)
        {
            string fileName = "BookStoreReport.txt";
            string saveToFolder = "/ExportedReports/";

            string[] booksArrayToSave = new string[booksToSave.Count];
            for (int i = 0; i < booksToSave.Count; i++)
            {
                booksArrayToSave[i] = booksToSave[i];
            }

            var saveToPath = new FileReader().BuildFullPathToFile(fileName, saveToFolder);
            System.IO.File.WriteAllLines(saveToPath, booksArrayToSave);
            Console.WriteLine($"File saved as {fileName} in {saveToFolder} folder! Click any key to continue...");
        }
    }
}
