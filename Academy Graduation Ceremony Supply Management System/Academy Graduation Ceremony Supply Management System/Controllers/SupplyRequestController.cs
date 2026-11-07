using Academy_Graduation_Ceremony_Supply_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Academy_Graduation_Ceremony_Supply_Management_System.Controllers
{
    public class SupplyRequestController : Controller
    {

        private readonly List<Offer> offers = new List<Offer>
            {
                new Offer{SupplierName ="Supplier A",OfferName="Premium Certificate Package",Quantity=35,UnitPrice=2,Category="Graduation Certificates"},
                new Offer{SupplierName ="Supplier B",OfferName="Standard Certificate Package",Quantity=35,UnitPrice=1.5m,Category="Graduation Certificates"},
                new Offer{SupplierName ="Supplier C",OfferName="Luxury Certificate Package",Quantity=35,UnitPrice=2.5m,Category="Graduation Certificates"},
                new Offer{SupplierName ="Supplier D",OfferName="Coffee & Drinks Package",Quantity=100,UnitPrice=2,Category="Hospitality"},
                new Offer{SupplierName ="Supplier E",OfferName="Sandwiches & Snacks Package",Quantity=100,UnitPrice=3,Category="Hospitality"},
                new Offer{SupplierName ="Supplier F",OfferName="Full Hospitality Package",Quantity=100,UnitPrice=4,Category="Hospitality"},
                new Offer{SupplierName ="Supplier G",OfferName="Customized Mugs Package",Quantity=35,UnitPrice=2,Category="Graduation Gifts"},
                new Offer{SupplierName ="Supplier H",OfferName="Graduation Bags Package",Quantity=35,UnitPrice=3,Category="Graduation Gifts"},
                new Offer{SupplierName ="Supplier I",OfferName="Premium Gift Boxes Package",Quantity=35,UnitPrice=4,Category="Graduation Gifts"},

            };

        [HttpGet]
        public IActionResult Index()
        {
          
            return View(offers);
        }
        public IActionResult Create()
        {
            return View();
        }
       
        public IActionResult Review()
        {
            Offer CertificateOffer = null;
            Offer hospitalityOffer = null;
            Offer giftOffer = null; 
            decimal certificateTotal = 0;
            decimal hospitalityTotal = 0;
            decimal giftTotal = 0;
            foreach (var item in offers)
            {
                if (HttpContext.Session.GetString("CertificateOffer") == item.SupplierName && item.Category == "Graduation Certificates")
                {
                    CertificateOffer = item;
                    certificateTotal = item.Quantity * item.UnitPrice;
                    break;
                }
            }
            foreach (var item in offers)
            {
                if (HttpContext.Session.GetString("HospitalityOffer") == item.SupplierName && item.Category == "Hospitality")
                {
                    hospitalityOffer=item;
                    hospitalityTotal = item.Quantity * item.UnitPrice;
                    break;
                }
            }
            foreach (var item in offers)
            {
                if (HttpContext.Session.GetString("GiftOffer") == item.SupplierName && item.Category == "Graduation Gifts")
                {
                    giftOffer=item; 
                    giftTotal = item.Quantity * item.UnitPrice;
                    break;
                }
            }
            decimal total = certificateTotal + hospitalityTotal + giftTotal;
            decimal discount = 0;
            if (total >= 500) {
                discount = .15m;
            }else if(total > 300 && total < 500)
            {
                discount = .10m;
            }
            else
            {
                discount = 0;
            }
            decimal	DiscountAmount = total  * discount;
            decimal FinalTotal = total - DiscountAmount;
            ViewBag.Total = total;
            ViewBag.Discount = discount;
            ViewBag.FinalTotal = FinalTotal;
            ViewBag.DiscountAmount = DiscountAmount;
            ViewBag.giftTotal = giftTotal;
            ViewBag.hospitalityTotal = hospitalityTotal;
            ViewBag.certificateTotal = certificateTotal;
            ViewBag.CertificateSupplier = CertificateOffer.SupplierName;
            ViewBag.CertificateOfferName = CertificateOffer.OfferName;
            ViewBag.CertificateCategory = CertificateOffer.Category;

            ViewBag.HospitalitySupplier = hospitalityOffer.SupplierName;
            ViewBag.HospitalityOfferName = hospitalityOffer.OfferName;
            ViewBag.HospitalityCategory = hospitalityOffer.Category;

            ViewBag.GiftSupplier = giftOffer.SupplierName;
            ViewBag.GiftOfferName = giftOffer.OfferName;
            ViewBag.GiftCategory = giftOffer.Category;
            return View();
        }
        [HttpPost]
        public IActionResult SelectOffer(string certificateSupplier,string hospitalitySupplier,string giftSupplier)
        {
            HttpContext.Session.SetString("CertificateOffer", certificateSupplier);
            HttpContext.Session.SetString("HospitalityOffer", hospitalitySupplier);
            HttpContext.Session.SetString("GiftOffer", giftSupplier);

            return RedirectToAction("Review");
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
