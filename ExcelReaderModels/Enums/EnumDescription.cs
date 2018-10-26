using System;

namespace ExcelReaderModels.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDescription : Attribute
    {

        public string ValueName;

        public EnumDescription(string valueName)
        {
            ValueName = valueName;
        }
    }
}
