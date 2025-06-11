using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QRSurprise.Models.DAL.Context;
using QRSurprise.Models.DAL.Entities;
using QRSurprise.Models.DAL.ViewModels;
using X.PagedList.Extensions;

namespace QRSurprise.Controllers
{
    public class UserResipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserResipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;
            var recipes = _context.Recipes
                .Include(r => r.RecipeCategory)
                .OrderByDescending(r => r.Id)
                .ToPagedList(pageNumber, pageSize);

            ViewBag.Categories = new SelectList(_context.RecipeCategories, "Id", "Title");
            var model = new RecipeIndexViewModel
            {
                Recipes = recipes
            };

            return View(model);
        }
        public IActionResult RecipeDetails(int id)
        {
            var recipe = _context.Recipes
                .Include(r => r.RecipeCategory)
                .FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }
        [HttpPost]
        public IActionResult GetRecipeByCategory(RecipeIndexViewModel model, int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;

            var filteredRecipes = _context.Recipes
                .Include(r => r.RecipeCategory)
                .Where(r => r.RecipeCategoryId == model.SelectedCategoryId)
                .OrderByDescending(r => r.Id)
                .ToPagedList(pageNumber, pageSize);

            model.Recipes = filteredRecipes;

            ViewBag.Categories = new SelectList(_context.RecipeCategories, "Id", "Title", model.SelectedCategoryId);

            return View("Index", model); 
        }


    }
}
