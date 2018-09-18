using System.Text;

namespace ExcelReader
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public bool IsAvailalbe { get; set; }

        public string Genre { get; set; }

        public int AvailableBooksCount { get; set; }

        public int SoldBooksCount { get; set; }

        public int TotalSoldPrice
        {
            get { return SoldBooksCount * Price; }
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id: {Id.ToString()},")
                      .Append($"Author: {Author.ToString()},")
                      .Append($"Title: {Title.ToString()},")
                      .Append($"Price: {Price.ToString()},")
                      .Append($"Available: {IsAvailalbe.ToString()},")
                      .Append($"Genre: {Genre.ToString()},")
                      .Append($"Available Books Count: {AvailableBooksCount.ToString()},")
                      .Append($"Sold Books Count: {SoldBooksCount.ToString()},")
                      .Append($"Total Sold Price: {TotalSoldPrice.ToString()}.");
            return strBuilder.ToString();
        }
    }
}
