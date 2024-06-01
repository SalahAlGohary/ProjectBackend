
namespace NativeBackend.Application.Common.Models.Identity
{
    public class AuthResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneKey { get; set; }
        public string PhoneNumber { get; set; }
        public string? LogoImagePath { get; set; }
        public string? Mail { get; set; }
        //public string? Language { get; set; }
        //public bool? SendNotification { get; set; } = true;
        public DateTime? BirthDate { get; set; }
        //public bool Verified { get; set; }
        //public bool IsMale { get; set; }


        public string Token { get; set; }
    }
}
