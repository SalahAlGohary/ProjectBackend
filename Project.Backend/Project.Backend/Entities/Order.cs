using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }
        public DateTime? OrderedAt { get; set; }
        public Guid UserId { get; set; }
        public Guid ResturantId { get; set; }
        public Guid AddressId { get; set; }
        public virtual User User { get; set; }
        public virtual Resturant Restuarant { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Item>? Items { get; set; }

    }
}
