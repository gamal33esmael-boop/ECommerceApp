using ECommerceApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var Products = this.productRepository.GetAll();

            return View("Index",Products);
        }
        public IActionResult Search(string name) {

            var products = productRepository.SearchProduct(name);
            return View("Index",products);
        }

        
    }
}
