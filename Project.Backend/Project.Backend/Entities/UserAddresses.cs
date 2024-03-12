using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class UserAddresses : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
    }
}
