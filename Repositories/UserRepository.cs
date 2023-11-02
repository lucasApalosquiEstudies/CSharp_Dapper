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
        private readonly SqlConnection _connection;
        
        public UserRepository(SqlConnection connection)
            => _connection = connection;
        

        public IEnumerable<User> GetAll()
            => _connection.GetAll<User>();

    }
}
