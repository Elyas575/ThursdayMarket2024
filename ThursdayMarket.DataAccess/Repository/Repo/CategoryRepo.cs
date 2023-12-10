using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.Models;
using Microsoft.EntityFrameworkCore;
using ThursdayMarket.DataAccess.Repository.IRepo;
namespace ThursdayMarket.DataAccess.Repository.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddCategory(Category category)
        {
          await _context.Categories.AddAsync(category);
          await _context.SaveChangesAsync();
          return category;
          
        }

        public async Task<Category> DeleteCategory(int id)
        {
          var categoryToDelete = await _context.Categories.FindAsync(id);
            if(categoryToDelete != null)
            {
                if(categoryToDelete.IsDeleted == false)
                {
                    categoryToDelete.IsDeleted = true;
                    await _context.SaveChangesAsync();
                    return categoryToDelete;
                } else
                {
                    return categoryToDelete;
                }
            } 
            throw new InvalidOperationException("Category not found");
        }

        public async Task<ICollection<Category>> GetAllCategories()
        {
            var categories = await _context.Categories.Where(category => category.IsDeleted == false).ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var categoryToFind = await _context.Categories.FindAsync(id);
            if(categoryToFind != null)
            {
                return categoryToFind;
            }
            throw new InvalidOperationException("Category not found");
        }

        public async Task<ICollection<Category>> GetCategoryByName(string name = "")
        {
            if(name == "")
            {
                var allCategories = await _context.Categories.ToListAsync();
                return allCategories;
            }
            else
            {
             var categoryList = await _context.Categories
                .Where(category => category.Name.Contains(name))
                .ToListAsync();
                return categoryList;
            }
            throw new InvalidOperationException("Category not found");

        }

        public async Task<Category> UpdateCategory(Category category)
        {
            if (category != null)
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return category;
            }
          
                throw new InvalidOperationException("Category not found");
          
        }

    }
}
