using System;

namespace ExcelReader
{
    public class ConsolePrinter : IConsolePrinter
    {
        public void PrintToConsole(string stringToPrint)
        {
            Console.WriteLine(stringToPrint);
        }
    }
}
