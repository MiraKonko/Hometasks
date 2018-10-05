using ExcelReader.ReportExport;
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
            var reportSaver = new BookstoreReportExpotToTxt();
            var testData = new List<string> { "tes1", "test2" };

            reportSaver.SaveBookReportToFile(testData);

            List<string> txtFilesInDirectory = new List<string>();

            Assert.IsNotEmpty(txtFilesInDirectory, "No txt file was found after report saving in the directory!");
        }
    }
}
