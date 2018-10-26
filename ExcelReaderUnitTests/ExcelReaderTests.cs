using ExcelReader;
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
            // var reportSaver = new ReportExportToTxt();
            //var testData = new List<string> { "tes1", "test2" };

            //reportSaver.SaveReportToFile(testData);

            var fileReader = new FileReader();
            List<string> txtFilesInDirectory = fileReader.GetAllFileNamesFromFolder();

            Assert.IsNotEmpty(txtFilesInDirectory, "No txt file was found after report saving in the directory!");
        }
    }
}
