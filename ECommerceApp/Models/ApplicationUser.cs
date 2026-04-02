using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
    }
}