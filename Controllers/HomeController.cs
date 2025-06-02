using Microsoft.AspNetCore.Mvc;

namespace QRSurprise.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
