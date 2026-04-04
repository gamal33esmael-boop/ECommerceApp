using ECommerceApp.DbCotext;
using ECommerceApp.Interfaces;
using ECommerceApp.Models;

namespace ECommerceApp.Repository
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public List<Product> SearchProduct(string name)
        {
          return  _context.Products.Where(p=>p.Name.Contains(name)).ToList();
        }
    }
}
