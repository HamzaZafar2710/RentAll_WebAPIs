using Microsoft.AspNetCore.Mvc;

namespace RentAll_WebAPIs.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
