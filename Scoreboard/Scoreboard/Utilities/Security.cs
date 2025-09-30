using System;
using System.Security.Cryptography;
using System.Text;

namespace Scoreboard.Utilities
{
    public static class Security
    {
        public static string HashPassword(string password)
        {
            var salt = Guid.NewGuid().ToString("N").Substring(0,16);
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(salt + password);
                var hash = sha.ComputeHash(bytes);
                return salt + ":" + Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string password, string stored)
        {
            try
            {
                var parts = stored.Split(':');
                if (parts.Length!=2) return false;
                var salt = parts[0];
                var expected = parts[1];
                using (var sha = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(salt + password);
                    var hash = sha.ComputeHash(bytes);
                    var b64 = Convert.ToBase64String(hash);
                    return b64 == expected;
                }
            }
            catch { return false; }
        }
    }
}
