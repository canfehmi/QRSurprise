using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRSurprise.Models.DAL.Context;
using QRSurprise.Models.DAL.Entities;

namespace QRSurprise.Controllers
{
    public class UserResipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserResipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(RecipeCategory? category, string? search)
        {
            var recipes = _context.Recipes.Include(x=>x.RecipeCategory).AsQueryable();
            //if (category != null)
            //{
            //    recipes = recipes.Where(r => r.RecipeCategory == category);
            //}
            if(!string.IsNullOrEmpty(search))
            {
                recipes = recipes.Where(r => r.Title.Contains(search) || r.Instruction.Contains(search));
            }
            ViewBag.Categories = _context.Recipes
                .Select(r => r.RecipeCategory)
                .Distinct()
                .ToList();
            ViewBag.Search = search;
            ViewBag.CurrentCategory = category;
            return View(recipes.ToList());
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
    }
}
