using ECommerceApp.Models;

namespace ECommerceApp.ViewModel
{
    public class DashBoardVm
    {
        public int ToTalUsers { get; set; }
        public int ToTalCategories { get; set; }
        public decimal TotalSalesThisMonth { get; set; } = 20000;

        public List<ApplicationUser> RecentUsers { get; set; } = new List<ApplicationUser>();
    }
}
