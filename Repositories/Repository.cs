using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DapperContext _context;
        public Repository(DapperContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            string sqlQuery = "SELECT * FROM " + entity.GetType().ToString() + "WHERE id = \"toto\"";
            return new TEntity();
            /*using (var connection = _context.CreateConnection())
            {
                connection
                var companies = await connection.QueryAsync<TEntity>(sqlQuery);
                return companies.ToList();
            }*/
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
