using BulkyBookWeb.Data;
using DziennikUcznia.Enum;
using DziennikUcznia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DziennikUcznia.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = GetRoleList();
            ViewBag.Roles = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Sprawdź, czy użytkownik o podanym loginie już istnieje
                if (_context.Users.Any(u => u.Login == model.Login))
                {
                    ModelState.AddModelError("Username", "Użytkownik o takim loginie już istnieje");
                    return View(model);
                }


                // Dodaj nowego użytkownika do bazy danych
                var newUser = new User
                {
                    Name = model.Name,
                    Password = HashPassword(model.Password), // Funkcja do haszowania hasła
                    Email = model.Email,
                    Roles = model.Roles  // Przykładowa rola, możesz dostosować do swoich potrzeb
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                 return RedirectToAction("Login", "Account");
            }
            var roleList = GetRoleList();
            ViewBag.Roles = roleList;
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Sprawdź, czy istnieje użytkownik o podanym loginie
                var user = _context.Users.FirstOrDefault(u => u.Login == model.Login);

                if (user != null && VerifyPassword(model.Password, user.Password))
                {
                    // Zaloguj użytkownika
                    // Możesz użyć ASP.NET Core Identity do zarządzania sesją
                    // Przykład użycia: SignInManager<User>.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "Nieprawidłowy login lub hasło");
            }

            return View(model);
        }


        // Funkcja do haszowania hasła
        private string HashPassword(string password)
        {
            // Generuj sol (randomowy ciąg znaków) - jest przechowywany razem z hasłem
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            // Haszuj hasło przy użyciu soli
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        // Funkcja do weryfikacji hasła
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Weryfikuj hasło przy użyciu hasha przechowywanego w bazie danych
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }


        private List<SelectListItem> GetRoleList()
        {
            var roles = Enum.Roles.GetValues(typeof(Roles))
                            .Cast<Roles>()
                            .Where(r => r!= Roles.Admin)  // Pomijamy Admina
                            .Select(r => new SelectListItem
                            {
                                Text = r.ToString(),
                                Value = r.ToString()
                            })
                            .ToList();

            return roles;
        }

    }
}
