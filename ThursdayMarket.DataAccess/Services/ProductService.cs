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
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepository;
        public ProductService( IProductRepo productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> AddProduct(Product product)
        {
          var productToAdd = await _productRepository.AddProduct(product);
            return productToAdd;
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            var productsList = await _productRepository.GetAllProducts();
            return productsList;
        }

        public async Task<Product> GetProductById(int id)
        {
            var productById = await _productRepository.GetProductById(id);
            return productById;
        }

        public Task<ICollection<Product>> GetProductsByCategoryId(int numberOfProducts, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var productToDelete = await _productRepository.DeleteProduct(id);
            return productToDelete;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var productToUpdate = await _productRepository.UpdateProduct(product);
            return productToUpdate;
        }
    }
}
