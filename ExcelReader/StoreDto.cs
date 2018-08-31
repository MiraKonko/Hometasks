using LinqToExcel.Attributes;

namespace ExcelReader
{
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
