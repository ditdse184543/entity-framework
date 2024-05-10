using EF_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_DBFirst.Controllers
{
    public class CategoriesController : Controller
    {
        Sqlquerry1Context db = new Sqlquerry1Context();

        public IActionResult Index()
        {
            var listsanpham = db.Categories.ToList();

            return View(listsanpham);
        }
    }
}
