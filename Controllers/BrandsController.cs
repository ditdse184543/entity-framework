using EF_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_DBFirst.Controllers
{
    public class BrandsController : Controller
    {
        Sqlquerry1Context db = new Sqlquerry1Context();
        
        public IActionResult Index()
        {
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}
