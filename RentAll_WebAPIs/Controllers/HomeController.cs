using Microsoft.AspNetCore.Mvc;

namespace RentAll_WebAPIs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
