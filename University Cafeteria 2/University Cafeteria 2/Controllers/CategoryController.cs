using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Cafeteria_2.Data;
using University_Cafeteria_2.Models;

namespace University_Cafeteria_2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext _contest)
        {
            context= _contest;
        }
            public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category_model c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id ) {
            var category = context.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category_model catagory)
        {
            context.Categories.Update(catagory);
            context.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public IActionResult Delete(int id) {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }
    }
}
