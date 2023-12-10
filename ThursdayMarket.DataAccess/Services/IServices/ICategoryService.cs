using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services.IServices
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int id);
        Task<ICollection<Category>> GetAllCategories();
        Task<ICollection<Category>> GetCategoryByName(string name);
        Task<Category> AddCategory(Category category);
        Task<Category> DeleteCategory(int id);
        Task<Category> UpdateCategory(Category category);
    }
}
