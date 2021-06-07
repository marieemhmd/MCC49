using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Handler
{
    public class Hashing
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashPassword(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password, GetRandomSalt());
        }

        public static bool ValidatePassword(string Password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(Password, correctHash);
        }
    }
}
