using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;
using QRSurprise.Models.DAL.Entities;

namespace QRSurprise.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.RecipeCategories.ToList();
            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(RecipeCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.RecipeCategories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult EditCategory(int id)
        {
            var category = _context.RecipeCategories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(RecipeCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.RecipeCategories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.RecipeCategories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
