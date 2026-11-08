using Microsoft.AspNetCore.Mvc;
using testday4.Models;

namespace testday4.Controllers
{
    public class testController : Controller
    {
        private readonly MyDbContext _context;
        public testController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Stds.ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }

        // حفظ الطالب بعد ضغط زر الحفظ
        [HttpPost]
        public IActionResult Create(Std student)
        {
            _context.Stds.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
}
