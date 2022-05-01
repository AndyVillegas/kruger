using System.Security.Cryptography;
using System.Text;

namespace Kruger.Shared.Encrypt
{
    public static class Sha256
    {
        public static string Encrypt(string data)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            var sb = new StringBuilder();
            foreach (var mByte in bytes)
                sb.Append(mByte.ToString("x2"));
            return sb.ToString();
        }
    }
}
