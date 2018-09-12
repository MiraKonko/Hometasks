using System;
using System.Collections.Generic;
using System.Data;
using ExcelDataReader;

namespace ExcelReader
{
    public class ConsolePrinter
    {
        public void PrintReportStringToConsole(string report)
        {
            Console.WriteLine(report);
        }

        public void PrintListToConsole(List<string> listToPrint)
        {
            foreach (var item in listToPrint)
            {
                Console.WriteLine(item);
            }
        }
    }
}
