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
    public class EfCategoryRepository : ICategoryRepository
    {
        bootShopDbContext dbContext;

        public EfCategoryRepository(bootShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Add(Category entity)
        {
            await dbContext.Categories.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
        }

        public IList<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public async Task<IList<Category>> GetAllEntities()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetEntityById(int id)
        {
            return await dbContext.Categories.FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<int> Update(Category entity)
        {
            dbContext.Categories.Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
