using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;

namespace QRSurprise.ViewComponents
{
    public class _ProverbComponentPartial:ViewComponent
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IViewComponentResult Invoke()
        {
            ViewBag.Proverb = _context.Proverbs.FirstOrDefault(x => x.ActivateCode == 705).FullProverb;
            ViewBag.WhoSay = _context.Proverbs.FirstOrDefault(x => x.ActivateCode == 705).WhoSay;
            return View();
        }
    }
}
