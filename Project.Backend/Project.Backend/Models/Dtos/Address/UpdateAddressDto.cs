namespace Project.Backend.Models.Dtos.Address
{
    public class UpdateAddressDto
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? BuildingNumber { get; set; }
        public int? Floor { get; set; }
        public int? Appartment { get; set; }
    }
}
