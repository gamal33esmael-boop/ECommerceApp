using ECommerceApp.Interfaces;
using ECommerceApp.Models;
using ECommerceApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceApp.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class DashboardController : Controller
    {
        private readonly IProductRepository productMange;
        private readonly IGenericRepository<Category> categoryManger;

        public DashboardController(IProductRepository productMange,IGenericRepository<Category> categoryManger) 
        {
            this.productMange = productMange;
            this.categoryManger = categoryManger;
        }
        public IActionResult Index()
        {
            DashBoardVm dashBoard = new DashBoardVm()
            {
                ToTalCategories= categoryManger.GetAll().Count(),
                ToTalUsers= productMange.GetAll().Count(),
                
            };
            return View("Index" ,dashBoard);
        }
    }
}
