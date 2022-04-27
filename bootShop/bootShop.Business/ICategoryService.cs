using bootShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootShop.Business
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();
        Task<int> AddCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task DeleteCategory(int id);
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category> GetEntityById(int id);
        Task<bool> IsExist(int id);
    }
}
