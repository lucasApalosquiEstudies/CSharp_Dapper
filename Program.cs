
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=DESKTOP-BVKU5HC;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True";

ReadUsers();

static void ReadUsers()
{
    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        var users = connection.GetAll<User>();
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }
}
