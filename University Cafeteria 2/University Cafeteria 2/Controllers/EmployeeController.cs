using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using University_Cafeteria_2.Data;
using University_Cafeteria_2.Models;

namespace University_Cafeteria_2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeeController(ApplicationDbContext _contest)
        {
            context = _contest;
        }
        public IActionResult Index()
        {
            var Employee = context.Employee.ToList();
            return View(Employee);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            context.Employee.Add(e);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var Employee = context.Employee.Find(id);
            return View(Employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee Employee)
        {
            context.Employee.Update(Employee);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var Employee = context.Employee.Find(id);
            context.Employee.Remove(Employee);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var Employee = context.Employee.Find(id);
            return View(Employee);
        }
    }
}
