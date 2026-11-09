using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using University_Cafeteria_2.Data;
using University_Cafeteria_2.Models;

namespace University_Cafeteria_2.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        public OrderController(ApplicationDbContext _contest)
        {
            context = _contest;
        }
        public IActionResult Index()
        {
            var Order = context.Order.ToList();
            return View(Order);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            LoadLists();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order o)
        {
            context.Order.Add(o);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        private void LoadLists()
        {
            ViewBag.Employee = new SelectList( context.Employee.ToList(), "Id", "FullName");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            LoadLists();
            var Order = context.Order.Find(id);
            return View(Order);
        }
        [HttpPost]
        public IActionResult Edit(Order Order)
        {
            context.Order.Update(Order);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var Order = context.Order.Find(id);
            context.Order.Remove(Order);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var Order = context.Order.Find(id);
            return View(Order);
        }
    }
}
