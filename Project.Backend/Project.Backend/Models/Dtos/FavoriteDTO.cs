namespace Project.Backend.Models.Dtos
{
    public class FavoriteDTO
    {
        public int RecipeId { get; set; }
        public Guid UserId { get; set; }
        public virtual RecipeDTO Recipe { get; set; }
    }
}
