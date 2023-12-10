using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services.IServices
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<ICollection<Product>> GetProductsByCategoryId(int numberOfProducts, int categoryId);
        Task<Product> GetProductById(int id);
        Task<ICollection<Product>> GetProductsByName(string name);
        Task<ICollection<Product>> GetAllProducts();
        Task<Product> DeleteProduct(int id);
        Task<Product> UpdateProduct(Product product);
    }
}
