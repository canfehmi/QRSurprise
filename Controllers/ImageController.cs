using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;

namespace QRSurprise.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Images.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateImage(QRSurprise.Models.DAL.Entities.Image img)
        {
            if (ModelState.IsValid)
            {
                _context.Images.Add(img);
                var old = _context.Images.FirstOrDefault(x => x.ActivateCode == 705);
                if (old != null)
                {
                    old.ActivateCode = 0; 
                    _context.Images.Update(old);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(img);
        }
        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
            var image = _context.Images.Find(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }
        [HttpPost]
        public IActionResult UpdateImage(QRSurprise.Models.DAL.Entities.Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Images.Update(image);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }
        public IActionResult DeleteImage(int id)
        {
            var image = _context.Images.Find(id);
            if (image == null)
            {
                return NotFound();
            }
            _context.Images.Remove(image);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
