using Microsoft.AspNetCore.Mvc;

namespace EF_DBFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
