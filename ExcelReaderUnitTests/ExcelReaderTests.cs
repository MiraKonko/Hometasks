using ExcelReader;
using ExcelReader.ReportExport;
using ExcelReaderModels.DTOs;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExcelReaderUnitTests
{
    [TestFixture]
    public class ExcelReaderTest
    {
        [Test]
        public void VerifyThatTxtFileIsPresentInDirectoryAfterSaving()
        {
            var reportSaver = new ReportPrintToTxt();
            var testData = new ReportDto { Name = "TxtTestReport", ReportContent = new List<string> { "test1, test2" } };

            reportSaver.PrintReport(testData);

            var fileReader = new FileReader();
            List<string> txtFilesInDirectory = fileReader.GetAllFileNamesFromFolder();

            Assert.IsNotEmpty(txtFilesInDirectory, "No txt file was found after report saving in the directory!");
        }
    }
}
