using Project.Backend.Entities.Common;
namespace Project.Backend.Entities
{
    public class Item : BaseEntity
    {
        public string? SpecialNote { get; set; }
        public int Quntity { get; set; }
        //relations
        public Guid DishId { get; set; }
        public Guid DishSizeId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? CartId { get; set; }
        public virtual Dish Dish { get; set; }
        public virtual Order? Order { get; set; }
        public virtual DishSize DishSize { get; set; }
        public virtual Cart? Cart { get; set; }



    }
}
