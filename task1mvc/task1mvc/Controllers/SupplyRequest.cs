using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;
using task1mvc.Models;
namespace task1mvc.Controllers
{
    public class SupplyRequest : Controller
    {
        public static List<ConfirmedRequest> requests = new List<ConfirmedRequest>();

        public static int requestCounter = 1;
        [HttpGet]
        public IActionResult Index()
        {

            string preferredPriority = Request.Cookies["PreferredPriority"];

            ViewBag.PreferredPriority = preferredPriority;

            return View();
        }
        [HttpPost]
        public IActionResult AddItem(string ProductName, string Category, int Quantity, double UnitPrice, string priority)
        {
           
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                ViewBag.Error = "Product name is required";
                return View("Index");
            }

            if (Quantity <= 0)
            {
                ViewBag.Error = "Quantity must be greater than zero";
                return View("Index");
            }

            if (UnitPrice <= 0)
            {
                ViewBag.Error = "Unit price must be greater than zero";
                return View("Index");
            }

            var items = HttpContext.Session.GetString("Products");

            List<SupplyProduct> products;

            if (items == null)
            {
                products = new List<SupplyProduct>();
            }
            else
            {
                products = JsonSerializer.Deserialize<List<SupplyProduct>>(items);
            }

            SupplyProduct product = new SupplyProduct();

            product.ProductName = ProductName;
            product.Category = Category;
            product.Quantity = Quantity;
            product.UnitPrice = UnitPrice;
            product.Priority = priority;

            products.Add(product);

            HttpContext.Session.SetString("Products", JsonSerializer.Serialize(products) );

            return RedirectToAction("Index");
        }
        public IActionResult Review()
        {
            var items = HttpContext.Session.GetString("Products");
            if (items == null)
            {
                return RedirectToAction("Index");
            }
            List<SupplyProduct> products =JsonSerializer.Deserialize<List<SupplyProduct>>(items);

            if (products == null || products.Count == 0)
            {
                return RedirectToAction("Index");
            }
            double subtotal = 0;
            foreach (var product in products)
            {
                product.Total = product.Quantity * product.UnitPrice;

                subtotal += product.Total;
            }
            // Determine Priority
            string requestPriority = "Normal";

            if (products.Any(p => p.Priority == "Emergency"))
            {
                requestPriority = "Emergency";
            }
            else if (products.Any(p => p.Priority == "Urgent"))
            {
                requestPriority = "Urgent";
            }

            double preparationFee = 0;

            switch (requestPriority)
            {
                case "Normal":
                    preparationFee = 2;
                    break;

                case "Urgent":
                    preparationFee = 5;
                    break;

                case "Emergency":
                    preparationFee = 10;
                    break;
            }
            double discount = 0;

            if (subtotal > 200)
            {
                discount = subtotal * 0.15;
            }
            else if (subtotal > 100)
            {
                discount = subtotal * 0.10;
            }

            double finalTotal = subtotal + preparationFee - discount;
            ViewBag.Subtotal = subtotal;
            ViewBag.Priority = requestPriority;
            ViewBag.PreparationFee = preparationFee;
            ViewBag.Discount = discount;
            ViewBag.FinalTotal = finalTotal;

            ViewBag.Products = products;
            return View();
        }
        public IActionResult ConfirmRequest()
        {
            var items = HttpContext.Session.GetString("Products");

            if (items == null)
            {
                return RedirectToAction("Index");
            }

            List<SupplyProduct> products =
                JsonSerializer.Deserialize<List<SupplyProduct>>(items);

            if (products == null || products.Count == 0)
            {
                return RedirectToAction("Index");
            }

            double subtotal = 0;

            foreach (var product in products)
            {
                product.Total = product.Quantity * product.UnitPrice;

                subtotal += product.Total;
            }

            string requestPriority = "Normal";

            if (products.Any(p => p.Priority == "Emergency"))
            {
                requestPriority = "Emergency";
            }
            else if (products.Any(p => p.Priority == "Urgent"))
            {
                requestPriority = "Urgent";
            }

            double preparationFee = 0;

            switch (requestPriority)
            {
                case "Normal":
                    preparationFee = 2;
                    break;

                case "Urgent":
                    preparationFee = 5;
                    break;

                case "Emergency":
                    preparationFee = 10;
                    break;
            }

            double discount = 0;

            if (subtotal > 200)
            {
                discount = subtotal * 0.15;
            }
            else if (subtotal > 100)
            {
                discount = subtotal * 0.10;
            }

            double finalTotal = subtotal + preparationFee - discount;

            ConfirmedRequest request = new ConfirmedRequest();

            request.RequestID = requestCounter++;

            request.NumberOfProducts = products.Count;

            request.Subtotal = subtotal;

            request.PreparationFee = preparationFee;

            request.Discount = discount;

            request.FinalTotal = finalTotal;

            request.Status = "Confirmed";

            requests.Add(request);

            HttpContext.Session.Remove("Products");

            return RedirectToAction("MyRequests");
        }
        public IActionResult ClearDraft()
        {
            HttpContext.Session.Remove("Products");

            return RedirectToAction("Index");
        }
        public IActionResult SavePreference(string priority)
        {

            CookieOptions options = new CookieOptions();

            options.Expires = DateTime.Now.AddDays(7);

            Response.Cookies.Append("PreferredPriority", priority, options);

            return RedirectToAction("Index");
        }
        public IActionResult MyRequests()
        {
            ViewBag.Requests = requests;

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
