using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;
using QRSurprise.Models.DAL.Entities;

namespace QRSurprise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProverbController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var values = _context.Proverbs.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProverb()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProverb(Proverb proverb)
        {
            if (ModelState.IsValid)
            {
                _context.Proverbs.Add(proverb);
                var old = _context.Proverbs.FirstOrDefault(x => x.IsActive == true);
                if (old != null)
                {
                    old.IsActive = false;
                    _context.Proverbs.Update(old);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proverb);
        }
        [HttpGet]
        public IActionResult UpdateProverb(int id)
        {
            var proverb = _context.Proverbs.Find(id);
            if (proverb == null)
            {
                return NotFound();
            }
            return View(proverb);
        }
        [HttpPost]
        public IActionResult UpdateProverb(Proverb proverb)
        {
            if (ModelState.IsValid)
            {
                _context.Proverbs.Update(proverb);
                if(proverb.IsActive)
                {
                    var old = _context.Proverbs.FirstOrDefault(x => x.IsActive == true && x.Id != proverb.Id);
                    if (old != null)
                    {
                        old.IsActive = false;
                        _context.Proverbs.Update(old);
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proverb);
        }
        public IActionResult DeleteProverb(int id)
        {
            var proverb = _context.Proverbs.Find(id);
            if (proverb == null)
            {
                return NotFound();
            }
            _context.Proverbs.Remove(proverb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
