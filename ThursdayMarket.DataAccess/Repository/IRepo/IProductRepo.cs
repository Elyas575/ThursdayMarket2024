using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Repository.IRepo
{
    public interface IProductRepo
    {
       public Task<Product> AddProduct(Product product);
        public Task<ICollection<Product>> GetProductsByCategoryId(int numberOfProducts, int categoryId);
        public Task<Product> GetProductById(int id);

        public Task<ICollection<Product>> GetProductsByName(string name);

        public Task<ICollection<Product>> GetAllProducts();
        public Task<Product> DeleteProduct(int id);
        public Task<Product> UpdateProduct(Product product);

    }
}
