using ECommerceApp.DbCotext;
using ECommerceApp.Interfaces;
using ECommerceApp.Models;

namespace ECommerceApp.Repository
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
       
         
    }
}
