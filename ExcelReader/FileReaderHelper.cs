using System.IO;

namespace ExcelReader
{
    public static class FileReaderHelper
    {
        public static string defaultDirectory = @"C:\Users\Myroslava_Konko\Source\Mentoring\Hometasks\ExcelReader\Reports\";

        public static string[] GetAllExcelFilesFromDirectory(string fileDirectory)
        {
            string[] allFiles = Directory.GetFiles(fileDirectory, "*.xlsx");
            return allFiles;
        }

        public static bool IsFileWithNamePresentInTheDirectory(string fileName, string fileDirectory = null)
        {
            var directory = fileDirectory == null ? defaultDirectory : fileDirectory;
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

        public static string BuildPathToFile(string fileName, string fileDirectory = null)
        {
            var directory = fileDirectory == null ? defaultDirectory : fileDirectory;
            string pathToFile = directory + fileName;
            return pathToFile;
        }

    }
}
