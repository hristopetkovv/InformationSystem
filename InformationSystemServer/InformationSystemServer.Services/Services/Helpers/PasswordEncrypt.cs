using System;
using System.Security.Cryptography;
using System.Text;

namespace InformationSystemServer.Services.Services
{
    public class PasswordEncrypt
    {
        private const string ALPHABET = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static (string Hash, string Salt) ComputeHash(string password)
        {
            var salt = GenerateString();

            var passSalt = password + salt;
            var passwordBytes = Encoding.UTF8.GetBytes(passSalt);

            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(passwordBytes);

            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));

            return (hashedInputStringBuilder.ToString(), salt);
        }

        public static string ComputeHash(string password, string salt)
        {
            var passSalt = password + salt;
            var passToHash = Encoding.UTF8.GetBytes(passSalt);

            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(passToHash);

            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }

        public static string GenerateString(int size = 10)
        {
            Random rand = new Random();

            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = ALPHABET[rand.Next(ALPHABET.Length)];
            }

            return new string(chars);
        }
    }
}
