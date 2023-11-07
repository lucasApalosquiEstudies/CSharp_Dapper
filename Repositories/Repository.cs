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

        public IEnumerable<T> GetAll()
            => Database.connection.GetAll<T>();

        public T GetById(int id)
            => Database.connection.Get<T>(id);

        public void Create(T model)
            => Database.connection.Insert(model);

        public void Update(T model)
            => Database.connection.Update(model);

        public void Delete(int id)
        {
            T model = GetById(id);
            Database.connection.Delete(model);
        }

    }
}
