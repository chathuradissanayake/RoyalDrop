using Microsoft.AspNetCore.Mvc;

namespace RoyalDrop.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
