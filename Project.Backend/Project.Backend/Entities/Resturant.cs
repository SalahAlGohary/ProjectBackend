using Project.Backend.Entities.Common;
using Project.Backend.Enums;

namespace Project.Backend.Entities
{
    public class Resturant : BaseEntityName
    {
        public string? Description { get; set; }
        public string? CoverUrl { get; set; }
        public int Rate { get; set; }
        public decimal DeliveryCost { get; set; }
        public int DeliveryTime { get; set; }
        public Guid? AddressId { get; set; }
        public List<string>? Specialities { get; set; }
        public PaymentOption PaymentOption { get; set; } = PaymentOption.All;
        public decimal MinOrder { get; set; }
        public string? Category { get; set; }
        public virtual List<Order>? Orders { get; set; }
        public virtual Address? Address { get; set; }
        public virtual List<Cart>? Carts { get; set; }
        public virtual List<Dish>? Dishes { get; set; }
    }
}
