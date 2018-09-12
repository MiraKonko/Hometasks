using System.IO;
using System.Configuration;
using System;

namespace ExcelReader
{
    public class FileReaderHelper
    {
        public string defaultFolderName = ConfigurationSettings.AppSettings["defaultTestDataDirectory"];

        public string BuildFullPathToFile(string fileName, string fileDirectory = null)
        {
            var pathToFolder = BuildFullPathToFolder(fileDirectory);
            string pathToFile = pathToFolder + fileName;
            return pathToFile;
        }

        public string BuildFullPathToFolder(string folderDirectory = null)
        {
            var directory = folderDirectory ?? defaultFolderName;
            string pathToFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + directory;
            return pathToFolder;
        }
    }
}
