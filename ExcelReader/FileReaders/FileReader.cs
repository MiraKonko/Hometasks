using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ExcelReader
{
    public class FileReader
    {
        public string defaultFolderName = ConfigurationSettings.AppSettings["defaultTestDataDirectory"];

        public string BuildFullPathToFile(string fileName, string fileDirectory = null)
        {
            var pathToFolder = BuildFullPathToFolder(fileDirectory);
            string pathToFile = pathToFolder + fileName;

            return pathToFile;
        }

        public string BuildFullPathToFolder(string folderName = null)
        {
            var directory = folderName ?? defaultFolderName;
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
                fileNames.Add(allFiles[i].Split(new string[] { defaultFolderName }, StringSplitOptions.None)[1]);
            }

            return fileNames;
        }

        public List<string> GetListOfFilesNamesFromUserInput(string userInput)
        {
            List<string> fileNames = new List<string>();

            if (userInput == ".")
            {
                fileNames = GetAllExcelFileNamesFromFolder();
            }
            else if (userInput.Contains(","))
            {
                fileNames = userInput.Split(',').ToList();
            }
            else
            {
                fileNames.Add(userInput);
            }

            return fileNames;
        }
    }
}
