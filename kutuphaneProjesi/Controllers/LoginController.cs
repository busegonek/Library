using kutuphaneProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace kutuphaneProjesi.Controllers
{
    public class LoginController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "buse", Password = "a123" },
            new User { Id = 2, Username = "mete", Password = "b123" }
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, bool rememberMe)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View("Index");
            }

            // Kullanıcı doğrulandıysa, kullanıcı adını cookie'ye saklayarak kitapları gösteren sayfaya yönlendir
            CookieOptions option = new CookieOptions();
            if (rememberMe)
            {
                option.Expires = System.DateTime.Now.AddDays(1);
            }
            else
            {
                option.Expires = System.DateTime.Now.AddMinutes(10); // Örnek olarak 10 dakika geçerli olacak şekilde ayarlandı
            }

            Response.Cookies.Append("Username", user.Username, option);
            return RedirectToAction("UserReservations", "Reservation");
        }


        public IActionResult Logout()
        {
            // Cookie'yi temizle ve login sayfasına yönlendir
            Response.Cookies.Delete("Username");
            return RedirectToAction("Index");
        }
    }
}
