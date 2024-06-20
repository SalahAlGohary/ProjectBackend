using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class OAuthTokenUser : BaseEntity
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }

    }
}
