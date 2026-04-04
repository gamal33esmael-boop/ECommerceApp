using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
