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
        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(""))
            {
                return connection.GetAll<User>();
                
            }
        }
    }
}
