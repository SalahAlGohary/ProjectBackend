﻿using Microsoft.AspNetCore.Identity;
namespace Project.Backend.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? TwitterUserName { get; set; }
        public virtual List<Favorite>? Favorites { get; set; }
        public virtual List<Address>? Addresses { get; set; }

    }
}
