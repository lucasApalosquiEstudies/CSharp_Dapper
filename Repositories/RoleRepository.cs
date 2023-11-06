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
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection conenction)
            => _connection = conenction;

        public IEnumerable<Role> GetAll()
            => _connection.GetAll<Role>();

        public Role GetById(int id)
            => _connection.Get<Role>(id);

        public void Create(Role role)
        {
            role.Id = 0;
            _connection.Insert(role);
        }

        public void Update(Role role)
        {
            if (role.Id != 0)
            {
                _connection.Update(role);
            }
        }

        public void Delete(int id)
        {
            Role role = GetById(id);
            _connection.Delete(role);
        }

    }
}
