namespace QRSurprise.Models.DAL.Entities
{
    public class RecipeCategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
