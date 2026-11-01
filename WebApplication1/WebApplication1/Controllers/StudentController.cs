using Microsoft.AspNetCore.Mvc;

namespace MyFirstMvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.StudentName = "Sara";

            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.StudentID = id;

            return View();
        }
    }
}
