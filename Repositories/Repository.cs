using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DapperContext _context;
        private Type type = typeof(TEntity);
        public Repository(DapperContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            var properties = type.GetProperties();
            string idName = "";
            string idValue = "";
            //foreach (var property in properties)
            //{
            //    var customAttributes = property.GetCustomAttributes(false).ToList();
            //    if ( customAttributes.Count > 0 )
            //    {
            //        foreach (var attribute in customAttributes)
            //        {
            //            if(attribute.GetType() == typeof(IdAttribute))
            //            {
            //                idName = property.Name;
            //                idValue = (string)entity.GetType().GetProperty(idName).GetValue(entity);
            //                break;
            //            }
            //        }
            //    }
            //}
            string sqlQuery = $"SELECT * FROM { type.Name } WHERE { idName } = { idValue }";

            var sqlConnection = _context.CreateConnection();
            var resourceGroup = sqlConnection.Query<ResourceGroup>(sqlQuery).FirstOrDefault();
            
            Console.WriteLine(sqlQuery);


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
