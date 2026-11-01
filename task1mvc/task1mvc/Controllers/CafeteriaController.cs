using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using task1mvc.Models;

namespace task1mvc.Controllers
{
    public class CafeteriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Suppliers()
        {
            return View();
        }
        public IActionResult SupplyStatus()
        {
            return View();
        }
    }
}
