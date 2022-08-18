using ChequebookRegistry.Data;
using ChequebookRegistry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;



namespace ChequebookRegistry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChequebookRegistryContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ChequebookRegistryContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
               

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

        //        public IActionResult Index()
        //        {
        //            return View();
        //        }
        public async Task<IActionResult> Index()
        {
            return _context.UpcomingPayments != null ?
                        View(await _context.UpcomingPayments.ToListAsync()) :
                        Problem("Entity set 'ChequebookRegistryContext.UpcomingPayments'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}