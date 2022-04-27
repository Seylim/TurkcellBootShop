using bootShop.DataAccess.Data;
using bootShop.DataAccess.Repositories;
using bootShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootShop.Business
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<int> AddCategory(Category category)
        {
            return await categoryRepository.Add(category);
        }

        public async Task DeleteCategory(int id)
        {
            await categoryRepository.Delete(id);
        }

        public IList<Category> GetCategories()
        {
            return categoryRepository.GetAll(); 
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await categoryRepository.GetAllEntities();
        }

        public async Task<Category> GetEntityById(int id)
        {
            return await categoryRepository.GetEntityById(id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await categoryRepository.IsExists(id);
        }

        public async Task<int> UpdateCategory(Category category)
        {
            return await categoryRepository.Update(category);
        }
    }
}
