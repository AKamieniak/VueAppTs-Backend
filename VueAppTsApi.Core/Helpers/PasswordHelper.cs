using System;
using System.Security.Cryptography;
using System.Text;

namespace VueAppTsApi.Core.Helpers
{
    public static class PasswordHelper
    {
        public static bool IsPasswordValid(string password, string passwordHash)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (passwordHash == null)
            {
                throw new ArgumentNullException(nameof(passwordHash));
            }

            return string.Compare(passwordHash, HashPassword(password), StringComparison.Ordinal) == 0;
        }

        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA256.Create().ComputeHash(passwordBytes);
            var result = new StringBuilder();

            foreach (var i in hashBytes)
            {
                result.Append(i.ToString("X2"));
            }

            return result.ToString();
        }
    }
}