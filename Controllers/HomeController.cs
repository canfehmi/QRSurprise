using Microsoft.AspNetCore.Mvc;
using QRSurprise.Models.DAL.Context;

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
