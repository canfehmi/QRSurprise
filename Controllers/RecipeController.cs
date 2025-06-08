using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QRSurprise.Models.DAL.Context;
using QRSurprise.Models.DAL.Entities;
using QRSurprise.Models.DAL.ViewModels;
using X.PagedList.Extensions;

namespace QRSurprise.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var values = _context.Recipes.Include(x => x.RecipeCategory).OrderByDescending(x=>x.Id).ToPagedList(page,pageSize);
            return View(values);
        }
        public IActionResult Details(int id)
        {
            var recipe = _context.Recipes.Include(x => x.RecipeCategory).FirstOrDefault(x => x.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }
        public IActionResult CreateRecipe()
        {
            ViewBag.Categories = _context.RecipeCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateRecipe(Recipe model)
        {
            ViewBag.Categories = _context.RecipeCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            }).ToList();
            if (ModelState.IsValid)
            {
                var category = _context.RecipeCategories.Find(model.RecipeCategoryId);
                if(category!= null)
                {
                    model.RecipeCategory = category;
                }
                _context.Recipes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditRecipe(int id)
        {
            var recipe = _context.Recipes.Include(x => x.RecipeCategory).FirstOrDefault(x => x.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            var model = new RecipeViewModel
            {
                Recipe = recipe,
                Categories = _context.RecipeCategories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditRecipe(RecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Recipes.Update(model.Recipe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            model.Categories = _context.RecipeCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            }).ToList();
            return View(model);
        }
    }
}
