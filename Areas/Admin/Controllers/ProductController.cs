using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThursdayMarket.DataAccess.Services.IServices;
using ThursdayMarket.Models;

using ThursdayMarket.Models.DTO;

namespace ThursdayMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService; 
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
     
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var products = await _productService.GetAllProducts();
            var categories = await _categoryService.GetAllCategories();
            IEnumerable<SelectListItem> CategoryList = categories.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM obj)
        {
            var productToCreate = new Product {
                CategoryId = obj.Product.CategoryId,
                Description = obj.Product.Description,
                DiscountPrice = obj.Product.DiscountPrice,
                Price = obj.Product.Price,
                IsDeleted = false,
                Quantity = obj.Product.Quantity,
                Weight = obj.Product.Weight,
                Name = obj.Product.Name,
                Image = obj.Product.Image,

          };  
          await _productService.AddProduct(productToCreate);
           
            return RedirectToAction("Index","Product");
        }

        public async Task<IActionResult> Delete(int id)
        {
           var productToDelete = await _productService.GetProductById(id);
            var productToDisplay = new ProductVM { Product =  productToDelete };
            return View(productToDisplay);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
             await _productService.DeleteProduct(id);
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductById(id);
            var categories = await _categoryService.GetAllCategories();
            IEnumerable<SelectListItem> CategoryList = categories.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;
            var productToDisplay = new ProductVM { Product = product };
            return View(productToDisplay);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductVM obj)
        {


            if(obj.Product.Id != null){
                var productToUpdate = await _productService.GetProductById(obj.Product.Id);
        

                productToUpdate.Description = obj.Product.Description;
                productToUpdate.DiscountPrice = obj.Product.DiscountPrice;
                productToUpdate.Price = obj.Product.Price;
                productToUpdate.IsDeleted = false;
                productToUpdate.Quantity = obj.Product.Quantity;
                productToUpdate.Weight = obj.Product.Weight;
                productToUpdate.Name = obj.Product.Name;
                productToUpdate.Image = obj.Product.Image;
                productToUpdate.CategoryId = obj.Product.CategoryId;

                await _productService.UpdateProduct(productToUpdate);
            }
          
            return RedirectToAction("Index", "Product");
        }
    
    }
}
