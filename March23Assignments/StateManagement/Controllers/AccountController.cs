using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;

namespace StateManagement.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cookieOption = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(1)
                };
                Response.Cookies.Append("Username", model.Username, cookieOption);
                return RedirectToAction("Welcome");
            }
            return View(model);
        }
        public IActionResult Welcome()
        {
            var username = HttpContext.Session.GetString("Username");
            //if(Request.Cookies.ContainsKey("Username"))
            //{
            //    string username = Request.Cookies["Username"];
            //    ViewBag.Username = username;
            //}
            if (!String.IsNullOrEmpty(username))
            {
                ViewBag.UserName = username;
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            //Response.Cookies.Delete("Username");
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login");
        }
    }
}
