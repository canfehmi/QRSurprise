using QRSurprise.Models.DAL.Entities;
using X.PagedList;

namespace QRSurprise.Models.DAL.ViewModels
{
    public class RecipeIndexViewModel
    {
        public int? SelectedCategoryId { get; set; }
        public IPagedList<Recipe> Recipes { get; set; }
    }
}
