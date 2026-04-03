using ECommerceApp.Enums;

namespace ECommerceApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
        public decimal Total { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;

        // Foreign Key
        public int UserId { get; set; }
        

        // Relationships
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    
}
