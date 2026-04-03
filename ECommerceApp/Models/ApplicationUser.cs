using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
        public ICollection<Order> Orders { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
