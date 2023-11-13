using BulkyBookWeb.Data;
using DziennikUcznia.Models;
using Microsoft.AspNetCore.Mvc;

namespace DziennikUcznia.Controllers
{
    public class ThemeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ThemeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetTheme(string theme)
        {
            // Pobierz aktualnego użytkownika (pseudokod - dostosuj do swojego mechanizmu autentykacji)
            var userId = "GetUserId();";

            // Sprawdź, czy użytkownik ma już zapisany motyw
            var userPreferences = _context.UserPreferences.SingleOrDefault(up => up.UserId == userId);

            if (userPreferences == null)
            {
                // Jeśli nie ma jeszcze preferencji użytkownika, utwórz nowy rekord
                userPreferences = new UserPreferences
                {
                    UserId = userId,
                    Theme = theme
                };

                _context.UserPreferences.Add(userPreferences);
            }
            else
            {
                // Jeśli użytkownik już ma preferencje, zaktualizuj motyw
                userPreferences.Theme = theme;
                _context.UserPreferences.Update(userPreferences);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home"); // lub inna akcja
        }
    }
}
