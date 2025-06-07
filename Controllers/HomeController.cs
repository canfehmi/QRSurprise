using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;

namespace QRSurprise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReadIt()
        {
            var value = _context.Proverbs.FirstOrDefault(x=>x.IsActive == true);
            if(value != null)
            {
                if(value.IsRead == false)
                {
                    value.IsRead = true;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
