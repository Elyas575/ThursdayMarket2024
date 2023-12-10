using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

using ThursdayMarket.DataAccess.DTO;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.Models;

using ThursdayMarket.DataAccess.Services.IServices;

namespace ThursdayMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO category)
        {

            var categoryToCreate = new Category
            {
                Name = category.Name,
                DisplayOrder = category.DisplayOrder,
                IsDeleted = false
            };
            if (ModelState.IsValid)
            {
               await _categoryService.AddCategory(categoryToCreate);
                return RedirectToAction("Index", "Category");
            }

            return View();

        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoryInfo = await _categoryService.GetCategoryById(id);

            return View(categoryInfo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {

            var categoryToDelete = await _categoryService.GetCategoryById(id);
            if (categoryToDelete != null)
            {
                categoryToDelete.IsDeleted = true;
                await _categoryService.UpdateCategory(categoryToDelete);
            }
           
            return RedirectToAction("Index", "Category");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var categoryToEdit = await _categoryService.GetCategoryById(id);
            return View(categoryToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if(category != null)
            {
                var categoryToEdit = await _categoryService.GetCategoryById(category.Id);
                categoryToEdit.Name = category.Name;
                categoryToEdit.DisplayOrder = category.DisplayOrder;

                _categoryService.UpdateCategory(categoryToEdit);
            }
  

            return RedirectToAction("Index", "Category");

        }

    }
}
