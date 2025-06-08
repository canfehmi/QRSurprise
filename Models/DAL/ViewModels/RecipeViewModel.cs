using Microsoft.AspNetCore.Mvc.Rendering;
using QRSurprise.Models.DAL.Entities;

namespace QRSurprise.Models.DAL.ViewModels
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; } = default!;
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
