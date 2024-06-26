﻿using Project.Backend.Entities.Common;

namespace Project.Backend.Entities
{
    public class Address : BaseEntity
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? BuildingNumber { get; set; }
        public int? Floor { get; set; }
        public int? Appartment { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }

    }
}
