using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Safety
    {
        const int KEY_LENGTH_BYTES = 32;

        private static string ToStringX2(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("X2"));
            }

            return builder.ToString();
        }

        public static string GetRandomKey()
        {
            var rng = RandomNumberGenerator.Create();
            var keyBytes = new byte[KEY_LENGTH_BYTES];
            rng.GetBytes(keyBytes);

            return ToStringX2(keyBytes);
        }

        public static string GetHMAC(string key, string choice)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(choice));

            return ToStringX2(hash);
        }
    }
}
