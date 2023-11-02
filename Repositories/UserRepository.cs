using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class UserRepository
    {
        private SqlConnection _connection = new SqlConnection("Server=DESKTOP-BVKU5HC;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True");

        public IEnumerable<User> GetAll()
            => _connection.GetAll<User>();


    }
}
