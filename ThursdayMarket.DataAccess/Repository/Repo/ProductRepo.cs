using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.Repository.IRepo;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Repository.Repo
{
   
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

 

        public async Task<ICollection<Product>> GetAllProducts()
        {
            var productsList = await _context.Products
                .Include(product => product.Category)
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            return productsList;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public Task<ICollection<Product>> GetProductsByCategoryId(int numberOfProducts, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;
            }
            throw new InvalidOperationException("Product not found");
        }
        public async Task<Product> AddProduct(Product product)
        {
            if(product != null){
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            return null;
        }


        public async Task<Product> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product != null && product.IsDeleted == false)
            {
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
                return product;
            }

            throw new InvalidOperationException("Product could not be removed");
        }


    }
}
