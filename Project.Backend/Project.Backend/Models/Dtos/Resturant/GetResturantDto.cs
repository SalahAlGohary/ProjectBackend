using Project.Backend.Enums;

namespace Project.Backend.Models.Dtos.Resturant
{
    public class GetResturantDto
    {
        public Guid Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Description { get; set; }
        public string? CoverUrl { get; set; }
        public int Rate { get; set; }
        public decimal DeliveryCost { get; set; }
        public int DeliveryTime { get; set; }
        public List<string>? Specialities { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public decimal MinOrder { get; set; }
        public string? Category { get; set; }
        public string? AddressDetail { get; set; }
    }
}
