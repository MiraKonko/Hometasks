using Infrastructure.Utils;
using System;
using System.Collections.Generic;


namespace ExcelReaderModels.DTOs
{
    public class ReportDto
    {
        private DateTime _creationDate;

        public ReportDto()
        {
            _creationDate = DateTime.Now;
        }

        public string Id
        {
            get
            {
                return Name + DateTimeConverter.ConvertDateTimeToLongString(CreationDate);
            }
        }
        public string Name { get; set; }
        public DateTime CreationDate { get { return _creationDate; } }
        public List<string> ReportContent { get; set; }
    }
}
