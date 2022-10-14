using AVTOTTEST_LAST.Services;
using Microsoft.AspNetCore.Mvc;

namespace AVTOTTEST_LAST.Controllers
{
    public class ExamController : Controller
    {
        CookieServices services;

        public ExamController()
        {
            services = new CookieServices();
        }

        public IActionResult Index()
        {
            string? phone =  services.GetUserPhone(HttpContext);
            if (phone == null)
                return RedirectToAction("SignIn", "Login");

            return View();
        }
    }
}
