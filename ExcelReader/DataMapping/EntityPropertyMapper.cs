using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace ExcelReader
{
    public class EntityPropertyMapper
    {
        public void MapRowDataToEntityByPropertyName(Type type, DataRow row, PropertyInfo prop, object entity)
        {
            string columnName = GetColumnNameByPropertyName(type, prop.Name);

            if (!String.IsNullOrEmpty(columnName) && row.Table.Columns.Contains(columnName))
            {
                var propertyValueFromDataset = row[columnName];
                if (propertyValueFromDataset != null)
                {
                    MapValueFromDatasetToProperty(prop, entity, propertyValueFromDataset);
                }
            }
        }

        public string GetColumnNameByPropertyName(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType().Name == "DataSetAttribute").FirstOrDefault();
            if (property != null)
            {
                return ((DataSetAttribute)property).ValueName;
            }
            return string.Empty;
        }

        private void MapValueFromDatasetToProperty(PropertyInfo prop, object entity, object value)
        {
            if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(entity, value.ToString().Trim());
            }
            else if (prop.PropertyType == typeof(bool))
            {
                prop.SetValue(entity, ParseBoolean(value.ToString()));
            }
            else if (prop.PropertyType == typeof(int))
            {
                prop.SetValue(entity, int.Parse(value.ToString()), null);
            }
            else if (prop.PropertyType == typeof(decimal))
            {
                prop.SetValue(entity, decimal.Parse(value.ToString()), null);
            }
            else if (prop.PropertyType == typeof(double))
            {
                prop.SetValue(entity, double.Parse(value.ToString()), null);
            }
        }

        public bool ParseBoolean(object value)
        {
            switch (value.ToString().ToLowerInvariant())
            {
                case "1":
                case "y":
                case "yes":
                case "true":
                    return true;

                case "0":
                case "n":
                case "no":
                case "false":
                default:
                    return false;
            }
        }
    }

}