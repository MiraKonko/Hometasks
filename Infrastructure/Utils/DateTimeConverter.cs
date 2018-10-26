using System;

namespace Infrastructure.Utils
{
    public static class DateTimeConverter
    {
        public static string ConvertDateTimeToLongString(DateTime date)
        {
            return date.ToString("yyyyMMddHHmmss");
        }
    }
}
