using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;

namespace QRSurprise.ViewComponents
{
    public class _ProverbComponentPartial:ViewComponent
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IViewComponentResult Invoke()
        {
            ViewBag.Proverb = _context.Proverbs.FirstOrDefault(x => x.IsActive == true).FullProverb;
            ViewBag.WhoSay = _context.Proverbs.FirstOrDefault(x => x.IsActive == true).WhoSay;
            return View();
        }
    }
}
