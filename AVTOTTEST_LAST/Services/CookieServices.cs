using AVTOTTEST_LAST.Models;

namespace AVTOTTEST_LAST.Services
{
    public class CookieServices
    {

        public string? GetUserPhone(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("phone"))
            {
                return context.Request.Cookies["phone"];
            }

            return null;
        }

        public void SaveToCookie(User user, HttpContext context)
        {
            context.Response.Cookies.Append("phone", user.Phone);
        }
    }
}
