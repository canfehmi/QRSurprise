using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QRSurprise.Models.DAL.Context;
using QRSurprise.Models.DAL.Entities;
using X.PagedList.Extensions;

namespace QRSurprise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var values = _context.Recipes.Include(r => r.RecipeCategory).OrderByDescending(x => x.Id).ToPagedList(page,pageSize);
            return View(values);
        }
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRecipe(int id)
        {
            var recipe = _context.Recipes.Include(x => x.RecipeCategory).FirstOrDefault(x => x.Id == id);
            ViewBag.Categories = new SelectList(_context.RecipeCategories, "Id", "Title");
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }
        [HttpPost]
        public IActionResult UpdateRecipe(Recipe recipe)
        {
            ViewBag.Categories = new SelectList(_context.RecipeCategories, "Id", "Title");
            if (ModelState.IsValid)
            {
                _context.Recipes.Update(recipe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }
        [HttpGet]
        public IActionResult CreateRecipe()
        {
            ViewBag.Categories = new SelectList(_context.RecipeCategories, "Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult CreateRecipe(Recipe recipe)
        {
            ViewBag.Categories = new SelectList(_context.RecipeCategories, "Id", "Title");
            if (ModelState.IsValid)
            {
                var category = _context.RecipeCategories.Find(recipe.RecipeCategoryId);
                if (category != null)
                {
                    recipe.RecipeCategory = category;
                }
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }
    }
}