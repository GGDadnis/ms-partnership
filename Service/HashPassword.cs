using System.Security.Cryptography;
using System.Text;
using ms_partnership.Models.Security;

namespace ms_partnership.Service
{
    public class HashPassword
    {
        public string HashingPassword(string password)
        {
            SHA256 hash = SHA256.Create();  
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword);
        }
    }
}