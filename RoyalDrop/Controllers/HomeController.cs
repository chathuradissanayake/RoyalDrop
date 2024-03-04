using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyalDrop.Data;
using RoyalDrop.Models;
using System.Diagnostics;

namespace RoyalDrop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoyalDropContext _context;

        public HomeController(ILogger<HomeController> logger, RoyalDropContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int pg=1)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'product'  is null.");
            }

            var products = from m in _context.Products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Productname!.Contains(searchString));
            }

            const int pageSize = 12;
            if(pg > 1)
            {
                pg = 1;
            }

            int recsCount = products.Count();
            var pager = new Pager(recsCount,pg, pageSize);
            int recSkip = (pg-1) * pageSize;
            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(await products.ToListAsync());
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contactus()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Favourites()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PurchaseCart()
        {
            return View();
        }
    }
}