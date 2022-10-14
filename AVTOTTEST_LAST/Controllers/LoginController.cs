using AVTOTTEST_LAST.Models;
using AVTOTTEST_LAST.Repository;
using AVTOTTEST_LAST.Services;
using AVTOTTEST_LAST.Validations;
using Microsoft.AspNetCore.Mvc;

namespace AVTOTTEST_LAST.Controllers
{
    public class LoginController : Controller
    {
        public UserRepositorySQL userSQL;
        public PhoneAttribute phoneAttribute;
        public CookieServices cookieServices;

        public LoginController()
        {
            userSQL = new UserRepositorySQL();
            phoneAttribute = new PhoneAttribute();
            cookieServices = new CookieServices();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            bool isUserexists = phoneAttribute.IsValid(user);

            if (isUserexists)
            {
                ViewBag.isUser = true;
                return View(user);
            }

           

            userSQL.InsertIntoTable(user);
            ViewBag.user = user.Name;
            cookieServices.SaveToCookie(user, HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
