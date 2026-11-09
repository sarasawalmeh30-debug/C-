using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using University_Cafeteria_2.Data;
using University_Cafeteria_2.Models;

namespace University_Cafeteria_2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProductController(ApplicationDbContext _contest)
        {
            context = _contest;
        }
        public IActionResult Index()
        {
            var proudects = context.Products.ToList();
            return View(proudects);
        }
        [HttpGet]
        public IActionResult Create()
        {
            LoadLists();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product_model p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        private void LoadLists()
        {
            ViewBag.Categories = new SelectList(
                context.Categories.ToList(), "Id", "Name");

            ViewBag.Suppliers = new SelectList(
                context.Suppliers.ToList(), "Id", "Name");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            LoadLists();
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product_model product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }
    }
}
