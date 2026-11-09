using Microsoft.AspNetCore.Mvc;
using University_Cafeteria_2.Data;
using University_Cafeteria_2.Models;

namespace University_Cafeteria_2.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext context;
        public SupplierController(ApplicationDbContext _contest)
        {
            context = _contest;
        }
        public IActionResult Index()
        {
            var Suppliers = context.Suppliers.ToList();
            return View(Suppliers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier_model s)
        {
            context.Suppliers.Add(s);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Supplier = context.Suppliers.Find(id);
            return View(Supplier);
        }
        [HttpPost]
        public IActionResult Edit(Supplier_model Supplier)
        {
            context.Suppliers.Update(Supplier);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var Supplier = context.Suppliers.Find(id);
            context.Suppliers.Remove(Supplier);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var Supplier = context.Suppliers.Find(id);
            return View(Supplier);
        }
    }
}
