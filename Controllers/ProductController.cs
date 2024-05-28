using EF_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_DBFirst.Controllers
{
    public class ProductController : Controller
    {
        Sqlquerry1Context db = new Sqlquerry1Context();
        public IActionResult Index(string search = "",string SortColumn="ProductId",string IconClass="fa-sort-asc")
        {
            //search
            List<Product> products = db.Products.Include(p=>p.Category).Include(p=>p.Brand).Where(row=>row.ProductName.Contains(search)).ToList();

            ViewBag.Search = search;

            //sort
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn=="ProductId")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductId).ToList();
                }
                else { 
                products = products.OrderByDescending(row=>row.ProductId).ToList();
                }
            } else if (SortColumn== "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductName).ToList();
                }
            } else if (SortColumn=="Price")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.Price).ToList();
                }
            }
            return View(products);
        }
        public IActionResult Detail(int id)
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
            Product product = db.Products.Where(row => row.ProductId == id).FirstOrDefault();
            return View(product);  
        }
        public IActionResult Create()
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();


            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
         db.Products.Add(product);
        db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
            Product product = db.Products.Where(row => row.ProductId == id).FirstOrDefault();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product pro)
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
            Product product = db.Products.Where(row => row.ProductId == pro.ProductId).FirstOrDefault();
            product.ProductName = pro.ProductName;
            product.Price = pro.Price;
            product.DateOfPurchase = pro.DateOfPurchase;
            product.AvailabilityStatus = pro.AvailabilityStatus;
            product.CategoryId = pro.CategoryId;
            product.Active = pro.Active;


            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
            Product product = db.Products.Where(row => row.ProductId==id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id,Product p)
        {
            Sqlquerry1Context db = new Sqlquerry1Context();
            Product product = db.Products.Where(row => row.ProductId == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }

}
