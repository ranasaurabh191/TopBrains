using LoginPage.AuthLoginRepositories;
using Microsoft.AspNetCore.Mvc;
namespace LoginPage.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthLoginRepository _loginUser;
        public LoginController(IAuthLoginRepository loginUser)
        {
            _loginUser = loginUser;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string passcode)
        {
            var issuccess = _loginUser.AuthenticateUser(username, passcode);
            if (issuccess.Result != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);

                TempData["username"] = "GAURAV";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed", username);
                return View();
            }
        }
    }
}