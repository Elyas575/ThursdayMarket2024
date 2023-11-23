using Microsoft.AspNetCore.Mvc;
using ThursdayMarket.Data;
using ThursdayMarket.DTO;
using ThursdayMarket.Models;

namespace ThursdayMarket.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController( AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {
            List<Category> categories = _context.Categories.Where(c => !c.isDeleted).ToList();
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
                isDeleted = false
            };
            if(ModelState.IsValid)
            {
              await  _context.Categories.AddAsync(categoryToCreate);
              await  _context.SaveChangesAsync();
                return RedirectToAction("Index", "Category");
            }

            return View();
          
        }

        public IActionResult Delete()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var categoryToDelete = _context.Categories.Where(category => category.Id == id).FirstOrDefault();
            if(categoryToDelete != null)
            {
                categoryToDelete.isDeleted = true;
            }
             _context.Update(categoryToDelete);
              await  _context.SaveChangesAsync();
            return View(categoryToDelete);
        }
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Edit(Category category)
        {
            var categoryToEdit = _context.Categories.Find(category.Id);
            categoryToEdit.Name = category.Name;
            categoryToEdit.DisplayOrder = category.DisplayOrder;

            _context.Categories.Update(categoryToEdit);
             await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Category");

        }

    }
}
