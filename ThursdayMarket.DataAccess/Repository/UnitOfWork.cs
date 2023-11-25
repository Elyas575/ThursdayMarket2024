using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.Repository.IRepository;

namespace ThursdayMarket.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }
 

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
