using System;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Collections.Generic;
using OfficeOpenXml;

namespace ExcelReader
{
    public class ExcelReader
    {
        //public DataSet GetDataSetFromExcelFile(string pathToFile)
        //{
        //    IExcelDataReader reader = GetExcelDataReader(pathToFile);
        //    DataSet docToOpen = reader.AsDataSet(
        //        new ExcelDataSetConfiguration
        //        {
        //            UseColumnDataType = true,

        //            ConfigureDataTable = (dataReader) => new ExcelDataTableConfiguration() { UseHeaderRow = true },
        //        });
        //    return docToOpen;
        //}

        //public IExcelDataReader GetExcelDataReader(string pathToFile)
        //{
        //    FileStream stream = File.Open(pathToFile, FileMode.Open);
        //    if (pathToFile.EndsWith(".xls"))
        //    {
        //        return ExcelReaderFactory.CreateBinaryReader(stream);
        //    }
        //    else
        //    {
        //        return ExcelReaderFactory.CreateOpenXmlReader(stream);
        //    }
        //    stream.Dispose();
        //}
        public ExcelPackage GetExcelPackage(string fileName)
        {
            string pathToFile = new FileReaderHelper().BuildFullPathToFile(fileName);
            FileInfo file = new FileInfo(pathToFile);
            if (file == null)
            {
                throw new Exception($"There is no file with such name {file}!");
            }
            //using (
            ExcelPackage package = new ExcelPackage(file);
            //{

            return package;
            //}
        }

    }
}
