using kutuphaneProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace kutuphaneProjesi.Controllers
{
    public class ReservationController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "buse", Password = "a123" },
            new User { Id = 2, Username = "mete", Password = "b123" }
        };

        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1" },
            new Book { Id = 2, Title = "Book 2" }
        };

        private static List<Reservation> reservations = new List<Reservation>();

        // Index action'ı, rezervasyon sayfasını görüntüler
        public IActionResult Index()
        {
            ViewData["Users"] = users;
            ViewData["Books"] = books;
            ViewData["Reservations"] = reservations;
            return View();
        }

        // Reserve action'ı, rezervasyon işlemini gerçekleştirir
        [HttpPost]
        
        public IActionResult Reserve(int userId, int bookId, DateTime reservedDate)
        {
            // Aynı tarihte aynı kitabı rezerve eden var mı diye kontrol et
            if (reservations.Any(r => r.BookId == bookId && r.ReservedDate.Date == reservedDate.Date))
            {
                ViewBag.ErrorMessage = "The book is already reserved for the selected date.";
                ViewData["Users"] = users;
                ViewData["Books"] = books;
                ViewData["Reservations"] = reservations;
                return View("Index");
            }

            var reservation = new Reservation
            {
                Id = reservations.Count + 1,
                UserId = userId,
                BookId = bookId,
                ReservedDate = reservedDate
            };
            reservations.Add(reservation);
            return RedirectToAction("Index");
        }


        // Kullanıcının rezervasyonlarını gösteren action
        public IActionResult UserReservations()
        {
            var username = HttpContext.Request.Cookies["Username"];
            if (string.IsNullOrEmpty(username))
            {
                // Kullanıcı oturumu doğrulanmadıysa, login sayfasına yönlendir
                return RedirectToAction("Index", "Login");
            }

            var user = users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                // Kullanıcı bulunamadıysa, hata sayfasına yönlendir
                return RedirectToAction("Index", "Error");
            }

            var userReservations = reservations.Where(r => r.UserId == user.Id).ToList();
            ViewData["Username"] = username;
            ViewData["UserReservations"] = userReservations;
            ViewData["Books"] = books;

            return View();
        }   

    }
}
