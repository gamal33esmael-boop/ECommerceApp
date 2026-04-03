using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image {  get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        
        public List<OrderItem> OrderItems { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
