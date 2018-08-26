using System.IO;

namespace ExcelReader
{
    public class FileReaderHelper
    {
        public static string[] GetAllExcelFilesFromDirectory(string fileDirectory)
        {
            string[] allFiles = Directory.GetFiles(fileDirectory, "*.xlsx");
            return allFiles;
        }

        public static bool IsFileWithNamePresentInTheDirectory(string fileName, string directory)
        {
            string[] presentFilesName = GetAllExcelFilesFromDirectory(directory);
            bool isFileWithNamePresent = false;
            for (int i = 0; i < presentFilesName.Length; i++)
            {
                if (presentFilesName[i].Contains(fileName))
                {
                    isFileWithNamePresent = true;
                    break;
                }
            }
            return isFileWithNamePresent;
        }
    }
}
