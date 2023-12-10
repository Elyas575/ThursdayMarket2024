using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Repository.IRepo
{
    public interface ICategoryRepo
    {
        public Task<Category> GetCategoryById(int id);
        public Task<ICollection<Category>> GetAllCategories();
        public Task<ICollection<Category>> GetCategoryByName(string name);
        public Task<Category> AddCategory(Category category);
        public Task<Category> DeleteCategory(int id);
        public Task<Category> UpdateCategory(Category category);   
    }
}
