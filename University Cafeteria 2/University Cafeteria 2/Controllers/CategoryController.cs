using Microsoft.AspNetCore.Mvc;
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
    }
}
