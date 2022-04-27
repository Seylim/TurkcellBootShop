using bootShop.DataAccess.Data;
using bootShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootShop.DataAccess.Repositories
{
    public class EfProductRepository : IProductRepository
    {

        private bootShopDbContext dbContext;
        public EfProductRepository(bootShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Add(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            product.IsActive = false;
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAllEntities()
        {
            return await dbContext.Products.Where(p => p.IsActive == true).ToListAsync();
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await dbContext.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<IList<Product>> SearchProductByName(string productName)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(productName)).ToListAsync();
        }

        public async Task<int> Update(Product entity)
        {
            entity.ModifiedDate = DateTime.Now; 
            dbContext.Products.Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
