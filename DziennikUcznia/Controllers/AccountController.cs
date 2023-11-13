using BulkyBookWeb.Data;
using DziennikUcznia.Enum;
using DziennikUcznia.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DziennikUcznia.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET
        public IActionResult Register()
        {
            var roleList = GetRoleList();
            ViewBag.Roles = roleList;
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {

            // Sprawdź, czy użytkownik o podanym loginie już istnieje
            if (_context.Users.Any(u => u.Login == model.Login))
            {
                ModelState.AddModelError("Username", "Użytkownik o takim loginie już istnieje");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                // Haszuj hasło przed zapisaniem do bazy danych
                model.Password = PasswordHasher.HashPassword(model.Password);

                _context.Users.Add(model);
                _context.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Login", "Account");
            }
            var roleList = GetRoleList();
            ViewBag.Roles = roleList;
            return View(model);
        }



        //Logowanie
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Login == model.Login);

                if (user != null && PasswordHasher.VerifyPassword(model.Password, user.Password))
                {
                    // Utwórz uwierzytelnienie dla użytkownika
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        // Dodaj właściwości uwierzytelniania, jeśli są potrzebne
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    HttpContext.Session.SetString("IsLoggedIn", "true");// Ustawienie ze zalogowany
                    TempData["success"] = "Zalogowano pomyślnie";
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "Nieprawidłowy login lub hasło");
            }

            return View(model);
        }

        //sprawdzamy czy zalogowany
        protected bool IsUserLoggedIn()
        {
            return HttpContext.Session.GetString("IsLoggedIn") == "true";
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["success"] = "Wylogowano pomyślnie";
            return RedirectToAction("Index", "Home");
        }



        private List<SelectListItem> GetRoleList()
        {
            var roles = Enum.Roles.GetValues(typeof(Roles))
                            .Cast<Roles>()
                            .Where(r => r != Roles.Admin)  // Pomijamy Admina
                            .Select(r => new SelectListItem
                            {
                                Text = r.ToString(),
                                Value = r.ToString()
                            })
                            .ToList();

            return roles;
        }

        //Wyswietlanie inforamcji o uzytkowniku
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        //Edycja inforamcji uzytkownika
        [HttpGet]
        public async Task<IActionResult> EditProfile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roleList = GetRoleList();
            ViewBag.Roles = roleList;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, User user, IFormFile profilePicture)
        {
            var roleList = GetRoleList();
            ViewBag.Roles = roleList;

            return View(user);
        }

        //Usuwanie uzytkownika
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _context.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Users.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");

        }

        //Ciasteczka
        [HttpPost]
        public IActionResult ChangeTheme(string theme)
        {
            // Tutaj zapisz preferencje motywu w ciasteczku
            SetThemeCookie(theme);

            // Możesz przekierować użytkownika z powrotem na tę samą stronę lub gdziekolwiek indziej
            return RedirectToAction("Index", "Home");
        }

        private void SetThemeCookie(string theme)
        {
            Response.Cookies.Append("theme", theme, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30) // Dostosuj do swoich potrzeb
            });
        }


    }
}
