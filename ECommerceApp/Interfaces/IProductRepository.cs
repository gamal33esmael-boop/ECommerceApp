using ECommerceApp.Models;
using ECommerceApp.Repository;

namespace ECommerceApp.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        List<Product> SearchProduct(string name);
    }
}
