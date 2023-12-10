using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Repository.IRepo;

using ThursdayMarket.DataAccess.Services.IServices;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepository;
        public CategoryService(ICategoryRepo categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> AddCategory(Category category)
        {
             var categoryToAdd =  await _categoryRepository.AddCategory(category);
            return categoryToAdd;
        }

        public async Task<Category> DeleteCategory(int id)
        {
             var categoryToDelete =  await _categoryRepository.DeleteCategory(id);
            return categoryToDelete;
        }

        public async Task<ICollection<Category>> GetAllCategories()
        {
           var categories = await _categoryRepository.GetAllCategories();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
           var categoryById = await _categoryRepository.GetCategoryById(id);
            return categoryById;
        }

        public async Task<ICollection<Category>> GetCategoryByName(string name)
        {
            var categoryByName = await _categoryRepository.GetCategoryByName(name);
            return categoryByName;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
           var categoryToUpdate = await _categoryRepository.UpdateCategory(category);
            return categoryToUpdate;
        }
    }
}
