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

        public User GetById(int id)
            => _connection.Get<User>(id);

        public void Create(User user)
        {
            user.Id = 0;
            _connection.Insert(user);
        }

        public void Update(User user)
        {
            if (user.Id != 0)
            {
                _connection.Update(user);
            }
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            _connection.Delete(user);
        }



    }
}
