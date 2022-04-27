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
    public class DapperProductRepository : IProductRepository
    {
        public IDbConnection dbConnection;
        public IConfiguration configuration;

        public DapperProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            //string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bootShopDb;Integrated Security=True";
            dbConnection = new SqlConnection(configuration.GetConnectionString("db"));
        }

        public async Task<int> Add(Product entity)
        {
            string sql = "INSERT INTO Products (Name, Price, Discount, Description, CategoryId, CreatedDate, ModifiedDate, ImageUrl, IsActive) VALUES(@Name, @Price, @Discount, @Description, @CategoryId, @CreatedDate, @ModifiedDate, @ImageUrl, @IsActive)";
            await dbConnection.ExecuteAsync(sql, entity);
            //await dbConnection.InsertAsync(entity);
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            string sql = "UPDATE Products SET IsActive = 0 WHERE Id = " + id;
            await dbConnection.ExecuteAsync(sql);
        }

        public async Task<IList<Product>> GetAllEntities()
        {
            IList<Product> products = new List<Product>();
            foreach (Product item in await SqlMapper.QueryAsync<Product>(dbConnection, "SELECT * FROM Products WHERE IsActive = 1"))
            {
                products.Add(item);
            }
            return products;
        }

        public async Task<Product> GetEntityById(int id)
        {
            string sql = "SELECT * FROM Products WHERE Id = " + id;
            var product = await dbConnection.QueryFirstOrDefaultAsync<Product>(sql);
            return product;
        }

        public async Task<bool> IsExists(int id)
        {
            string sql = "SELECT * FROM Products WHERE Id = " + id;
            return await dbConnection.QueryFirstOrDefaultAsync<bool>(sql);
        }

        public async Task<IList<Product>> SearchProductByName(string productName)
        {
            IList<Product> products = new List<Product>();
            foreach (Product item in await SqlMapper.QueryAsync<Product>(dbConnection, "SELECT * FROM Products WHERE Name = " + productName))
            {
                products.Add(item);
            }
            return products;
        }

        public async Task<int> Update(Product entity)
        {
            string sql = "UPDATE Products SET Name = @Name, Price = @Price, Discount = @Discount, Description = @Description, CategoryId = @CategoryId, CreatedDate = @CreatedDate, ModifiedDate = @ModifiedDate, ImageUrl = @ImageUrl, IsActive = @IsActive WHERE Id = " + entity.Id;
            return await dbConnection.ExecuteAsync(sql, entity);
        }
    }
}
