using System;
using System.Data.SqlClient;

namespace ExcelReader.EntityMappers
{
    public class EntityMapper
    {
        public BookDto MapSqlDataToBookDto(SqlDataReader sqlReader)
        {
            return new BookDto
            {
                Id = (int)sqlReader["Id"],
                Author = sqlReader["Author"].ToString(),
                Title = sqlReader["Title"].ToString(),
                Price = (int)sqlReader["Price"],
                IsAvailalbe = (bool)sqlReader["IsAvailable"],
                Genre = sqlReader["Genre"].ToString(),
                AvailableBooksCount = (int)sqlReader["AvailableBooksCount"],
                SoldBooksCount = (int)sqlReader["SoldBooksCount"]
            };
        }
    }
}
