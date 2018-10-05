using System;
using System.Collections.Generic;
using System.IO;

namespace ExcelReader
{
    public class FileReader
    {
        public const string defaultNameOfFolderWithData = "/TestData/";

        public string BuildFullPathToFile(string fileName, string fileDirectory = null)
        {
            var pathToFolder = BuildFullPathToFolder(fileDirectory);
            string pathToFile = pathToFolder + fileName;

            return pathToFile;
        }

        public string BuildFullPathToFolder(string folderName = null)
        {
            var directory = folderName ?? defaultNameOfFolderWithData;
            string pathToFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + directory;

            return pathToFolder;
        }

        public List<string> GetAllExcelFileNamesFromFolder(string folderName = null)
        {
            var pathToFolder = BuildFullPathToFolder(folderName);
            string[] allFiles = Directory.GetFiles(pathToFolder, "*.xlsx");
            List<string> fileNames = new List<string>();

            for (int i = 0; i < allFiles.Length; i++)
            {
                fileNames.Add(allFiles[i].Split(new string[] { defaultNameOfFolderWithData }, StringSplitOptions.None)[1]);
            }

            return fileNames;
        }
    }
}
