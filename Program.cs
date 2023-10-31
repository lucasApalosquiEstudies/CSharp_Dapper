using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;



const string connectionString = "Server=DESKTOP-BVKU5HC;Database=balta;Trusted_Connection=True;TrustServerCertificate=True";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    using (var command = new SqlCommand())
    {
        var categories = connection.Query<Category>("SELECT [ID], [Title] FROM [Category]");
        foreach (var category in categories)
        {
            Console.WriteLine(category.Id + ", " + category.Title);
        }
    }
}



