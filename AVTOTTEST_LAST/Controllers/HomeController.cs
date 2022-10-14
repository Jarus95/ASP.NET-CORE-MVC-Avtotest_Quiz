using AVTOTTEST_LAST.Models;
using AVTOTTEST_LAST.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AVTOTTEST_LAST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserRepositorySQL userSQL;


        public IActionResult Index()
        {
            userSQL = new UserRepositorySQL();
            
            return View();
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
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    }
}