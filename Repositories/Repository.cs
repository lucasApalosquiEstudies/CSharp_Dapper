using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<T> GetAll()
            => _connection.GetAll<T>();

        public T GetById(int id)
            => _connection.Get<T>(id);

        public void Create(T model)
            => _connection.Insert(model);

        public void Update(T model)
            => _connection.Update(model);

        public void Delete(int id)
        {
            T model = GetById(id);
            _connection.Delete(model);
        }

    }
}
