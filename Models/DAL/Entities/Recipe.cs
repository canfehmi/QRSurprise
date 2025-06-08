namespace QRSurprise.Models.DAL.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Ingredients { get; set; } = default!;
        public string Instruction { get; set; } = default!;
        public int? RecipeCategoryId { get; set; }
        public RecipeCategory? RecipeCategory { get; set; }
    }
}
