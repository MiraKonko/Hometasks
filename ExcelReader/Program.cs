using LinqToExcel;
using LinqToExcel.Attributes;
using System;
using System.IO;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //string file name = "TestData.xlsx"
            //@"C:\Users\Myroslava_Konko\Source\Mentoring\Practika-1\ExcelReader\Reports"
            Console.WriteLine("Please, enter file name to print (just file name without .xlsx). If you want to print multiple files, input files names separated by comma.");
            string fileName = Console.ReadLine();
            string pathToFile = BuildPathToFile(fileName);
            string sheetName = "Sheet1";
            PrintExcelReportToConsole(pathToFile, sheetName);
            Console.ReadLine();

        }
        /*todo
         * MUST:
         * github
         * interactive input
         * configs
         * 2classes in 1 file!
         * 
         * Constraints:
         * - DI
         * - 1 Unit test per file
         * - Endless running program
         * 
         * At least 1 per meeting:
         * 0. Endless running program
         * 1. 3 reports
         * 2. all files from folder
         * --- ideally up to here
         * 3. input = folder
         * 4. Filters (with prompt) Report for 'Available books'
         * 5. Save to file
         * 6. Save to different formats (JSON/txt/csv)
         * 7. Different view (console?) [sorting, add/remove columns]
         * 8. Big files (1k records)
         * */
        public static void PrintExcelReportToConsole(string pathToFile, string sheetName)
        {
            var doc = new ExcelQueryFactory(pathToFile);
            var sheet = doc.Worksheet<Row>();
            foreach (var row in sheet)
            {
                foreach (var column in doc.GetColumnNames(sheetName))
                {
                    Console.Write($"| {row[column]} ");
                }
                Console.WriteLine();
            }
        }

        public static void GetReportWithFilter(string pathToFile, string sheetName, string columnName, string filterToApply)
        {
            var doc = new ExcelQueryFactory(pathToFile);
            //var sheet = doc.Worksheet<Row>().Where()k;
            //foreach (var row in sheet)
            //{
            //    foreach (var column in doc.GetColumnNames(sheetName))
            //    {
            //        Console.Write($"| {row[column]} ");
            //    }
            //    Console.WriteLine();
            //}
        }

        public static string BuildPathToFile(string fileName)
        {
            string dirPath = @"C:\Users\Myroslava_Konko\Source\Mentoring\";
            string pathToFile = dirPath + fileName;
            return pathToFile;
        }

       
    }

    public class Store
    {
        [ExcelColumn("ID")]
        public int Id { get; set; }

        [ExcelColumn("Author")]
        public string Author { get; set; }

        [ExcelColumn("Title")]
        public string Title { get; set; }

        [ExcelColumn("Price")]
        public int Price { get; set; }

        [ExcelColumn("Availalbe")]
        public bool IsAvailalbe { get; set; }

    }
}
