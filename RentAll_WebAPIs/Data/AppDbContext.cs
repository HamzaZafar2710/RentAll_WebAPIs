using Microsoft.AspNetCore.Mvc;

namespace RentAll_WebAPIs.Data
{
    public class AppDbContext : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
