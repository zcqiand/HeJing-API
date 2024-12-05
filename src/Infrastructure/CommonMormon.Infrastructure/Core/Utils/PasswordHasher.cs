using System.Security.Cryptography;
using System.Text;

namespace CommonMormon.Infrastructure.Core.Utils;

public class PasswordHasher
{
    public readonly string StaticSalt = "nanrong";

    public static string HashPassword(string password, string salt)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashedBytes = sha512.ComputeHash(saltedPassword);

            return Convert.ToBase64String(hashedBytes);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword, string salt)
    {
        string newHash = HashPassword(password, salt);
        return newHash == hashedPassword;
    }
}
