using bootShop.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootShop.DataAccess.Repositories
{
    public class DapperCategoryRepository : ICategoryRepository
    {
        public IDbConnection dbConnection;
        public IConfiguration configuration;

        public DapperCategoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            dbConnection = new SqlConnection(configuration.GetConnectionString("db"));
        }

        public async Task<int> Add(Category entity)
        {
            string sql = "INSERT INTO Categories (Name) VALUES(@Name)";
            await dbConnection.ExecuteAsync(sql, entity);
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM Ctegories WHERE Id = " + id;
            await dbConnection.ExecuteAsync(sql);
        }

        public IList<Category> GetAll()
        {
            IList<Category> categories = new List<Category>();
            foreach (Category item in SqlMapper.Query<Category>(dbConnection, "SELECT * FROM Categories"))
            {
                categories.Add(item);
            }
            return categories;
        }

        public async Task<IList<Category>> GetAllEntities()
        {
            IList<Category> categories = new List<Category>();
            foreach (Category item in await SqlMapper.QueryAsync<Category>(dbConnection, "SELECT * FROM Categories"))
            {
                categories.Add(item);
            }
            return categories;
        }

        public async Task<Category> GetEntityById(int id)
        {
            string sql = "SELECT * FROM Products WHERE Id = " + id;
            var category = await dbConnection.QueryFirstOrDefaultAsync<Category>(sql);
            return category;
        }

        public async Task<bool> IsExists(int id)
        {
            string sql = "SELECT * FROM Products WHERE Id = " + id;
            return await dbConnection.QueryFirstOrDefaultAsync<bool>(sql);
        }

        public async Task<int> Update(Category entity)
        {
            string sql = "UPDATE Categories SET Name = @Name WHERE Id = " + entity.Id;
            return await dbConnection.ExecuteAsync(sql, entity);
        }
    }
}
