using System.Security.Cryptography;
using System.Text;

namespace DziennikUcznia.Models
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Generuj losową sól
                byte[] saltBytes = GenerateRandomSalt();
                string salt = Convert.ToBase64String(saltBytes);

                // Kombinuj hasło z solą
                string combinedPassword = password + salt;

                // Oblicz hash
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));

                // Kombinuj hasło z solą i hashem
                string hashedPassword = salt + Convert.ToBase64String(hashedBytes);

                return hashedPassword;
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Wyodrębnij sól i hash z przechowywanego hasła
            byte[] storedBytes = Convert.FromBase64String(storedHash);
            string salt = Encoding.UTF8.GetString(storedBytes, 0, 16);
            string storedHashedPassword = Encoding.UTF8.GetString(storedBytes, 16, storedBytes.Length - 16);

            using (var sha256 = SHA256.Create())
            {
                // Kombinuj wprowadzone hasło z solą
                string combinedPassword = enteredPassword + salt;

                // Oblicz hash
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));

                // Porównaj obliczony hash z przechowywanym
                string enteredHashedPassword = Convert.ToBase64String(hashedBytes);
                return storedHashedPassword.Equals(enteredHashedPassword);
            }
        }

        private static byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
