using OfficeOpenXml;
using System;
using System.IO;

namespace ExcelReader
{
    public class ExcelReader
    {
        public ExcelPackage GetExcelPackage(string fileName)
        {
            string pathToFile = new FileReader().BuildFullPathToFile(fileName);
            FileInfo file = new FileInfo(pathToFile);
            if (file == null)
            {
                throw new Exception($"There is no file with such name {file}!");
            }
            ExcelPackage package = new ExcelPackage(file);
            return package;
        }

    }
}
