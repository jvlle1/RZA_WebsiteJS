using System.Text;
using System.Security.Cryptography;

namespace RZA_WebsiteJS.Utilities
{
    public static class PasswordUtils
    {
        private static readonly char[] specialCharacters = new char[]
        {
            '!','£','$','%','^','&','*','(',')','-','=','_','+','[',']','{','}',';',':','@','#','~','<','>'
        };
        private static readonly char[] digits = new char[]
        {
            '1','2','3','4','5','6','7','8','9','0'
        };
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convert the password to a byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the byte array to a hexadecimal string
                var sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));  // "x2" for hexadecimal formatting
                }

                return sb.ToString();  // Return the hashed password as a string
            }
        }
    }
    public class UserSession
    {
        public int UserId { get; set; }

    }
}