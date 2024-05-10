using EF_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_DBFirst.Controllers
{
    public class ProductController : Controller
    {
        Sqlquerry1Context db = new Sqlquerry1Context();
        public IActionResult Index(string search="")
        {
            List<Product>products = db.Products.Where(row=> row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(products);
        }
        public IActionResult Detail(int id)
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
            Product product = db.Products.Where(row => row.ProductId == id).FirstOrDefault();
            return View(product);  
        }
    }

}
