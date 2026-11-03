using Microsoft.AspNetCore.Mvc;

namespace task1mvc.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            List<string> Categories = new List<string> { "Drinks", "Food", "Snacks", "Hot Drinks", "Cold Drinks " };
            ViewBag.Categories = Categories;
            return View();
        }
        [HttpGet]
        public IActionResult Products()
        {
            ViewData["PageTitle"] = "Cafeteria Products";
            ViewData["ManagerName"] = "Ahmad Ali";
            ViewData["NumberofProducts"] = 5;
            string[] productsarr = { "Water", "Orange", "Juice", "Coffee", "Sandwich", "Chocolate" };
            ViewData["Products"] = productsarr;
            return View();
        }
        public IActionResult Suppliers()
        {
            ViewBag.PageTitle = "Our Suppliers";
            ViewBag.NumberofSuppliers= 3;
            string[] arr = { "Fresh Food Company", "Happy Drinks Company", "Daily Supplies Company" };
            ViewBag.arraycontaining = arr;
            return View();
        }
        [HttpGet]
        public IActionResult CreateRequest()
        {

            return View();

        }
        [HttpPost]
        public IActionResult SubmitRequest()
        {
            string employeeName = Request.Form["EmployeeName"];
            string productName = Request.Form["ProductName"];
            string quantity = Request.Form["Quantity"];
            string requiredDate = Request.Form["RequiredDate"];

            if (string.IsNullOrEmpty(employeeName))
            {
                ViewBag.Message = "Error: Employee Name is required!";
                ViewBag.MessageClass = "alert-danger";
                return View("CreateRequest");

            }
            else
            {
                TempData["Message"] = "Request submitted successfully!";

                return RedirectToAction("About");
            }

           
        
           
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
