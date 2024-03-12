using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Cart : BaseEntity
    {
        public decimal TotalAmount { get; set; } = 0;
        public Guid RestuarantId { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual Resturant? Restuarant { get; set; }
        public virtual List<Item>? Items { get; set; }


    }
}
