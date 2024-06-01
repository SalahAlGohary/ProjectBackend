using System.ComponentModel.DataAnnotations;

namespace NativeBackend.Application.Common.Models.Identity
{
    public class RegistrationRequest
    {
        //[Required]
        //public string PhoneKey { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Mail { get; set; }

        public DateTime? BirthDate { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        //[Required]
        //public bool  IsMale { get; set; }
    }
}
