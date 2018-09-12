using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataSetAttribute : Attribute
    {

        public string ValueName { get; set; }

        public DataSetAttribute(string valueName)
        {
            ValueName = valueName;
        }
    }
}
