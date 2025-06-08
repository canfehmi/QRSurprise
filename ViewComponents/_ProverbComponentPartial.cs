using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;

namespace QRSurprise.ViewComponents
{
    public class _ProverbComponentPartial:ViewComponent
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IViewComponentResult Invoke()
        {
            var value = _context.Proverbs.FirstOrDefault(x => x.IsActive == true);
            if (value != null)
            {
                return View(value);
            }
            else
            {
                ViewBag.Proverb = "No proverb available";
                ViewBag.Author = "Unknown";
            }
            return View();
        }
    }
}
