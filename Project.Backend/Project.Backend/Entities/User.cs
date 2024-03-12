using Microsoft.AspNetCore.Identity;
namespace Project.Backend.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual List<Order>? Orders { get; set; }
        public virtual List<UserAddresses>? UserAddresses { get; set; }

    }
}
