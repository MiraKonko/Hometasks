using System.Text;

namespace ExcelReader
{
    public class AuthorDto
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}