using Microsoft.AspNetCore.Mvc;

namespace University_Cafeteria.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
