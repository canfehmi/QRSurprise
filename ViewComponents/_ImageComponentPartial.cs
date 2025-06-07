using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;

namespace QRSurprise.ViewComponents
{
    public class _ImageComponentPartial:ViewComponent
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IViewComponentResult Invoke()
        {
            var value = _context.Images.FirstOrDefault(x => x.IsActive == true);
            if (value != null)
            {
                ViewBag.Image = value.ImageUrl;
            }
            else
            {
                ViewBag.Image = "https://i.hizliresim.com/618qkal.jpg"; // Fallback image URL
            }
            return View();
        }
    }
}
