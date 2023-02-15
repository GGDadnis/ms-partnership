using System.Security.Cryptography;
using System.Text;

namespace ms_partnership.Service
{
    public class HashPassword
    {
        public string CreatingSalt()
        {
            byte[] salting = RandomNumberGenerator.GetBytes(128 / 8);
            string saltToString = Convert.ToBase64String(salting);

            return saltToString;
        }

        public string HashingPassword(string password, string salt)
        {
            string spicePassword = password + salt;

            SHA256 hash = SHA256.Create();  
            var passwordBytes = Encoding.Default.GetBytes(spicePassword);
            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword);
        }
    }
}